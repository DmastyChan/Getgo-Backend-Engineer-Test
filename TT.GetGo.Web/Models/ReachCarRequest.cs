namespace TT.GetGo.Web.Models
{
    public class ReachCarRequest
    {
        /// <summary>
        /// Get the direction by car identity
        /// </summary>
        public int CarId { get; set; }

        public UserRequest User { get; set; } = new UserRequest();
    }
}
