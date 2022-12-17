namespace GeekShopping.ProductAPI.Data.ValueObjects
{
    //ProductVO é um espelho dos atributos da entidade Product sem as annotations
    public class ProductVO
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string? CategoryName { get; set; }
        public string? ImageURL { get; set; }
    }
}
