namespace Agri_EnergyConnect.Models
{
    public class ForumPost
    {
        public int Id { get; set; }
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public DateTime PostedAt { get; set; }
        public string Content { get; set; }
    }
}