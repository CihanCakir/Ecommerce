// using System;
// using System.Collections;

namespace Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public ProductType ProductType { get; set; }
        public int ProductTypeId { get; set; }
        public ProductBrand ProductBrand { get; set; }
        public int ProductBrandId { get; set; }



        //Few Features : Kampanya Modülü, Hediye Çeki modülü, İstek Listesi Modülü,Favori Liste Modülü, indirim Modülü?, Size Modülü, Fotoğraf Modülü
        // public string Gender { get; set; } // Ürünün Cinsiyeti Belirlemek için
        // public AppUser AppUser { get; set; } // ürünü Kim Yükledi
        // public int AppUserId { get; set; } //ürünü Kim Yükledi   
        // public string ColorCode { get; set; } // ürünün rengi belirtmek için Code lar kullancağız
        // public virtual ICollection<ProductSize> ProductSize { get; set; }    // Ürünün Sizeleri quantity ile biriilte buraso virtual collection List olacak
        // public virtual ICollection<PhotoProduct>  PhotoProduct { get; set; } // Ürünün Fotoğrafları virtual collection LİST activitide yapıtğımız ishost muhbbetini yapcağızishost olanı en önde göndereceğiz 
        // public virtual ICollection<WishList> Wishlist { get; set; } // Kullanıcılar ürüne istekte bulunabilir
        // public virtual ICollection<Favorites> Favorites { get; set; } // Kullanıcılar ürünlere Favorilerine ekleyebilir bulunabilir
        // public ProductCampaign Campaign { get; set; }  // ürüne Tanımlanmış Promosyon Codu
        // public int? CampaignId { get; set; }  // ürüne Tanımlanmış Promosyon Codu
        // public bool? GiftVoucher { get; set; } // Hediye çeki geçerlimi
        // public DateTime CreatedAt { get; set; } // Ürünün Oluşturulma tarihi
        // public DateTime? UpdateAt { get; set; } // Ürünün Değiştirilme tarihi
        // public Guid? GcGuid { get; set; } // Ürünün Silinme tarihi silindiiği zaman sadece update çakacağız gcreid değerini user guid diyeceğiz ki listelemede de gcreid değerin boş olanlar

    }
}