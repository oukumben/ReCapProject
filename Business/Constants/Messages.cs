﻿namespace Business.Constants
{
    public class Messages
    {
        public static string Success = "Başarılı";
        public static string Error = "Bir sorun ile karşılaşıldı: ";
        public static string CarError = "Araç kiralıkta";
        public static string CustomerorUserDeleteError = "Şirketin kiralanmış bir aracı var ";
        public static string Added = "Eklendi";
        public static string Updated = "Güncellendi";
        public static string Deleted = "Silindi";
        public static string DailyPriceError = "Günlük fiyat 0 dan küçük olamaz";
        public static string DescriptionError = "Açıklama 2 karakterden kısa olamaz";
        public static string RentalSuccess = "Araç kiralandı";
        public static string CarImageLimitError = "Bir aracın en fazla 5 resmi olabilir";
        public static string UserNotExist = "kullanıcı bulunamadı";
        public static string WrongPassword = "şifre hatalı";
        public static string UserExist = "kullanıcı mevcut";
        public static string TokenCreated = "token oluştu";
        public static string AuthorizationDenied = "yetkin yok";
    }
}