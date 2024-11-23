namespace MunicipalServicesManagementApp.Models
{
    public class WasteManagement
    {
        public int Id { get; set; }
        public string Area { get; set; }
        public double WasteGenerated { get; set; }
        public DateTime CollectionDate { get; set; }
    }

}
