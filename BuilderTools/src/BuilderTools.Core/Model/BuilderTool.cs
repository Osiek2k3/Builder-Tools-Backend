
using BuilderTools.Core.DTO;

namespace BuilderTools.Core.Model
{
    public class BuilderTool
    {
        public Guid BuilderToolId { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Permission { get; set; }
        public decimal PricePerDay { get; set; }
        public byte[] Image { get; set; }

        public BuilderTool(Guid builderToolId, Guid categoryId, string name,
            string permission, decimal pricePerDay, byte[] image)
        {
            BuilderToolId = builderToolId;
            CategoryId = categoryId;
            Name = name;
            Permission = permission;
            PricePerDay = pricePerDay;
            Image = image;
        }

        public BuilderToolDto ToModel()
        {
            return new BuilderToolDto(BuilderToolId, CategoryId, Name, Permission, PricePerDay, Image);
        }
    }
}
