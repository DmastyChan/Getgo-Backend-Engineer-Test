namespace TT.GetGo.Core.Domain
{
    public class CarInfo
    {
        /// <summary>
        /// Car Details
        /// </summary>
        public Car Car { get; set; } 

        /// <summary>
        /// Latest Geo X 
        /// </summary>
        public int LastGeoX { get; set; } = 0;

        /// <summary>
        /// Latest Geo Y
        /// </summary>
        public int LastGeoY { get; set; } = 0;
    }
}
