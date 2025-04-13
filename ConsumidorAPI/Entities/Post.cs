
namespace ConsumidorAPI.Entities
{
    public class Post
    {
        public string symbol { get; set; }
        public string price { get; set; }
        public long time { get; set; }
        public string dailyChange { get; set; }
        public long ts { get; set; }

    }
}
