namespace RecurlyNET.Managers.Concrete
{
    using RecurlyNET.Entities;
    using RecurlyNET.Managers.Abstract;
    using RestSharp;

    /// <summary>
    /// Recurly account manager.
    /// </summary>
    public class AccountManager : ManagerBase
    {
        #region Defines

        /// <summary>
        /// Enpoint postfix, ex: https://{api-endpoint}/{postfix}
        /// </summary>
        private const string ENDPOINT_POSTFIX = "accounts";

        #endregion Defines

        #region Public Methods

        /// <summary>
        /// Gets account.
        /// </summary>
        /// <param name="code">Account code.</param>
        /// <returns>Account insance.</returns>
        public Account Get(string code)
        {
            return ExecuteRequest<Account>(new[] { ENDPOINT_POSTFIX, code }, Method.GET).Data;
        }

        /// <summary>
        /// Gets account's billing info.
        /// </summary>
        /// <param name="code">Account code.</param>
        /// <returns>Billing info instance</returns>
        public BillingInfo GetBillingInfo(string code)
        {
            return ExecuteRequest<BillingInfo>(new[] { ENDPOINT_POSTFIX, code, "billing_info" }, Method.GET).Data;
        }

        /// <summary>
        /// Gets all accounts.
        /// </summary>
        /// <returns>Collection of accounts.</returns>
        public AccountCollection GetAll()
        {
            return ExecuteRequest<AccountCollection>(new[] { ENDPOINT_POSTFIX }, Method.GET).Data;
        }

        /// <summary>
        /// Gets account's subscriptions.
        /// </summary>
        /// <param name="code">Account code.</param>
        /// <returns>Subscription instance.</returns>
        public SubscriptionCollection GetSubscriptions(string code)
        {
            return ExecuteRequest<SubscriptionCollection>(new[] { ENDPOINT_POSTFIX, code, "subscriptions" }, Method.GET).Data;
        }

        /// <summary>
        /// Creates account.
        /// </summary>
        /// <param name="body">Account instance.</param>
        /// <returns>Account instance.</returns>
        public Account Create(Account body)
        {
            return ExecuteRequest<Account>(new[] { ENDPOINT_POSTFIX }, Method.POST, body).Data;
        }

        /// <summary>
        /// Updates account.
        /// </summary>
        /// <param name="code">Account code.</param>
        /// <param name="body">Account instance.</param>
        /// <returns>Account instance.</returns>
        public Account Update(string code, Account body)
        {
            return ExecuteRequest<Account>(new[] { ENDPOINT_POSTFIX, code }, Method.PUT, body).Data;
        }

        /// <summary>
        /// Updates billing info.
        /// </summary>
        /// <param name="code">Account code.</param>
        /// <param name="body">BillingInfo instance.</param>
        /// <returns>BillingInfo instance.</returns>
        public BillingInfo UpdateBillingInfo(string code, BillingInfo body)
        {
            return ExecuteRequest<BillingInfo>(new[] { ENDPOINT_POSTFIX, code, "billing_info" }, Method.PUT, body).Data;
        }

        /// <summary>
        /// Closes account.
        /// </summary>
        /// <param name="code">Account code.</param>
        public void CloseAccount(string code)
        {
            ExecuteRequest(new[] { ENDPOINT_POSTFIX, code }, Method.DELETE);
        }

        /// <summary>
        /// Clears billing info.
        /// </summary>
        /// <param name="code">Account code.</param>
        public void ClearBillingInfo(string code)
        {
            ExecuteRequest(new[] { ENDPOINT_POSTFIX, code, "billing_info" }, Method.DELETE);
        }

        #endregion Public Methods

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="client">REST client.</param>
        public AccountManager(RestClient client) : base(client) { }

        #endregion Constructors
    }
}
