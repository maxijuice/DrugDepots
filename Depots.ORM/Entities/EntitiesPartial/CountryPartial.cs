using Depots.ORM.EntityInterfaces;

namespace Depots.ORM.Entities
{
    public partial class Country : IUnique
    {
        public dynamic EntityID => CountryId;
    }
}
