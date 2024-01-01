namespace OperatorSamples.Models3;

#pragma warning disable CS8618

    public class ProductItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public override string ToString() => ProductName;
    }