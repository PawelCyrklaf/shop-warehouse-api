namespace ShopWarehouse.API.Data.Dto.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string Ean13 { get; set; }
    }
}
