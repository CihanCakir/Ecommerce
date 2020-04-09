using Core.Entities;

namespace Core.Spesifications.Spec
{

    // PRODUCT_WİTH_FİLTERS_FOR_COUNT_SPECİFİCATİON
    public class ProWitFiltFrCountSpec : BaseSpesifications<Product>
    {
        public ProWitFiltFrCountSpec(ProductSpecParams productParams) : base(x =>
                                     (string.IsNullOrEmpty(productParams.Search) || (x.Name.ToLower().Contains(productParams.Search)))
                                 && (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId)
                                 && (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId))
        {
        }
    }
}