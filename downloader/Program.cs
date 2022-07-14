using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using RestSharp;
using RestSharp.Extensions;
namespace consoleApp
{
  public class Model
  {
    public string Name { get; set; }
    public long Id { get; set; }
  }
  public class Program
  {
    public static void Main()
    {
      RestClient restClient = new("apiUrl");
      RestRequest restRequest = new("apiUrlDetails", Method.Get);
      restRequest.AddUrlSegment("id", 1);
      restRequest.AddQueryParameter("pagesize", 999999);

      var restResponse = restClient.Execute<Model[]>(restRequest);

      foreach (var item in restResponse.Data)
      {
        string name = Regex.Replace(item.Name, "[^a-zA-Z0-9_.]+", "-", RegexOptions.Compiled); ;
        string target = $"/Users/userName/Desktop/{item.Id}{name}.xlsx";

        RestClient restClientRecords = new RestClient("apiUrl");

        RestRequest restRequestRecords = new($"apiUrlDetails", Method.Post);
        var bytes = restClientRecords.DownloadData(restRequestRecords);
        File.WriteAllBytes(target, bytes);
      }
      Console.ReadKey();
    }
  }
}
