namespace TT.GetGo.Core.Domain
{
    public class Location:  BaseEntity
    {
        /// <summary>
        /// Car Identity
        /// </summary>
        public int CarId { get; set; } 

        public virtual Car Car { get; set; }

        /// <summary>
        /// Car Geo X 
        /// </summary>
        public int GeoX { get; set; } = 0;

        /// <summary>
        /// Car Geo Y
        /// </summary>
        public int GeoY { get; set; } = 0;
    }
}
