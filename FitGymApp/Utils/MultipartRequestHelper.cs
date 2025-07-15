using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;

namespace FitGymApp.Utils
{
    public class MultipartSectionData
    {
        public string Name { get; set; } = null!;
        public string? Value { get; set; }
        public byte[]? FileContent { get; set; }
        public string? FileName { get; set; }
        public string? ContentType { get; set; }
    }

    public static class MultipartRequestHelper
    {
        public static string GetBoundary(string contentType, int lengthLimit)
        {
            var elements = contentType.Split(';');
            var boundary = elements.Select(t => t.Trim()).FirstOrDefault(t => t.StartsWith("boundary=", StringComparison.OrdinalIgnoreCase));
            if (boundary == null)
                throw new InvalidDataException("Missing content-type boundary.");
            var boundaryValue = boundary.Substring("boundary=".Length);
            if (string.IsNullOrWhiteSpace(boundaryValue))
                throw new InvalidDataException("Missing content-type boundary value.");
            if (boundaryValue.Length > lengthLimit)
                throw new InvalidDataException($"Multipart boundary length limit {lengthLimit} exceeded.");
            return boundaryValue;
        }

        public static async Task<List<MultipartSectionData>> GetSectionsAsync(Stream body, string boundary)
        {
            var reader = new MultipartReader(boundary, body);
            var sections = new List<MultipartSectionData>();
            Microsoft.AspNetCore.WebUtilities.MultipartSection? section;
            while ((section = await reader.ReadNextSectionAsync()) != null)
            {
                var contentDisposition = section.GetContentDispositionHeader();
                if (contentDisposition == null) continue;
                var name = HeaderUtilities.RemoveQuotes(contentDisposition.Name).Value;
                if (contentDisposition.IsFileDisposition())
                {
                    using var ms = new MemoryStream();
                    await section.Body.CopyToAsync(ms);
                    sections.Add(new MultipartSectionData
                    {
                        Name = name!,
                        FileContent = ms.ToArray(),
                        FileName = HeaderUtilities.RemoveQuotes(contentDisposition.FileName).Value,
                        ContentType = section.ContentType
                    });
                }
                else if (contentDisposition.IsFormDisposition())
                {
                    using var reader2 = new StreamReader(section.Body, Encoding.UTF8);
                    var value = await reader2.ReadToEndAsync();
                    sections.Add(new MultipartSectionData
                    {
                        Name = name!,
                        Value = value
                    });
                }
            }
            return sections;
        }
    }
}
