namespace PaymentIntegrations.Modals
{
    public enum PaymentMethod
    {
        CreditCard,
        PayPal,
        Bitcoin
    }
    public enum PaymentStatus
    {
        Pending,
        Captured,
        Refunded,
        Authorized
    }
}
