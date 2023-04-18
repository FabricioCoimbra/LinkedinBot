namespace LinkedinBot.Models
{
    public class Recruiter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string ProfileLink { get; set; }
        public bool ConectedProfile { get; set; }
        public bool FirstMessageSended { get; set; }
        public bool IsPrivateProfile { get; set; }
    }
}
