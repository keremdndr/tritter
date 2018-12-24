namespace TP.Core
{
    public static class Keywords
    {
        public const string MaxLenghtMessage = "Maksimum uzunluk aşıldı";
        public const string Required = "Bu alan zorunludur";
        public const string ModelMustBeValid = "Tüm alanlara uygun giriş yapılmalı";
        public const string OpenPageError = "Sayfa açılırken hata oluştu";
        public const string ValueMustBeValid = "Lütfen geçerli bir değer giriniz";

        public const string CreateError = "Kayıt eklenirken bir hata oluştu";
        public const string UpdateError = "Kayıt güncellenirken bir hata oluştu";
        public const string DeleteError = "Kayıt silinirken bir hata oluştu.";
        public const string ReadError = "Kayıt bulunurken bir hata oluştu";
        public const string ListReadError = "Liste bulunurken bir hata oluştu";

        public const string CreateInfo = "Kayıt başarıyla eklendi";
        public const string UpdateInfo = "Kayıt başarıyla güncellendi";
        public const string DeleteInfo = "Kayıt başarıyla silindi";
        public const string ReadInfo = "Kayıt başarıyla bulundu";
        public const string ListReadInfo = "Liste başarıyla bulundu";

        public const string PleaseSelect = "Lütfen seçiniz";

        public const string PredictiveList = "Havuz Liste";
        public const string PreviewList = "Portföy Liste";

        public static string GetCrudMessage(string crudObjectName, CrudType crudType)
        {
            switch (crudType)
            {
                case CrudType.Create:
                    break;

                case CrudType.Update:
                    break;

                case CrudType.Read:
                    break;

                case CrudType.Delete:
                    break;

                default:
                    break;
            }
            return "";
        }
    }
}