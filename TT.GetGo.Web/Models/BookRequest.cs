namespace TT.GetGo.Web.Models
{
    public class BookRequest
    {
        /// <summary>
        /// Car identity for book
        /// </summary>
        public int CarId { get; set; }

        /// <summary>
        /// For Validation , user geo 
        /// </summary>
        public UserRequest User { get; set; } = new UserRequest();
    }
}
