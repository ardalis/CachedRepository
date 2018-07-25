namespace CachedRepoSample.Data.Models
{
    public class Resource : BaseEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public ResourceType Type { get; set; }
    }
}