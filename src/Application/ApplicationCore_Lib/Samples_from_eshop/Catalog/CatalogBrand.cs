using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.ApplicationCore.Entities;

namespace Microsoft.eShopWeb.ApplicationCore.Features.Catalog
{
    public class CatalogBrand : BaseEntity, IAggregateRoot
    {
        public string Brand { get; private set; }
        public CatalogBrand(string brand)
        {
            Brand = brand;
        }
    }
}
