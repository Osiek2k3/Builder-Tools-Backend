using BuilderTools.Core.Model;

namespace BuilderTools.Core.DTO
{
    public class CategoryDto
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public CategoryDto() { }
        public CategoryDto(Guid categoryId, string name, string description)
        {
            CategoryId = categoryId;
            Name = name;
            Description = description;
        }
        public Category ToModel()
        {
            return new Category(CategoryId, Name, Description);
        }
    }
}
