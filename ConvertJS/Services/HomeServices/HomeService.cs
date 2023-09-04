using RestSharp;

namespace ConvertJS.Services.HomeServices
{
    public class HomeService
    {
        public async Task<object> Get_rule(string id_tkqc, string accessTokenInfo, string cookie)
        {
           
                try
                {
                    var baseUrl = "https://graph.facebook.com/v14.0";
                    var options = new RestClientOptions(baseUrl)
                    {
                        MaxTimeout = -1,
                        UserAgent = " Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/113.0.0.0 Safari/537.36",
                    };
                    var client = new RestClient(options);
                    var request = new RestRequest("httpshttps://adsmanager-graph.facebook.com/v15.0/act_"
                        + id_tkqc + "/adrules_library?access_token="
                        + accessTokenInfo + "&__cppo=1&__activeScenarioIDs=%5B%5D&__activeScenarios=%5B%5D&__interactionsMetadata=%5B%5D&_reqName=adaccount%2Fadrules_library&_reqSrc=AdsRuleListDataManager&_sessionID=85b63ea04270095&date_format=U&fields=%5B%22account_id%22%2C%22created_time%22%2C%22entity_type%22%2C%22evaluation_spec%22%2C%22execution_spec%22%2C%22id%22%2C%22is_for_account%22%2C%22name%22%2C%22schedule_spec%22%2C%22status%22%2C%22updated_time%22%2C%22created_by%7Bid%2C%20name%7D%22%5D&include_headers=false&limit=250&locale=en_GB&method=get&pretty=0&suppress_http_code=1&xref=f1ed4b64eabbfd8&", Method.Get);
                    request.AddHeader("authority", " adsmanager-graph.facebook.com");
                    request.AddHeader("accept", " */*");
                    request.AddHeader("accept-language", " en-US,en;q=0.9");
                    request.AddHeader("content-type", " application/x-www-form-urlencoded");
                    request.AddHeader("origin", " https://adsmanager.facebook.com");
                    request.AddHeader("referer", " https://adsmanager.facebook.com/");
                    request.AddHeader("sec-ch-ua", " \"Google Chrome\";v=\"113\", \"Chromium\";v=\"113\", \"Not-A.Brand\";v=\"24\"");
                    request.AddHeader("sec-ch-ua-mobile", " ?0");
                    request.AddHeader("sec-ch-ua-platform", " \"Windows\"");
                    request.AddHeader("sec-fetch-dest", " empty");
                    request.AddHeader("sec-fetch-mode", " cors");
                    request.AddHeader("sec-fetch-site", " same-site");
                    request.AddHeader("Cookie", cookie);
                    RestResponse response = await client.ExecuteAsync(request);
                    return response.Content;
                }
                catch (Exception ex)
                {
                    return new { Error = ex };
                }
           
        }
    }
}
