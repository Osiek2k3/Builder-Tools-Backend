
namespace BuilderTools.Core.Model
{
    public class BuilderTool
    {
        public Guid BuilderToolId { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public bool Permission { get; set; } = false;
        public decimal PricePerDay { get; set; }
        public Byte[] Image { get; set; }

        public BuilderTool(Guid builderToolId, Guid categoryId, string name,
            bool permission, decimal pricePerDay, byte[] image)
        {
            BuilderToolId = builderToolId;
            CategoryId = categoryId;
            Name = name;
            Permission = permission;
            PricePerDay = pricePerDay;
            Image = image;
        }
    }
}
