namespace Zerifax.Actions.SetClip
{
    using System.Text.RegularExpressions;
    
    public partial class CPHInline
    {
            public bool Execute()
            {
                string pattern = @"https://clips.twitch.tv/[^\s]+";
		    
                string input = args["rawInput"].ToString();
                RegexOptions options = RegexOptions.Multiline | RegexOptions.IgnoreCase;

                foreach (Match m in Regex.Matches(input, pattern, options))
                {
                    CPH.SetGlobalVar("lastclip", m.Groups[0].Value, false);

                    break;                
                }

                return true;
            }
    }
}