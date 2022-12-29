namespace TT.GetGo.Core.Domain
{
    public class ReachReturnDTO
    {
        /// <summary>
        /// The status of the record
        /// </summary>
        public ReachReturnStatus Status { get; set; } = ReachReturnStatus.None;

        /// <summary>
        /// Direction
        /// </summary>
        public IList<string> Direction { get; set; } = new List<string>();
    }
}
