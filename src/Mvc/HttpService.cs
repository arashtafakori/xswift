using XSwift.Domain;
using Newtonsoft.Json;
using System.Text;
using System.IO;

namespace XSwift.Mvc
{
    public class HttpService
    {
        private readonly string _applicationContext = string.Empty;
        private readonly string _version = string.Empty;
        private readonly string _collectionResource = string.Empty;
        private readonly HttpClient _httpClient;
 
        public HttpService(
            HttpClient httpClient,
            string applicationContext = "",
            string version = "",
            string collectionResource = "")
        {
            _httpClient = httpClient;
            _applicationContext = applicationContext;
            _version = version;
            _collectionResource = collectionResource;
        }
        public async Task SendAsync(HttpMethod httpMethod,
            BaseRequest? request = null,
            string applicationContext = "",
            string version = "",
            string collectionResource = "",
            object? collectionItemParameter = null,
            string subCollectionResource = "",
            string actionName = "",
            string queryParametersString = "",
            QueryParameters? queryParameters = null)
        {
            var requestUri = GetRequestUri(
                applicationContext,
                version,
                collectionResource,
                collectionItemParameter,
                subCollectionResource,
                actionName,
                queryParametersString,
                queryParameters);

            var httpRequest = new HttpRequestMessage(
                httpMethod,
                requestUri);

            if (request != null)
            {
                string jsonBody = JsonConvert.SerializeObject(request);
                httpRequest.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            }

            HttpResponseMessage response = await _httpClient.SendAsync(httpRequest);
            response.EnsureSuccessStatusCode();
        }

        public async Task<TResponse> SendAsync<TResponse>(HttpMethod httpMethod,
            BaseRequest? request = null,
            string applicationContext = "",
            string version = "",
            string collectionResource = "",
            object? collectionItemParameter = null,
            string subCollectionResource = "",
            string actionName = "",
            string queryParametersString = "",
            QueryParameters? queryParameters = null)
        {
            var requestUri = GetRequestUri(
                applicationContext,
                version,
                collectionResource,
                collectionItemParameter,
                subCollectionResource,
                actionName,
                queryParametersString,
                queryParameters);

            var httpRequest = new HttpRequestMessage(
                httpMethod,
                requestUri);

            if (request != null)
            {
                string jsonBody = JsonConvert.SerializeObject(request);
                httpRequest.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            }

            HttpResponseMessage response = await _httpClient.SendAsync(httpRequest);
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(content)!;
        }

        /// <summary>
        /// Refer to: https://medium.com/@nadinCodeHat/rest-api-naming-conventions-and-best-practices-1c4e781eb6a5
        /// </summary>
        private string GetRequestUri(
            string applicationContext = "",
            string version = "",
            string collectionResource = "",
            object? collectionItemParameter = null,
            string subCollectionResource = "",
            string actionName = "",
            string queryParametersString = "",
            QueryParameters? queryParameters = null)
        {
            string path = string.Empty;
            //--
            applicationContext = MakesRestUrlSegmentProper(applicationContext);
            applicationContext = string.IsNullOrEmpty(applicationContext) ? _applicationContext : applicationContext;
            if (!string.IsNullOrEmpty(applicationContext))
                path += AddsSlashBeforeUrlSegment(applicationContext);
            //--
            version = MakesRestUrlSegmentProper(version);
            version = string.IsNullOrEmpty(version) ? _version : version;
            if (!string.IsNullOrEmpty(version))
                path += AddsSlashBeforeUrlSegment(version);
            //--
            collectionResource = MakesRestUrlSegmentProper(collectionResource);
            collectionResource = string.IsNullOrEmpty(collectionResource) ? _collectionResource : collectionResource;
            if (!string.IsNullOrEmpty(collectionResource))
            {
                path += AddsSlashBeforeUrlSegment(collectionResource);

                if (string.IsNullOrEmpty(actionName)
                    && collectionItemParameter != null)
                {
                    var collectionParameterValue = collectionItemParameter.ToString();
                    collectionParameterValue = MakesRestUrlSegmentProper(collectionParameterValue!);
                    if (!string.IsNullOrEmpty(collectionParameterValue))
                        path += AddsSlashBeforeUrlSegment(collectionParameterValue);
                }
            }
            //--
            subCollectionResource = MakesRestUrlSegmentProper(subCollectionResource);
            if (!string.IsNullOrEmpty(subCollectionResource))
                path += AddsSlashBeforeUrlSegment(subCollectionResource);
            //--
            actionName = MakesRestUrlSegmentProper(actionName);
            if (!string.IsNullOrEmpty(actionName))
            {
                path += AddsSlashBeforeUrlSegment(actionName);

                if (collectionItemParameter != null)
                {
                    var collectionParameterValue = collectionItemParameter.ToString();
                    collectionParameterValue = MakesRestUrlSegmentProper(collectionParameterValue!);
                    if (!string.IsNullOrEmpty(collectionParameterValue))
                        path += AddsSlashBeforeUrlSegment(collectionParameterValue);
                }
            }

            //------------

            var resultOfQueryParameters = string.Empty;
            if (!string.IsNullOrEmpty(queryParametersString))
            {
                resultOfQueryParameters += queryParametersString;
            }

            if (queryParameters != null)
            {
                resultOfQueryParameters += queryParameters.GetQueryparameters();
            }

            if (!string.IsNullOrEmpty(resultOfQueryParameters) && resultOfQueryParameters.Trim().Substring(0, 1) != "?")
                resultOfQueryParameters = "?" + resultOfQueryParameters;

            path += resultOfQueryParameters;

            //------------

            return path;
        }

        private string MakesRestUrlSegmentProper(string segment)
        {
            segment = segment.Trim();
            if (!string.IsNullOrEmpty(segment) && segment.Substring(segment.Length - 1, 1) == "/")
                segment = segment.Substring(0, segment.Length - 1);

            return segment;
        }
        private string AddsSlashBeforeUrlSegment(string segment)
        {
            if (!string.IsNullOrEmpty(segment) && segment.Trim().Substring(0, 1) != "/")
                segment = "/" + segment;

            return segment;
        }
    }
}
