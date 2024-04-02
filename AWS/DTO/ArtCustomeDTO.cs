namespace AWS.DTO
{
    public class ArtCustomeDTO
    {
        public string Description { get; set; }
        public DateTime DeadlineDate { get; set; }
        public bool Status { get; set; }
        public List<GerneArtworkDTO>? Genres { get; set; }

    }
}
