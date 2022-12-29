namespace TT.GetGo.Web.Models
{
    public class CarModel
    {
        public int Id { get; set; }

        /// <summary>
        /// Car Name
        /// </summary>
        public string CarName { get; set; }

        /// <summary>
        /// Car Brand
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Car Model
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Car Color
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Car No Plate
        /// </summary>
        public string NoPlate { get; set; }

        /// <summary>
        /// Car Status 
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Car Register in the system
        /// </summary>
        public string CreatedDateDesc { get; set; }

        /// <summary>
        /// Home Lot / Last location X 
        /// </summary>
        public int GeoX { get; set; } = 0;

        /// <summary>
        /// Home Lot / Last location Y 
        /// </summary>
        public int GeoY { get; set; } = 0;
    }
}
