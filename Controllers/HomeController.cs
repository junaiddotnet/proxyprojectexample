using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using proxyproject.Models;
using System.IO;
using System.Reflection;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace proxyproject.Controllers
{
    public class jsonFinal
    {
        public int level { get; set; }
        public string selector { get; set; }
        public string fn { get; set; }
        public string value { get; set; }

    }
    public class HomeController : Controller
    {
        delegate void stringProcessor(string str);
        // GET: Home
        public ActionResult Index()
        {

            var client = new WebClient();
            var value = client.DownloadString("https://bbc.co.uk");
            // client.DownloadFile("http://junaidnet.co.uk",)
            //value = HttpUtility.HtmlDecode(value);
            //value = "<b>juadd</b> jdjfasdfaskdj <h2>junaid <h2>";
            // value = "junaud";
            var java = " <script src='https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js'></script> ";
            java  = java + " <script> $(document).ready(function(){ " +
                        " alert(33); " +
                         "$('a').click(function(event){ " +
                         "alert('it works!'); event.preventDefault(); });  }); </script>";
            // value = value.Replace("</html>", " ");

            // value = value+ java;

            // value = value + "</html>";

            var index =  value.IndexOf("<body >");
            value = value.Insert(index + 8, java);
            return View(model:value);
        }
        public ActionResult First ()
        {
            return View();
        }
        public ActionResult JsonPattern ()
        {
            string json1 = null;
            IList<jsonFinal> finalString = null;
            var d = Server.MapPath("..\\json.json");
            using (StreamReader r = new StreamReader(d))
            {
                 json1 = r.ReadToEnd();
                finalString= JsonConvert.DeserializeObject<List<jsonFinal>>(json1);
            }
           //JArray objt = JArray.Parse(json1);
            dynamic objt = JsonConvert.DeserializeObject(json1);

          
            
            return View(finalString);
        }
        public ActionResult modulePattern()
        {
            Product p = new Product("junaid",37);
            Product pp = new Product();

            return View();
        }
        public void printString(string x)
        {
            stringProcessor sproc1, sproc2;
            Product p = new Product();
            sproc2 = new stringProcessor(p.PrintString);
            sproc1 = new stringProcessor(staticMethodCLass.printString);

            sproc2.Invoke("junaid mahmood");
            sproc1("ammar mahmood");

        }
        public ActionResult chart()
        {
            return View();
        }
    }
}