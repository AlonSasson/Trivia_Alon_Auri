using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Trivia_Client
{
    class Deserializer
    {
        public static T DeserialiseResponse<T>(byte[] response)
        {
            String jsonStr = new ASCIIEncoding().GetString(response, 0, response.Length);
            
            return JsonConvert.DeserializeObject<T>(jsonStr);
        }
        
    }
}
