using PaymentIntegrations.Services;
using System.Collections.Generic;

namespace PaymentIntegrations.PaymentFactory
{
    public class PaymentGatewayFactory
    {
        // Dictionary to store the mapping between paymentMethod and IPaymentGateway implementation
        private static readonly Dictionary<string, IPaymentGateway> PaymentGateways = new Dictionary<string, IPaymentGateway>
        {
            { "PayPal", new PayPalPaymentGateway() },
            { "Stripe", new StripePaymentGateway() }
        };

        /// <summary>
        /// Returns an instance of the appropriate IPaymentGateway implementation based on the provided paymentMethod.
        /// </summary>
        /// <param name="paymentMethod">The payment method to get the gateway for.</param>
        /// <returns>An instance of the appropriate IPaymentGateway implementation.</returns>
        /// <exception cref="ArgumentException">Thrown if the provided paymentMethod is not supported.</exception>
        public IPaymentGateway GetPaymentGateway(string paymentMethod)
        {
            if (PaymentGateways.TryGetValue(paymentMethod, out IPaymentGateway paymentGateway))
            {
                return paymentGateway;
            }
            else
            {
                throw new ArgumentException("Invalid payment method");
            }
        }
    }
}