using Ardalis.Specification;
using System;
using System.Linq;

namespace Microsoft.eShopWeb.ApplicationCore.Features.Catalog
{
    public class CatalogItemsSpecification : Specification<CatalogItem>
    {
        public CatalogItemsSpecification(params int[] ids)
        {
            Query.Where(c => ids.Contains(c.Id));
        }
    }
}
