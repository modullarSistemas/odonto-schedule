using PlanejaOdonto.Finance.ApiClient.Resource;
using PlanejaOdonto.Finance.ApiClient.Resource.Income;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlanejaOdonto.Finance.ApiClient.Service
{
    public class IncomeService
    {

        private readonly RestClient _client;



        public IncomeService(string url)
        {
            _client = new RestClient(url);
        }


        public async Task<IncomeResource> AddIncome(AddIncomeResource saveIncomeResource)
        {
            var request = new RestRequest("/Income/AddIncome", Method.Post)
                .AddJsonBody(saveIncomeResource);

            var response = await _client.ExecutePostAsync<IncomeResource>(request);

            return response.Data;
        }

    }
}
