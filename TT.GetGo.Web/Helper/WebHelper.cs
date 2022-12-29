using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;
using System.Net;
using TT.GetGo.Services.Helper;

namespace TT.GetGo.Web.Helper
{
    public class WebHelper: IWebHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public WebHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        #region Utilities

        /// <summary>
        /// Check whether current HTTP request is available
        /// </summary>
        /// <returns>True if available; otherwise false</returns>
        protected virtual bool IsRequestAvailable()
        {
            if (_httpContextAccessor?.HttpContext == null)
                return false;

            try
            {
                if (_httpContextAccessor.HttpContext.Request == null)
                    return false;
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get URL referrer
        /// </summary>
        /// <returns>URL referrer</returns>
        public string GetUrlReferrer()
        {
            if (!IsRequestAvailable())
                return string.Empty;

            // URL referrer is null in some case (for example, in IE 8)
            return _httpContextAccessor.HttpContext.Request.Headers[HeaderNames.Referer];
        }

        /// <summary>
        /// Get context IP address
        /// </summary>
        /// <returns>URL referrer</returns>
        public string GetCurrentIpAddress()
        {
            if (!IsRequestAvailable())
                return string.Empty;

            if(_httpContextAccessor.HttpContext.Connection?.RemoteIpAddress is not IPAddress remoteIp)
                return "";

            if(remoteIp.Equals(IPAddress.IPv6Loopback))
                return IPAddress.Loopback.ToString();

            return remoteIp.MapToIPv4().ToString();
        }

        /// <summary>
        /// Gets this page name
        /// </summary>
        /// <param name="includeQueryString">Value indicating whether to include query strings</param>
        /// <param name="useSsl">Value indicating whether to get SSL protected page</param>
        /// <returns>Page name</returns>
        public string GetThisPageUrl(bool includeQueryString, bool? useSsl = null)
        {
            if (!IsRequestAvailable())
                return string.Empty;

            //get  location
            var location = GetLocation(useSsl ?? IsCurrentConnectionSecured());

            //add local path to the URL
            var pageUrl = $"{location.TrimEnd('/')}{_httpContextAccessor.HttpContext.Request.Path}";

            //add query string to the URL
            if (includeQueryString)
                pageUrl = $"{pageUrl}{_httpContextAccessor.HttpContext.Request.QueryString}";

            //whether to convert the URL to lower case
            return pageUrl.ToLowerInvariant();
        }

        /// <summary>
        /// Gets a value indicating whether current connection is secured
        /// </summary>
        /// <returns>true - secured, false - not secured</returns>
        public bool IsCurrentConnectionSecured()
        {
            if (!IsRequestAvailable())
                return false;

            return _httpContextAccessor.HttpContext.Request.IsHttps;
        }

        /// <summary>
        /// Gets host location
        /// </summary>
        /// <param name="useSsl">Use SSL</param>
        /// <returns>host location</returns>
        public string GetHost(bool useSsl)
        {
            if (!IsRequestAvailable())
                return string.Empty;

            //try to get host from the request HOST header
            var hostHeader = _httpContextAccessor.HttpContext.Request.Headers[HeaderNames.Host];
            if (StringValues.IsNullOrEmpty(hostHeader))
                return string.Empty;

            //add scheme to the URL
            var host = $"{(useSsl ? Uri.UriSchemeHttps : Uri.UriSchemeHttp)}{Uri.SchemeDelimiter}{hostHeader.FirstOrDefault()}";

            //ensure that host is ended with slash
            host = $"{host.TrimEnd('/')}/";

            return host;
        }


        /// <summary>
        /// Gets location
        /// </summary>
        /// <param name="useSsl">Use SSL</param>
        /// <returns>location</returns>
        public string GetLocation(bool? useSsl = null)
        {
            var location = string.Empty;

            //get host
            var host = GetHost(useSsl ?? IsCurrentConnectionSecured());
            if (!string.IsNullOrEmpty(host))
            {
                //add application path base if exists
                location = IsRequestAvailable() ? $"{host.TrimEnd('/')}{_httpContextAccessor.HttpContext.Request.PathBase}" : host;
            }

            //ensure that URL is ended with slash
            location = $"{location.TrimEnd('/')}/";

            return location;
        }
        

        #endregion

        
    }
}
