using Newtonsoft.Json;
using System.Web;

namespace CoreX.Web
{
    public static class RestApiHelper<TObject> where TObject : class
    {
        public static TObject QueryStringToObject(string QueryString)
        {
            //string QueryString = "BaseNo=5&Width=100";
            var dict = HttpUtility.ParseQueryString(QueryString);
            string json = JsonConvert.SerializeObject(dict.Cast<string>()
                .ToDictionary(k => k, v => dict[v]));
            return JsonConvert.DeserializeObject<TObject>(json)!;
        }
    }
}
