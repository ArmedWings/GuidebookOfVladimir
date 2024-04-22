namespace AvraamProject.Models
{
    public class Place
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }
        public string Address { get; set; }
        public string WorkingHours { get; set; }
        public int Popularity { get; set; }
        public float Rating { get; set; }
        public string Url { get; set; }
        public string Site { get; set; }
    }
}