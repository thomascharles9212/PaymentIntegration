namespace PaymentIntegrations.Modals.Paypal
{

    public class CapturedRoot
    {
        public string id { get; set; }
        public string status { get; set; }
        public List<Link> links { get; set; }
    }

    public class Link
    {
        public string rel { get; set; }
        public string method { get; set; }
        public string href { get; set; }
    }

    public class Amount
    {
        public string value { get; set; }
        public string currency_code { get; set; }
    }

    public class CapturedRequestRoot
    {
        public Amount amount { get; set; }
        public string invoice_id { get; set; }
        public bool final_capture { get; set; }
        public string note_to_payer { get; set; }
        public string soft_descriptor { get; set; }
    }
}
