using BuilderTools.Core.Model;

namespace BuilderTools.Core.DTO
{
    public class CategoryInputDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public CategoryInputDto() { }
        public CategoryInputDto(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public Category ToModel()
        {
            return new Category(Guid.NewGuid(), Name, Description);
        }
    }
}
