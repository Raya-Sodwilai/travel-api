// using System.Threading.Tasks;
// using RestSharp;

// namespace Travel.Models
// {
//   class ApiHelper
//   {
//     public static async Task<string> GetAll()
//     {
//       RestClient client = new RestClient("http://localhost:5000/api");
//       RestRequest request = new RestRequest($"places", Method.GET);
//       var response = await client.ExecuteTaskAsync(request);
//       return response.Content;
//     }

//     public static async Task<string> Get(int id)
//     {
//       RestClient client = new RestClient("http://localhost:5000/api");
//       RestRequest request = new RestRequest($"places/{id}", Method.GET);
//       var response = await client.ExecuteTaskAsync(request);
//       return response.Content;
//     }

//     public static async Task Post(string newPlace)
//     {
//       RestClient client = new RestClient("http://localhost:5000/api");
//       RestRequest request = new RestRequest($"places", Method.POST);
//       request.AddHeader("Content-Type", "application/json");
//       request.AddJsonBody(newPlace);
//       var response = await client.ExecuteTaskAsync(request);
//     }

//     public static async Task Put(int id, string newPlace)
//     {
//       RestClient client = new RestClient("http://localhost:5000/api");
//       RestRequest request = new RestRequest($"places/{id}", Method.PUT);
//       request.AddHeader("Content-Type", "application/json");
//       request.AddJsonBody(newPlace);
//       var response = await client.ExecuteTaskAsync(request);
//     }

//     public static async Task Delete(int id)
//     {
//       RestClient client = new RestClient("http://localhost:5000/api");
//       RestRequest request = new RestRequest($"places/{id}", Method.DELETE);
//       request.AddHeader("Content-Type", "application/json");
//       var response = await client.ExecuteTaskAsync(request);
//     }
//   }
// }