namespace TT.GetGo.Core.Domain
{
    public class BaseEntity : CoreBaseEntity
    {
        /// <summary>
        /// Creator Login Id 
        /// </summary>
        public int CreatedBy { get; set; }

        /// <summary>
        /// Created Date
        /// </summary>
        public DateTime CreatedUTCDate { get; set; }

        /// <summary>
        /// Creator's IP 
        /// </summary>
        public string CreatedIP { get; set; }

        /// <summary>
        /// Update Login Id 
        /// </summary>
        public int UpdatedBy { get; set; }

        /// <summary>
        /// Update Date
        /// </summary>
        public DateTime UpdatedUTCDate { get; set; }

        /// <summary>
        /// Update IP
        /// </summary>
        public string UpdatedIP { get; set; }

        /// <summary>
        /// To control deleted records
        /// </summary>
        public bool Deleted { get; set; } = false;
    }
}
