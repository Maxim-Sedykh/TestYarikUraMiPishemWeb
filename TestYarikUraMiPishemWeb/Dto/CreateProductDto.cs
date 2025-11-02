using System.ComponentModel;

namespace TestYarikUraMiPishemWeb.Dto
{
    public record CreateProductDto
    {
        public string Name { get; set; }

        public double Cost { get; set; }
    }
}
