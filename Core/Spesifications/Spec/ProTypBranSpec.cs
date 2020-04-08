using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Spesifications.Spec
{
    // PRODUCT_TYPES_BRAND_SPECIFICATION
    public class ProTypBranSpec : BaseSpesifications<Product>
    {
        // Hepsi için LİSTE
        public ProTypBranSpec()
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
        // TEK TEK OLAN İÇİN
        public ProTypBranSpec(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}