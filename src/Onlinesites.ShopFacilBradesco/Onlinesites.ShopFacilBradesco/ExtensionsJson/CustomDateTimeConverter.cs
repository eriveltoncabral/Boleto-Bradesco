using Newtonsoft.Json.Converters;

namespace Onlinesites.ShopFacilBradesco.ExtensionsJson
{
    public class CustomDateTimeConverter : IsoDateTimeConverter
    {
        public CustomDateTimeConverter()
        {
            base.DateTimeFormat = "yyyy-MM-dd";
        }
    }
}
