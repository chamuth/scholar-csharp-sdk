using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace Scholar
{

    [Serializable]
    public class ScholarRequestException : Exception
    {
        public ScholarRequestException() { }
        public ScholarRequestException(string message) : base(message) { }
        public ScholarRequestException(string message, Exception inner) : base(message, inner) { }
        protected ScholarRequestException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    public class Request<T> where T : new()
    {
        private RestClient client;
        private RestRequest request = new RestRequest(Method.GET);

        public T Send()
        {
            var response = client.Execute(request);
            T obj = new T();
            try
            {
                obj = JsonConvert.DeserializeObject<T>(response.Content);
            }
            catch (Exception ex)
            {
                throw new ScholarRequestException(ex.Message);
            }

            return obj;
        }

        public Request(string URL)
        {
            client = new RestClient("http://localhost/Scholar/API/" + URL);
        }
    }
}
