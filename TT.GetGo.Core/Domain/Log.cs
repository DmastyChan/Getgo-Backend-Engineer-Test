namespace TT.GetGo.Core.Domain
{
    /// <summary>
    /// Represents Log
    /// </summary>
    public class Log : CoreBaseEntity
    {
        private string _shortMessage = "";

        /// <summary>
        /// Get or Sets the short message
        /// </summary>
        public string ShortMessage
        {
            get
            {
                if (this._shortMessage.Length > 1500)
                    return this._shortMessage.Substring(0, 1450) + "...";

                return this._shortMessage;
            }
            set { this._shortMessage = value; }
        }

        /// <summary>
        /// Get or Sets the full exception
        /// </summary>
        public string FullMessage { get; set; }

        /// <summary>
        /// Get or Sets the log level identifier
        /// </summary>
        public LogLevel LogLevelId { get; set; }

        /// <summary>
        /// Get or Sets the IP address
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// Get or Sets the user id
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// Get or Sets the page URL
        /// </summary>
        public string PageUrl { get; set; }

        /// <summary>
        /// Get or Sets the referrer URL
        /// </summary>
        public string ReferrerUrl { get; set; }

        /// <summary>
        /// Get or sets log created date 
        /// </summary>
        public DateTime CreatedUTCDate { get; set; } = new DateTime(1900, 1, 1);
    }
}
