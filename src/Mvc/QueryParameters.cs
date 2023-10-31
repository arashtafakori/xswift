using System.Text;

namespace XSwift.Mvc
{
    public class QueryParameters
    {
        private Dictionary<string, string> queryParams = new Dictionary<string, string>();

        public QueryParameters AddParameter(string name, object value)
        {
            if(value != null)
            {
                if (queryParams.ContainsKey(name))
                {
                    // If the parameter with the same name already exists, update its value.
                    queryParams[name] = value.ToString()!;
                }
                else
                {
                    queryParams.Add(name, value.ToString()!);
                }
            }

            return this;
        }

        public string GetQueryparameters()
        {
            StringBuilder queryString = new StringBuilder();
            foreach (var param in queryParams)
            {
                queryString.Append(Uri.EscapeDataString(param.Key));
                queryString.Append("=");
                queryString.Append(Uri.EscapeDataString(param.Value));
                queryString.Append("&");
            }

            // Remove the trailing "&" if there are parameters
            if (queryString.Length > 0)
            {
                queryString.Length--; // Remove the last character (which is an extra '&')
            }

            return  queryString.ToString();
        }
    }
}
