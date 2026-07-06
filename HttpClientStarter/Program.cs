

using var client = new HttpClient();

var requestBody = new StringContent("{\r\n  \"id\": 100,\r\n  \"name\": \"Jane Doe\",\r\n  \"username\": \"janedoe\",\r\n  \"email\": \"jane@example.com\",\r\n  \"isActive\": true,\r\n  \"roles\": [\"admin\", \"editor\"],\r\n  \"address\": {\r\n    \"street\": \"123 Main St\",\r\n    \"city\": \"Metropolis\",\r\n    \"zipcode\": \"12345\"\r\n  }\r\n}");

var response = await client.PostAsync("https://jsonplaceholder.typicode.com/posts", requestBody);




Console.WriteLine("Choose an Option: \nA. Get \nB. Post \nC. Put\nD. Delete");

string answer = Console.ReadLine();

//Gets the information from API

if (answer == "A")
{
    response = await client.GetAsync("https://localhost:7116/weatherforecast");
   
//Creates a new resource
}
else if (answer == "B")
{
    response = await client.PostAsync("https://localhost:7116/weatherforecast", requestBody);
 //updates the resource
}
else if (answer == "C")
{
    response = await client.PutAsync("https://localhost:7116/weatherforecast/1", requestBody);

//Deletes the resource  
}
else if (answer == "D")
{
    response = await client.DeleteAsync("https://jsonplaceholder.typicode.com/posts/1");
    Console.WriteLine("Deleted");
}
else
{
    Console.WriteLine("Invalid Input.");
    return;
}

// ✅ Show response details
Console.WriteLine($"Status Code: {(int)response.StatusCode}");
Console.WriteLine($"Status: {response.StatusCode}");
Console.WriteLine($"Is Success: {response.IsSuccessStatusCode}");
Console.WriteLine($"Raw response: {response}");

var body = await response.Content.ReadAsStringAsync();
Console.WriteLine(body);

Console.ReadLine();