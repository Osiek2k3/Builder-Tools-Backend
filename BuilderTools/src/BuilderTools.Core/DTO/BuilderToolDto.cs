
using BuilderTools.Core.Model;

namespace BuilderTools.Core.DTO
{
    public class BuilderToolDto
    {
        public Guid BuilderToolId { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Permission { get; set; }
        public decimal PricePerDay { get; set; }
        public byte[] Image { get; set; }

        public BuilderToolDto(Guid builderToolId, Guid categoryId, string name,
            string permission, decimal pricePerDay, byte[] image)
        {
            BuilderToolId = builderToolId;
            CategoryId = categoryId;
            Name = name;
            Permission = permission;
            PricePerDay = pricePerDay;
            Image = image;
        }

        public BuilderTool ToModel()
        {
            return new BuilderTool(BuilderToolId, CategoryId, Name, Permission, PricePerDay, Image);
        }
    }
}
