namespace CachedRepoSample.Data.Models
{
    public class ResourceType : BaseEntity
    {
        public string Name { get; set; }
        public int SortOrder { get; set; }
    }
}