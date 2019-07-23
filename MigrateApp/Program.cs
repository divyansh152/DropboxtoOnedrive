using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dropbox.Api;
using System.Net.Http;
using Newtonsoft.Json;
using System.IO;
using MigrateApp.Models;

namespace MigrateApp
{
    public class Program
    {
        private static List<UserFolderRelation> CorrelationList = new List<UserFolderRelation>();
        public static void Main(string[] args)
        {

            Task t = new Task(GetAsync);
            t.Start();
            Console.WriteLine("Connecting to Dropbox...");
            Console.ReadLine();

        }
        public static async void GetAsync()
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
                    string response = await GetFolderDetails(member.profile.team_member_id);
                    UserFolderRelation userFolderRelation = new UserFolderRelation
                    {
                        MemberID = member.profile.team_member_id,
                        UserName = member.profile.name,
                        EmailID = member.profile.email,
                        UFCorrelation = JsonConvert.DeserializeObject<Models.Entities>(response)
                    };
                    CorrelationList.Add(userFolderRelation);
                }

            }

        }
        private static async Task<string> GetFolderDetails(string memberid)
        {
            string Baseurl = "https://api.dropboxapi.com/2/files/list_folder";
            var connectionurl = new Uri(@Baseurl);
            PathRequest path = new PathRequest { path = "" };

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = connectionurl;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer qdOwzAg1H0YAAAAAABBh5AJKwTCsoYK5shEDoBF1kJtGJv8Q7fXOBK2mYMFbnjZN");
                client.DefaultRequestHeaders.Add("Dropbox-API-Select-User", memberid);
                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(path), Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponseMessage = await client.PostAsync(Baseurl, httpContent);
                httpResponseMessage.EnsureSuccessStatusCode();
                string memberDetail = await httpResponseMessage.Content.ReadAsStringAsync();
                //Models.Entities members = JsonConvert.DeserializeObject<Models.Entities>(memberDetail);
                return memberDetail;
            }
        }
    }

}

