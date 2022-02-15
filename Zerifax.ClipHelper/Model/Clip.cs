namespace Zerifax.ClipHelper.Model
{
    public class Clip
    {
        public string Id { get; set; }
        
        public Broadcaster Broadcaster { get; set; }
        
        public string Tiny { get; set; }
        public string Small { get; set; }
        public string Medium { get; set; }
        
        public string Title { get; set; }
        
        public int DurationSeconds { get; set; }
    }
}