namespace Buzz.Hybrid
{
    using System.Text;
    using System.Web;

    using Newtonsoft.Json;

    public static class ObjectExtensions
    {
        public static string UrlTokenEncode(this object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var bytes = Encoding.UTF8.GetBytes(json);
            return HttpServerUtility.UrlTokenEncode(bytes);
        }

        public static T UrlTokenDecode<T>(this string obj)
        {
            if (obj == null)
                return default(T);

            var bytes = HttpServerUtility.UrlTokenDecode(obj);
            if (bytes == null)
                return default(T);

            var json = Encoding.UTF8.GetString(bytes);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}