namespace CQRS_and_MediatR.Domain
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;  //  public string? Name { get; set; } Cela indique que la variable Name peut contenir une valeur null.
        public string Description { get; set; } = default!; // Ceci supprime l'avertissement de nullabilité
        public decimal Price { get; set; } 

        private Product()
        {

        }
        public Product(string name, string description, decimal price)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Price = price;
        }
    }
}
