using BuilderTools.Core.DTO;

namespace BuilderTools.Core.Model
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Category(Guid categoryId, string name, string description)
        {
            CategoryId = categoryId;
            Name = name;
            Description = description;
        }

        public CategoryDto ToModel()
        {
            return new CategoryDto(CategoryId, Name, Description);
        }
    }
}
