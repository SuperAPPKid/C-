using System;
using System.Text;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Json {
    class Program {
        struct Data {
            public Value result;
        }
        struct Value {
            public Result[] results;
        }
        struct Result {
            public int _id;
            public string Name;
            public string ParkName;
            public string YearBuilt;
            public string OpenTime;
            public string Image;
            public string Introduction;
        }
    
        static string MyDownload(string url) {
            using (var webClient = new WebClient()) {
                Console.Write("\n下載中");
                webClient.Encoding = Encoding.UTF8;
                string content = webClient.DownloadString(url);
                Console.Write("\n下載完成!!");
                return content;
            }
        }

        static async Task<string> MyDownloadAsync(string url) {
            using (var webClient = new WebClient()) {
                Console.Write("下載中");
                webClient.Encoding = Encoding.UTF8;
                Task<string> task = webClient.DownloadStringTaskAsync(url);
                string content = await task;
                Console.Write("\n下載完成!!");
                return content;
            }
        }

        static Result[] JsonDeserializer1(string jsonStr) {
            Console.Write("\nJSON解析中");
            Thread.Sleep(1000);
            JavaScriptSerializer js = new JavaScriptSerializer();
            Data content = js.Deserialize<Data>(jsonStr);
            Result[] results = content.result.results;
            Console.Write("\n解析完成");
            return results;
        }

        static void WriteToFile(Result[] results) {
            using (TextWriter tw = File.CreateText("TaipeiPark.txt")) {
                foreach (var result in results) {
                    tw.WriteLine($" {result._id} : {result.ParkName} - {result.Name} ({result.OpenTime})");
                    tw.WriteLine();
                    tw.WriteLine($" {result.Introduction}");
                    tw.WriteLine();
                    tw.WriteLine($"----------------------------------------------------------------------");
                }
            }
        }
        

        static void Main(string[] args) {
            var t = new System.Timers.Timer();
            t.Interval = 100;
            t.Elapsed += ((source,arg) => Console.Write("."));
            t.Enabled = true;

            //sync
            //var content = MyDownload("http://data.taipei/opendata/datalist/apiAccess?scope=resourceAquire&rid=bf073841-c734-49bf-a97f-3757a6013812");
            //Console.Write("\nSync");
            //var results = JsonDeserializer1(content);


            //async
            var task = MyDownloadAsync("http://data.taipei/opendata/datalist/apiAccess?scope=resourceAquire&rid=bf073841-c734-49bf-a97f-3757a6013812");
            Console.Write("\nAsync");
            var content = task.Result;
            var results = JsonDeserializer1(content);



            WriteToFile(results);

            t.Enabled = false;
            Process.Start(@"TaipeiPark.txt");
            

            Console.ReadKey();
        }
    }
}
