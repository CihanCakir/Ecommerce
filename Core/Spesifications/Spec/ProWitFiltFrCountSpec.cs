using Core.Entities;

namespace Core.Spesifications.Spec
{

    // PRODUCT_WİTH_FİLTERS_FOR_COUNT_SPECİFİCATİON
    public class ProWitFiltFrCountSpec : BaseSpesifications<Product>
    {
        public ProWitFiltFrCountSpec(ProductSpecParams productParams) : base(x => (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId)
                                    && (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId))
        {
        }
    }
}