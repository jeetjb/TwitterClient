using System;
using System.Collections.Generic;
using System.Linq;
using TwitterClient;
using TwitterClient.Entities;
using TwitterClient.Services.Interfaces;
using Newtonsoft.Json;

namespace SampleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var twitterClient = new TwitterApiClient("accesstoken", "tokensecret", "consumerkey", "consumersecret", "accountid");
            var campaignService = twitterClient.GetService<ICampaignService>();

            var fundingStuffs = twitterClient.GetService<IFundingService>();
            var funds = fundingStuffs.GetFundingInstrumentsAsync().Result;

            var para = new Parameters("funding_instrument_id", "1");
            para["name"] = "";
            para["start_time"] = "2021-02-02T00:00:00Z";
            para["daily_budget_amount_local_micro"] = 10000000;

            var camp = campaignService.CreateCampaignAsync(para).Result;
        }
    }
}
