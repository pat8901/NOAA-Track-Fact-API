namespace NOAA_API.Models
{
    public class Satellite
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? DateCreated { get; set; }
        public string? Description { get; set; }
        public string? Link { get; set; }
    }
}