namespace ITI_MVC.Models
{
	public class ProductMockData
	{
		public List<Product> Products = new List<Product>
			{
				new Product { Id = 1, Name = "Laptop", Description = "A high performance laptop", Price = 1200.99m, Image = "laptop.jpg" },
				new Product { Id = 2, Name = "Smartphone", Description = "Latest model smartphone", Price = 799.49m, Image = "smartphone.jpg" },
				new Product { Id = 3, Name = "Headphones", Description = "Noise cancelling headphones", Price = 199.99m, Image = "headphones.jpg" },
				new Product { Id = 4, Name = "Monitor", Description = "4K Ultra HD monitor", Price = 349.99m, Image = "monitor.jpg" },
				new Product { Id = 5, Name = "Keyboard", Description = "Mechanical keyboard", Price = 89.99m, Image = "keyboard.jpg" }
			};

		public List<Product> GetAll()
		{
			return Products;
		}
		public Product GetById(int id)
		{
			return Products.FirstOrDefault(p => p.Id == id);
		}

	}
}
