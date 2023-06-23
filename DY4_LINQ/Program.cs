// See https://aka.ms/new-console-template for more information
using DY4_LINQ;

Console.WriteLine("Hello, World!");

List<Product> products = Product.Products;
IEnumerable<string> productLowerCaseStrings = products.Select(p => p.ToString().ToLower()); //Fluent Syntax
IEnumerable<string> productLowerCaseStringsQ = from p in products                           //Query Syntax
                                               select p.ToString().ToLower();

foreach (string x in productLowerCaseStrings)
{
    Console.WriteLine(x);
}    

List<char> chars = new() { 'a', 'b',  'c' };
IEnumerable<string> CharsQuery = chars.Select(c => c.ToString().ToUpper());
chars.Remove('b');
foreach (string x in CharsQuery)
{ 
    Console.WriteLine(x); 
}

List<string> LowerCaseNames = productLowerCaseStrings.ToList(); //Forces Enumeration of IEnumerable
string[] LowerCaesNamesArray = productLowerCaseStrings.ToArray();
Dictionary<string, string> LowerCaseDictionary = LowerCaseNames.ToDictionary(np => np.ToLower(), np => np.ToUpper());
string FIrstName = productLowerCaseStrings.First();

 List<Product> ProductNamePriceOnly = products.Select
    (p => new Product()
    { Id = p.Id, Name = p.Name })
    .ToList();

var AnonymousNamePrice = products.Select(p =>
new { Id = p.Id, Name = p.Name })
.ToList();

var AnonymousNamePrice2 = products.Select(p =>
new { p.Id, p.Name })
.ToList();

var orderedProducts = products
    .OrderBy(p => p.Price)
    .ToList();

var orderedProductsDesc = products
    .OrderByDescending(p => p.Price)
    .ToList();

var orderedProductsQ =
    (from p in products
     orderby p.Price
     select p)
    .ToList();

var orderedProductsQDesc =
    (from p in products
     orderby p.Price descending
     select p)
    .ToList();

var orderedProductsPriceandColor = products
    .OrderBy(p => p.Price)
    .ThenBy(p => p.Color)
    .ToList();

var orderedProductsPriceandColorDesc = products
    .OrderBy(p => p.Price)
    .ThenByDescending(p => p.Color)
    .ToList();

var orderedProductsQDescColorDesc =
    (from p in products
     orderby p.Price descending, p.Color
     select p)
    .ToList();

var manufacturers = new[]
    {
    new
    {
        CompanyName = "ThreeStars",
        ProductSeries = new[] {"Universe", "Nebula"}
    },
    new
    {
        CompanyName = "Watermelon",
        ProductSeries = new[] {"uPhone", "uPad"}
    }
};

List<string> ProductSerieses = manufacturers.SelectMany(m => m.ProductSeries)
    .ToList();

List<Product> ProductsFromU = products.Where(p => p.Name.StartsWith('u'))
    .ToList();

List<Product> BlackProducts = products.Where(p => p.Color == "Black")
    .ToList();

List<Product> ExpensiveBlackProducts = products
    .Where(p => p.Color == "Black" && p.Price >= 1000)
    .ToList();

List<Product> ExpernsiveORBlackProducts = products.Where(p => p.Color == "Black" || p.Price >= 1000)
    .ToList();

try
{
    Product Blackuphone = products.Where(p => p.Name == "uPhone X")
        .First();
}
catch(InvalidOperationException e)
{
    Console.WriteLine(e.Message);
}

Product? BlackuphoneOrNull = products.Where(p => p.Name == "uPhone X")
    .FirstOrDefault();

Product? BackUPhoneOrNullShorthand = products.FirstOrDefault(p => p.Name == "uPhone");

Product LastBlackProduct = products.Last(p => p.Name == "uPhone X");
Product? LastBlackProductOrNull = products.LastOrDefault(p => p.Color == "uPhone X");

Product SingleProduct = products.Single(p => p.Name == "uPhone X" && p.Color == "Black");
Product? SingleProductOrNull = products.SingleOrDefault(p => p.Name == "uPhone X" && p.Color == "Black");

List<Product> First2Products = products.OrderBy(p => p.Id).Take(2).ToList();
List<Product> Last2Products = products.OrderBy(p => p.Id).TakeLast(2).ToList();

List<Product> TakeWhileuphone = products.OrderBy(p=>p.Color).TakeWhile(p => p.Name == "uPhone X").ToList();
List<Product> SkipWhileBlack = products.OrderBy(p=>p.Color).SkipWhile(p => p.Name == "uPhone X").ToList();

Console.WriteLine("XYZ" == "XYZ"); //True
Console.WriteLine(1 == 1); //True

Product newProduct = new()
{
    Id = 1,
    Name = "uPhone X",
    Color = "Black",
    Price = 1200.99m,
    Cost = 800.10m
};

Console.WriteLine(products.First() == newProduct); //False


Product product1ref = products.Single(p => p.Id == 1); 
Console.WriteLine(products.First() == product1ref); //True

List<string> DifferentColor = products.Select(p => p.Color).Distinct().ToList();

Console.WriteLine("End of application");
Console.WriteLine("End of application");