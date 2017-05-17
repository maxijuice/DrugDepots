namespace Depots.BLL.Interface.DTO
{
    public class DrugUnitDTO
    {
        public string DrugUnitId { get; set; }
        public int PickNumber { get; set; }
        public int? DrugTypeId { get; set; }
        public int? DepotId { get; set; }

    }
}
