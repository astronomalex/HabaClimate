namespace HabaClimate.Data.Models
{
    public class AirConditioner : Good
    {
        public bool IsInverter { get; set; }
        public string EnergyEfficiencyClass { get; set; }
        public int SquareRoom { get; set; }
    }
}