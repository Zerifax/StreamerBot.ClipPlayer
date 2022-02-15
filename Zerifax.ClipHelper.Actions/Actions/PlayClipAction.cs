namespace Zerifax.Actions.PlayClip
{
    using System.Linq;
    using Zerifax.ClipHelper;
    using System.Text.RegularExpressions;
    
    public partial class CPHInline
    {
        private Helper _helper;
        
        public Helper Helper
        {
            get
            {
                if (_helper == null)
                {
                    _helper = new Helper() {ClientId = CPH.GetGlobalVar<string>("TwitchApiClient", true)};
                }

                return _helper;
            }
        }

        public bool Execute()
        {
            var scene = CPH.GetGlobalVar<string>("ClipScene", true);
            var source = CPH.GetGlobalVar<string>("ClipBrowserSource", true);
            var webSocket = CPH.GetGlobalVar<string>("ClipWebsocket", true);
            var videoPlayerFile = CPH.GetGlobalVar<string>("ClipFile", true);
		
            var clip = CPH.GetGlobalVar<string>("lastclip", false);

            var slugRegex = new Regex(".*/(?<slug>[^/]+)(?:/?)$");

            var slugResult = slugRegex.Match(clip);

            if (!slugResult.Success)
            {
                return true;
            }
		
            var clipData = Helper.GetClipData(slugResult.Groups["slug"].Value);

            if (clipData == null)
            {
                return true;
            }

            var clipPreview =
                new[] {clipData.Tiny, clipData.Small, clipData.Medium}.FirstOrDefault(
                    c => !string.IsNullOrWhiteSpace(c));

            if (string.IsNullOrWhiteSpace(clipPreview))
            {
                return true;
            }
		
            CPH.SetArgument("clipBroadcaster", clipData.Broadcaster?.DisplayName);
            CPH.SetArgument("clipTitle", clipData.Title);
            CPH.SetArgument("clipDuration", clipData.DurationSeconds);
            CPH.SetArgument("clipThumbnailUrl", clipPreview);
		
            videoPlayerFile += "?user=" + clipData.Broadcaster?.DisplayName;
            videoPlayerFile += "&image=" + clipData.Broadcaster?.ProfileImageURL;
            videoPlayerFile += "&thumbnail_url=" + clipPreview;
            int delay = 700 + (int) clipData.DurationSeconds * 1000;
            videoPlayerFile += "&time=" + (delay*1000);
            videoPlayerFile += "&ws=" + webSocket;

            CPH.ObsSetBrowserSource(scene, source, videoPlayerFile);

            return true;
        }
    }
}