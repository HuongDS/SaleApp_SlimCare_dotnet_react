namespace SlimcareWeb.Service.Services
{
    public class ProductViewDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string Desciption { get; set; }
        public int CategoryId { get; set; }
        public string Img { get; set; }
    }
}