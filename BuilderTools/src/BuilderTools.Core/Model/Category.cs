namespace BuilderTools.Core.Model
{
    public class Category
    {
        public Category(Guid categoryId, string name, string description)
        {
            CategoryId = categoryId;
            Name = name;
            Description = description;
        }

        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
