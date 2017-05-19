namespace Depots.BLL.Interface.DTO
{
    public class DrugUnitDTO
    {
        public string DrugUnitId { get; set; }
        public int PickNumber { get; set; }
        public DrugTypeDTO DrugType { get; set; }
        public DepotDTO Depot { get; set; }

    }
}
