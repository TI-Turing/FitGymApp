using FitGymApp.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitGymApp.Application.Services.Payments
{
    public class PaymentGatewayResolver
    {
        public static IPaymentGatewayService GetGatewayForCountry(string countryCode)
        {
            return countryCode switch
            {
                "CO" => new WompiPaymentGateway(),
                _ => throw new NotSupportedException("No hay pasarela configurada para este país")
            };
        }
    }
}
