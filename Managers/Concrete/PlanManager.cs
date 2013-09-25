namespace RecurlyNET.Managers.Concrete
{
    using RecurlyNET.Entities;
    using RecurlyNET.Managers.Abstract;
    using RestSharp;

    /// <summary>
    /// Recurly plan manager.
    /// </summary>
    public class PlanManager : ManagerBase
    {
        #region Defines

        /// <summary>
        /// Enpoint postfix, ex: https://{api-endpoint}/{postfix}
        /// </summary>
        private const string ENDPOINT_POSTFIX = "plans";

        #endregion Defines

        #region Public Methods

        /// <summary>
        /// Gets all plans.
        /// </summary>
        /// <returns>Collection of plans.</returns>
        public PlanCollection GetAll()
        {
            return ExecuteRequest<PlanCollection>(new[] { ENDPOINT_POSTFIX }, Method.GET).Data;
        }

        /// <summary>
        /// Gets plan.
        /// </summary>
        /// <param name="code">Plan code.</param>
        /// <returns>Plan insance.</returns>
        public Plan Get(string code)
        {
            return ExecuteRequest<Plan>(new[] { ENDPOINT_POSTFIX, code }, Method.GET).Data;
        }

        #endregion Public Methods

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="client">REST client.</param>
        public PlanManager(RestClient client) : base(client) { }

        #endregion Constructors
    }
}
