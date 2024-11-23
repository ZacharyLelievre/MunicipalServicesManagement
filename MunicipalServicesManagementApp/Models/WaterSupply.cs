namespace MunicipalServicesManagementApp.Models
{
    public class WaterSupply
    {
        public int Id { get; set; }
        public string Zone { get; set; }
        public double Consumption { get; set; }
        public DateTime LastUpdated { get; set; }
    }

}
