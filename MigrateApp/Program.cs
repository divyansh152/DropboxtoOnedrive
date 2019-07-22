using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dropbox.Api;
using System.Net.Http;
using Newtonsoft.Json;
using System.IO;

namespace MigrateApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Task t = new Task(GetAsync);
            t.Start();
            Console.WriteLine("Connecting to Dropbox...");
            Console.ReadLine();

        }
        static async void GetAsync()
        {
           
            string Baseurl = "https://api.dropboxapi.com/2/team/members/list";
            var connectionurl = new Uri(@Baseurl);
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = connectionurl;
             
                HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, connectionurl);
                req.Headers.Add("Authorization", "Bearer qdOwzAg1H0YAAAAAABBh5AJKwTCsoYK5shEDoBF1kJtGJv8Q7fXOBK2mYMFbnjZN");
                HttpResponseMessage httpResponseMessage = await client.SendAsync(req);
                httpResponseMessage.EnsureSuccessStatusCode();
                HttpContent httpContent = httpResponseMessage.Content;
                string responseString = await httpContent.ReadAsStringAsync();

                Models.MembersCollection members = JsonConvert.DeserializeObject<Models.MembersCollection>(responseString);
                foreach (var member in members.members)
                {
                    member.profile.team_member_id
                }

            }
        }
    }
}
