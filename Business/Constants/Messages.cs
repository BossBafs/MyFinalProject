﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    // Sürekli new'lemeyeceğimiz için static yapıyoruz.
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime = "Sistem bakımda.";
        public static string ProductsListed = "Ürünler listelendi.";
        public static string ProductCountOfCategoryError = "Kategoriye 15 den fazla ürün eklenemez.";
        public static string ProductNameAlreadyExists = "Aynı isimde ürün mevcut.";

        public static string CategoryLimitExceded = "Kategori limiti aşıldığı için ürün eklenemiyor.";
    }
}
