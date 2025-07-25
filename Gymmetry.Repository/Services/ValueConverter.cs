using System.Text.Json;

namespace Gymmetry.Repository.Services
{
    public static class ValueConverter
    {
        public static object? ConvertValueToType(object? value, Type targetType)
        {
            try
            {
                if (value is JsonElement jsonElement)
                {
                    if (targetType == typeof(string))
                        return jsonElement.GetString();
                    if (targetType == typeof(int) || targetType == typeof(int?))
                        return jsonElement.ValueKind == JsonValueKind.Number ? jsonElement.GetInt32() : int.Parse(jsonElement.GetString() ?? "0");
                    if (targetType == typeof(long) || targetType == typeof(long?))
                        return jsonElement.ValueKind == JsonValueKind.Number ? jsonElement.GetInt64() : long.Parse(jsonElement.GetString() ?? "0");
                    if (targetType == typeof(short) || targetType == typeof(short?))
                        return jsonElement.ValueKind == JsonValueKind.Number ? jsonElement.GetInt16() : short.Parse(jsonElement.GetString() ?? "0");
                    if (targetType == typeof(decimal) || targetType == typeof(decimal?))
                        return jsonElement.ValueKind == JsonValueKind.Number ? jsonElement.GetDecimal() : decimal.Parse(jsonElement.GetString() ?? "0");
                    if (targetType == typeof(double) || targetType == typeof(double?))
                        return jsonElement.ValueKind == JsonValueKind.Number ? jsonElement.GetDouble() : double.Parse(jsonElement.GetString() ?? "0");
                    if (targetType == typeof(float) || targetType == typeof(float?))
                        return jsonElement.ValueKind == JsonValueKind.Number ? jsonElement.GetSingle() : float.Parse(jsonElement.GetString() ?? "0");
                    if (targetType == typeof(bool) || targetType == typeof(bool?))
                        return jsonElement.ValueKind == JsonValueKind.True || (jsonElement.ValueKind == JsonValueKind.String && bool.Parse(jsonElement.GetString() ?? "false"));
                    if (targetType == typeof(Guid) || targetType == typeof(Guid?))
                        return Guid.Parse(jsonElement.GetString() ?? Guid.Empty.ToString());
                    if (targetType == typeof(DateTime) || targetType == typeof(DateTime?))
                        return DateTime.Parse(jsonElement.GetString() ?? DateTime.MinValue.ToString());
                    if (targetType == typeof(byte) || targetType == typeof(byte?))
                        return jsonElement.ValueKind == JsonValueKind.Number ? jsonElement.GetByte() : byte.Parse(jsonElement.GetString() ?? "0");
                    if (targetType == typeof(char) || targetType == typeof(char?))
                    {
                        var str = jsonElement.GetString();
                        return !string.IsNullOrEmpty(str) ? str[0] : default(char);
                    }
                    if (targetType == typeof(uint) || targetType == typeof(uint?))
                        return jsonElement.ValueKind == JsonValueKind.Number ? jsonElement.GetUInt32() : uint.Parse(jsonElement.GetString() ?? "0");
                    if (targetType == typeof(ulong) || targetType == typeof(ulong?))
                        return jsonElement.ValueKind == JsonValueKind.Number ? jsonElement.GetUInt64() : ulong.Parse(jsonElement.GetString() ?? "0");
                    if (targetType == typeof(ushort) || targetType == typeof(ushort?))
                        return jsonElement.ValueKind == JsonValueKind.Number ? jsonElement.GetUInt16() : ushort.Parse(jsonElement.GetString() ?? "0");

                    // Fallback: intenta convertir usando ToString y Convert.ChangeType
                    return Convert.ChangeType(jsonElement.ToString(), targetType);
                }
                else
                {
                    if (value == null || value is DBNull)
                        return null;
                    if (targetType.IsEnum)
                        return Enum.Parse(targetType, value.ToString()!);
                    if (targetType == typeof(Guid) || targetType == typeof(Guid?))
                        return Guid.Parse(value.ToString() ?? Guid.Empty.ToString());
                    if (targetType == typeof(DateTime) || targetType == typeof(DateTime?))
                        return DateTime.Parse(value.ToString() ?? DateTime.MinValue.ToString());
                    if (targetType == typeof(uint) || targetType == typeof(uint?))
                        return uint.Parse(value.ToString() ?? "0");
                    if (targetType == typeof(ulong) || targetType == typeof(ulong?))
                        return ulong.Parse(value.ToString() ?? "0");
                    if (targetType == typeof(ushort) || targetType == typeof(ushort?))
                        return ushort.Parse(value.ToString() ?? "0");
                    if (targetType == typeof(byte) || targetType == typeof(byte?))
                        return byte.Parse(value.ToString() ?? "0");
                    if (targetType == typeof(char) || targetType == typeof(char?))
                    {
                        var str = value.ToString();
                        return !string.IsNullOrEmpty(str) ? str[0] : default(char);
                    }
                    if (targetType == typeof(bool) || targetType == typeof(bool?))
                    {
                        var str = value.ToString()?.ToLower();
                        return str == "true" || str == "1";
                    }
                    return Convert.ChangeType(value, targetType);
                }
            }
            catch
            {
                // Manejo de error controlado: retorna null si no se puede convertir
                return null;
            }
        }
    }
}