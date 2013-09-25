namespace RecurlyNET.Infrastructure
{
    using System.Xml.Serialization;

    /// <summary>
    /// Refund type enum.
    /// </summary>
    public enum RefundType
    {
        /// <summary>
        /// Prorates a refund based on the amount of time remaining in the current bill cycle.
        /// </summary>
        Partial,
        /// <summary>
        /// Performs a full refund of the last charge for the current subscription term.
        /// </summary>
        Full,
        /// <summary>
        /// Terminates the subscription without a refund.
        /// </summary>
        None
    }

    /// <summary>
    /// Recurly currency enum.
    /// </summary>
    public enum RecurlyCurrency
    {
        [XmlEnum("USD")]
        USD,
        [XmlEnum("EUR")]
        EUR,
        [XmlEnum("AUD")]
        AUD
    }

    /// <summary>
    /// Timeframes enum.
    /// </summary>
    public enum UpdateTimeframe
    {
        [XmlEnum("now")]
        Now,
        [XmlEnum("renewal")]
        Renewal
    }

    /// <summary>
    /// Account states enum.
    /// </summary>
    public enum AccountState
    {
        Unknown,
        [XmlEnum("active")]
        Active,
        [XmlEnum("closed")]
        Closed,
        [XmlEnum("past_due")]
        PastDue
    }

    /// <summary>
    /// Recurly subscription states enum.
    /// </summary>
    public enum SubscriptionState
    {
        [XmlEnum("active")]
        Active = 1,
        [XmlEnum("canceled")]
        Canceled = 2,
        [XmlEnum("future")]
        Future = 3,
        [XmlEnum("expired")]
        Expired = 4,
        [XmlEnum("modified")]
        Modified = 5
    }

}
