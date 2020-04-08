using System;

namespace Core.Entities
{
    public class ProductType : BaseEntity
    {
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } // Ürünün Oluşturulma tarihi
        public DateTime? UpdateAt { get; set; } // Ürünün Değiştirilme tarihi
        public Guid? GcGuid { get; set; } // Ürünün Silinme tarihi silindiiği zaman sadece update çakacağız gcreid değerini user guid diyeceğiz ki listelemede de gcreid değerin boş olanlar

    }
}