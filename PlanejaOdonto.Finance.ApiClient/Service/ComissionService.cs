using PlanejaOdonto.Finance.ApiClient.Resource;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlanejaOdonto.Finance.ApiClient.Service
{
    public class ComissionService
    {

        private readonly RestClient _client;



        public ComissionService(string url)
        {
            _client= new RestClient(url);
        }


        public async Task<ComissionResource> AddComission(SaveComissionResource saveComissionResource)
        {
            var request = new RestRequest("/Comission/AddComission",Method.Post)
                .AddJsonBody(saveComissionResource);

            var response = await _client.ExecutePostAsync<ComissionResource>(request);

            return response.Data;
        }

    }
}
