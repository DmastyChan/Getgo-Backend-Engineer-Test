namespace TT.GetGo.Services.Helper
{
    /// <summary>
    /// Represents a web helper interface
    /// Common functionally which applied for web page / URL 
    /// </summary>
    public partial interface IWebHelper
    {
        /// <summary>
        /// Get URL referrer
        /// </summary>
        /// <returns>URL referrer</returns>
        string GetUrlReferrer();

        /// <summary>
        /// Get context IP address
        /// </summary>
        /// <returns>URL referrer</returns>
        string GetCurrentIpAddress();

        /// <summary>
        /// Gets this page name
        /// </summary>
        /// <param name="includeQueryString">Value indicating whether to include query strings</param>
        /// <param name="useSsl">Value indicating whether to get SSL protected page</param>
        /// <returns>Page name</returns>
        string GetThisPageUrl(bool includeQueryString, bool? useSsl = null);

        /// <summary>
        /// Gets a value indicating whether current connection is secured
        /// </summary>
        /// <returns>true - secured, false - not secured</returns>
        bool IsCurrentConnectionSecured();

        /// <summary>
        /// Gets host location
        /// </summary>
        /// <param name="useSsl">Use SSL</param>
        /// <returns>Host location</returns>
        string GetHost(bool useSsl);

        /// <summary>
        /// Gets location
        /// </summary>
        /// <param name="useSsl">Use SSL</param>
        /// <returns>location</returns>
        string GetLocation(bool? useSsl = null);
    }
}