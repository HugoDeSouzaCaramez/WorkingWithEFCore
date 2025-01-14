using Packt.Shared;

//Northwind db = new();

//WriteLine($"Provider: {db.Database.ProviderName}");

//QueryingCategories();

//FilteredIncludes();

//QueryingProducts();

//QueryingWithLike();

//GetRandomProduct();

var resultUpdate = IncreaseProductPrice(productNameStartsWith: "Bob", amount: 20M);

if (resultUpdate.affected == 1)
{
    WriteLine("Increase price success for ID: {resultUpdate.productId}.");
}

WriteLine("About to delete all products whose name starts with Bob.");
Write("Press Enter to continue or any other key to exit: ");

if (ReadKey(intercept: true).Key == ConsoleKey.Enter)
{
    int deleted = DeleteProducts(productNameStartsWith: "Bob");
    WriteLine($"{deleted} product(s) were deleted.");
}
else
{
    WriteLine("Delete was canceled.");
}

ListProducts(productIdsToHighlight: new[] { resultUpdate.productId });
