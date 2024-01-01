namespace OperatorSamples.Models2;

#pragma warning disable CS8618


    public class ProductItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public override string ToString() => ProductName;

        public static implicit operator ProductItem(Product product) =>
            new()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
            };
    }