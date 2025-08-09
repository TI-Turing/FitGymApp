using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO.User.Request;
using Gymmetry.Domain.DTO.User.Response;
using Gymmetry.Domain.DTO;
using Gymmetry.Repository.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace Gymmetry.Application.Services
{
    public static class EmailTemplates
    {
        public static string WelcomeTitle => "¡Bienvenido a Gymmetry!";
        public static string WelcomeBody(string userNameOrEmail) => $"<h1>Bienvenido, {userNameOrEmail}!</h1><p>Gracias por registrarte en Gymmetry.</p>";

        public static string VerificationTitle => "Verifica tu correo electrónico";
        public static string VerificationBody => "<p>Por favor verifica tu correo haciendo clic en el siguiente enlace: <a href='{{verification_link}}'>Verificar</a></p>";
    }
}
