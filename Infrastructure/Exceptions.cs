namespace RecurlyNET.Infrastructure
{
    using System;

    /// <summary>
    /// Recurly base exception.
    /// </summary>
    public class RecurlyExceptionBase : Exception
    {
        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public RecurlyExceptionBase() { }

        /// <summary>
        /// Constructor with specified message.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public RecurlyExceptionBase(string message) : base(message) { }

        #endregion Constructors
    }

    /// <summary>
    /// UnAuthorized exception.
    /// </summary>
    public class RecurlyUnAuthorizedException : RecurlyExceptionBase
    {
        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public RecurlyUnAuthorizedException() { }

        /// <summary>
        /// Constructor with specified message.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public RecurlyUnAuthorizedException(string message) : base(message) { }

        #endregion Constructors
    }

    /// <summary>
    /// PaymentRequired exception.
    /// </summary>
    public class RecurlyPaymentRequiredException : RecurlyExceptionBase
    {
        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public RecurlyPaymentRequiredException() { }

        /// <summary>
        /// Constructor with specified message.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public RecurlyPaymentRequiredException(string message) : base(message) { }

        #endregion Constructors
    }

    /// <summary>
    /// NotFound exception.
    /// </summary>
    public class RecurlyNotFoundException : RecurlyExceptionBase { }
}
