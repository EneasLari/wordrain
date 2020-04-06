using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Web {
    public class WebRequests {

        public static async void SendSerialnumberasParameter(string uri,string serial) {
            var client = new HttpClient();
            var URL = uri+"?serial="+ serial;
            //var url = "http://localhost:3000/api/serialnumber?var=" + serial;
            var result = await client.GetAsync( URL);

            Console.WriteLine(result);
        }
    }
}
