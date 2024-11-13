using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;

var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider())
{
    BaseUrl = "https://localhost:7218"
};

var client = new ApiClient.ApiClient(requestAdapter);

Console.WriteLine($"Getting all items from {requestAdapter.BaseUrl}");
var items = await client.Items.GetAsync();
if(items == null)
    throw new Exception("Failed to get items from API");

foreach (var item in items)
{
    Console.WriteLine($"Name: {item.Name} Price: {item.Price}");
}

Console.WriteLine($"Getting tea item from {requestAdapter.BaseUrl}");
var teaItem = await client.Item.GetAsync(requestConfiguration => requestConfiguration.QueryParameters.Name = "Tea");
if(teaItem == null)
    throw new Exception("Failed to get tea item from API");

Console.WriteLine($"Name: {teaItem.Name} Price: {teaItem.Price}");
