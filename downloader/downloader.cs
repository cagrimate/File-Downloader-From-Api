using System;
using RestSharp;

namespace Tests
{
  public class downloader
  {
    public downloader()
    {
      RestClient restClient = new("https://hangwire.kimola.com/v1");
      RestRequest restRequest = new("clients/{id}/models", Method.Get);
      restRequest.AddUrlSegment("id", 1);
      var queryResult = restClient.Execute(restRequest);

      Console.WriteLine(queryResult);

      //foreach (var item in queryResult)
      //{
      //  RestClient clientDownload = new RestClient("https://hangwire.kimola.com/v1/Models/item.id/");
      //  var request = new RestRequest("records", Method.Get);
      //  var response = clientDownload.DownloadData(request);

      //}
      Console.ReadKey();
    }
  }
}