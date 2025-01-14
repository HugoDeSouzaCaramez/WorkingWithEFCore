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

ListProducts(productIdsToHighlight: new[] { resultUpdate.productId });
