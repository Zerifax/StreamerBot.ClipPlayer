using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using NUnit.Framework;
using Zerifax.ClipHelper.Model;
using Zerifax.ClipHelper.Query;

namespace Zerifax.ClipHelper.Tests
{
    [TestFixture]
    public class Tests
    {
       
        [Test]
        public void CanFetchClipData()
        {
            var graph = new QueryGraph();

            graph.RootEntity = new QueryEntity() {Value = "clip"};
            graph.RootEntity.AddAttribute("slug", ""); // insert the slug for a well known clip here to test
            var broadcaster = graph.RootEntity.AddChild("broadcaster");
            broadcaster.AddChildren("displayName");
            var profile = broadcaster.AddChild("profileImageURL");
            profile.AddAttribute("width", 300);
            
            var thumbnail = graph.RootEntity.AddChild("tiny", "thumbnailURL");
            thumbnail.AddAttribute("width", 86);
            thumbnail.AddAttribute("height", 45);
            
            thumbnail = graph.RootEntity.AddChild("small", "thumbnailURL");
            thumbnail.AddAttribute("width", 260);
            thumbnail.AddAttribute("height", 147);
            
            thumbnail = graph.RootEntity.AddChild("medium", "thumbnailURL");
            thumbnail.AddAttribute("width", 480);
            thumbnail.AddAttribute("height", 272);
            
            graph.RootEntity.AddChildren("id", "durationSeconds", "title");

            var graphString = graph.ToString();

            Console.WriteLine(graphString);
            
            var request = (HttpWebRequest)WebRequest.Create("https://gql.twitch.tv/gql");
            request.Method = WebRequestMethods.Http.Post;
            request.Headers.Add("Client-Id", "kimne78kx3ncx6brgo4mv6wki5h1ko");

            var query = new Query.Query()
            {
                QueryGraph = graphString
            };

            var requestBody = JsonConvert.SerializeObject(query);
            
            Console.WriteLine(requestBody);
            
            using (var writer = new StreamWriter(request.GetRequestStream()))
            {
                writer.Write(requestBody);
            } 

            var response = request.GetResponse();

            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var content = reader.ReadToEnd();
                Console.WriteLine(content);
            }
        }
    }
}