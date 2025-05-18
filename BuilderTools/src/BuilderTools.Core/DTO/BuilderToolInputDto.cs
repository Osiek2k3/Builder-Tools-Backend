
using BuilderTools.Core.Model;

namespace BuilderTools.Core.DTO
{
    public class BuilderToolInputDto
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public bool Permission { get; set; } = false;
        public decimal PricePerDay { get; set; }
        public Byte[] Image { get; set; }

        public BuilderToolInputDto() { }
        public BuilderToolInputDto(Guid categoryId, string name, bool permission, decimal pricePerDay, byte[] image)
        {
            CategoryId = categoryId;
            Name = name;
            Permission = permission;
            PricePerDay = pricePerDay;
            Image = image;
        }

        public BuilderTool ToModel()
        {
            return new BuilderTool(Guid.NewGuid(), CategoryId, Name, Permission, PricePerDay, Image);
        }
    }
}
