namespace Zerifax.Actions.BRB
{
    using System;
    using System.Linq;

    public partial class CPHInline
    {
        public bool Execute()
        {
            var scene = (string)args["clipScene"];
            var source = (string)args["clipBrowserSource"];
            var videoplayerfile = (string)args["clipFile"];
            string userName = (string)args["targetUser"].ToString();
            var allClips = CPH.GetClipsForUser(userName);
            if (allClips.Count == 0)
            {
                CPH.SendMessage("This streamer doesn't have any clips! :(");
                return false;
            }

            var randomClips = allClips.OrderBy(c => Guid.NewGuid()).Take(5);
		
            string thumbnailUrl = string.Join(",", randomClips.Select(rc => rc.ThumbnailUrl));

            videoplayerfile += "?thumbnail_url=" + thumbnailUrl;

            CPH.ObsSetBrowserSource(scene, source, videoplayerfile);

            return true;
        }
    }
}