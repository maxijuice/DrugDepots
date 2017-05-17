namespace Depots.BLL.Interface.DTO
{
    public class CountryDTO
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public int? SupplyingDepotId { get; set; }
    }
}
