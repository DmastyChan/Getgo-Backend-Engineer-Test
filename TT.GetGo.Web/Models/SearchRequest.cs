namespace TT.GetGo.Web.Models
{
    /// <summary>
    /// Search Request Model
    /// </summary>
    public class SearchRequest
    {
        /// <summary>
        ///  the key words will be filter , null will be ignore
        /// </summary>
        public string? SearchKeyWords { get; set; } = null;

        public UserRequest User { get; set; } = new UserRequest();
    }
}
