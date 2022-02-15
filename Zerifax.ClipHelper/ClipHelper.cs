using System.IO;
using System.Net;
using Newtonsoft.Json;
using Zerifax.ClipHelper.Query;
using Zerifax.ClipHelper.Model;

namespace Zerifax.ClipHelper
{
    public class Helper
    {
        private readonly QueryGraph _graph;
        private readonly StringQueryAttribute _slugAttribute;
        public string ClientId { get; set; }

        public Helper()
        {
            _graph = new QueryGraph();

            _graph.RootEntity = new QueryEntity() {Value = "clip"};
            _slugAttribute = _graph.RootEntity.AddAttribute("slug", "#invalidSlug");
            
            var broadcaster = _graph.RootEntity.AddChild("broadcaster");
            broadcaster.AddChildren("displayName");
            var profile = broadcaster.AddChild("profileImageURL");
            profile.AddAttribute("width", 300);
            
            var thumbnail = _graph.RootEntity.AddChild("tiny", "thumbnailURL");
            thumbnail.AddAttribute("width", 86);
            thumbnail.AddAttribute("height", 45);
            
            thumbnail = _graph.RootEntity.AddChild("small", "thumbnailURL");
            thumbnail.AddAttribute("width", 260);
            thumbnail.AddAttribute("height", 147);
            
            thumbnail = _graph.RootEntity.AddChild("medium", "thumbnailURL");
            thumbnail.AddAttribute("width", 480);
            thumbnail.AddAttribute("height", 272);
            
            _graph.RootEntity.AddChildren("id", "durationSeconds", "title");
        }

        public Clip GetClipData(string slug)
        {
            _slugAttribute.Value = slug;
            var graphString = _graph.ToString();
            
            var request = (HttpWebRequest)WebRequest.Create("https://gql.twitch.tv/gql");
            request.Method = WebRequestMethods.Http.Post;
            request.Headers.Add("Client-Id", ClientId);

            var query = new Query.Query()
            {
                QueryGraph = graphString
            };

            var requestBody = JsonConvert.SerializeObject(query);

            using (var writer = new StreamWriter(request.GetRequestStream()))
            {
                writer.Write(requestBody);
            } 

            var response = request.GetResponse() as HttpWebResponse;

            if (response?.StatusCode == HttpStatusCode.OK)
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    var content = reader.ReadToEnd();
                    var payload = JsonConvert.DeserializeObject<ClipResponse>(content);
                    return payload?.Data?.Clip;
                }
            }

            return null;
        }
    }
}