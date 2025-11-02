namespace TestYarikUraMiPishemWeb.Dto
{
    public record UpdateProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Cost { get; set; }
    }
}
