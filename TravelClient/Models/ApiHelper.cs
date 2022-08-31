using System.Threading.Tasks;
using RestSharp;

namespace TravelClient.Models
{
  class ApiHelper
  {
    public static async Task<string> GetAll()
    {
      RestClient client = new RestClient("http://localhost:5004/api");
      RestRequest request = new RestRequest($"travels", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> Get(int id)
    {
      RestClient client = new RestClient("http://localhost:5004/api");
      RestRequest request = new RestRequest($"travels/{id}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task Post(string newTravel)
    {
      RestClient client = new RestClient("http://localhost:5004/api");
      RestRequest request = new RestRequest($"travels", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newTravel);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task Put(int id, string newTravel)
    {
      RestClient client = new RestClient("http://localhost:5004/api");
      RestRequest request = new RestRequest($"travels/{id}", Method.PUT);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newTravel);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task Delete(int id)
    {
      RestClient client = new RestClient("http://localhost:5004/api");
      RestRequest request = new RestRequest($"travels/{id}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      var response = await client.ExecuteTaskAsync(request);
    }


  }
}