
using cw8;
using cw8.Models;

ProductsRepo repo = new ProductsRepo();
List<Product> products = repo.GetProducts();
foreach (Product product in products) {
    Console.WriteLine($"{product.Id} \t {product.Name} \t {product.Price} \t {product.Type}");
}
Console.WriteLine("Podaj id produktu: ");
int idProduct = Convert.ToInt32(Console.ReadLine());
Product? selectedProduct = repo.GetProductById(idProduct);
if (selectedProduct == null) {
    Console.WriteLine("Produkt nie istnieje");
} else {
    Console.WriteLine($"{selectedProduct.Id} \t {selectedProduct.Name} \t {selectedProduct.Price} \t {selectedProduct.Type}");
}
Console.WriteLine("Podaj nazwę produktu: ");
string name = Console.ReadLine();
Console.WriteLine("Podaj cenę produktu: ");
int price = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Podaj typ produktu: ");
string type = Console.ReadLine();
repo.AddProduct(new Product{
        Name = name,
        Price = price,
        Type = type
});
