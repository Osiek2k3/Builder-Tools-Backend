using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderTools.Core.Model
{
    public class BuilderTool
    {
        public BuilderTool(Guid builderToolId, Guid categoryId, string name, bool permission, decimal pricePerDay, byte[] image)
        {
            BuilderToolId = builderToolId;
            CategoryId = categoryId;
            Name = name;
            Permission = permission;
            PricePerDay = pricePerDay;
            Image = image;
        }

        public Guid BuilderToolId { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public bool Permission { get; set; }
        public decimal PricePerDay { get; set; }
        public Byte[] Image { get; set; }
    }
}
