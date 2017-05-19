namespace Depots.BLL.Interface.DTO
{
    public class DepotDTO
    {
        public int DepotId { get; set; }
        public string DepotName { get; set; }
        public CountryDTO Country { get; set; }
    }
}
