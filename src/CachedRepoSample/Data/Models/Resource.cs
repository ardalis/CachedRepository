namespace CachedRepoSample.Data.Models
{
    public class Resource : BaseEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public ResourceType ResourceType { get; set; }
        public int ResourceTypeId { get; set; }
        public int AuthorId { get; set; }
    }
}