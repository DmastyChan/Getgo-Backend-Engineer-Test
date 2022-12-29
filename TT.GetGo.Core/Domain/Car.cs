namespace TT.GetGo.Core.Domain
{
    public class Car : BaseEntity
    {
        public string CarName { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public string NoPlate { get; set; }

        public decimal Rate { get; set; } = 0;

        public CarStatus Status { get; set; } = CarStatus.None;

        public virtual ICollection<Record> Records { get; set; } = new List<Record>();

        public virtual ICollection<Location> LocationHistory { get; set; } = new List<Location>();
    }
}
