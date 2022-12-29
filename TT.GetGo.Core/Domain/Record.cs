namespace TT.GetGo.Core.Domain
{
    public class Record : BaseEntity
    {
        /// <summary>
        /// Car Identity
        /// </summary>
        public int CarId { get; set; }

        public virtual Car Car { get; set; }

        /// <summary>
        /// Booking Date
        /// </summary>
        public DateTime BookDate { get; set; } = new DateTime(1900, 1, 1);

        /// <summary>
        /// Car Home Lot During Book Geo X
        /// </summary>
        public int GeoX { get; set; } = 0;

        /// <summary>
        /// Car Home Lot During Book Geo Y
        /// </summary>
        public int GeoY { get; set; } = 0;

        /// <summary>
        /// true - already return and car status set as Normal / none, false - booked 
        /// </summary>
        public bool isComplete { get; set; } = false;

        /// <summary>
        /// Temporary No Assign
        /// </summary>
        public decimal Rate { get; set; } = 0;

        /// <summary>
        /// Temporary No Assign
        /// </summary>
        public decimal Hour { get; set; } = 0;

        /// <summary>
        /// Temporary No Assign
        /// </summary>
        public decimal Total { get; set; } = 0;
    }
}
