using ConvertJS.DTOs;
using ConvertJS.DTOs.ResponseDTO;
using ConvertJS.Infras.Enums;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Net;

namespace ConvertJS.Services.AccountServices
{
    public interface IAccountService
    {
        public Task<List<AdsAccountDTO>> AdAccount(string accessTokenInfo, string cookie);

        //Thằng này chính là thằng Appeal page
        public Task<List<AppealCheckPageDTO>> Account(string accessTokenInfo, string cookie);
        public Task<List<AdsAccountDTO>> Businesses(string accessTokenInfo, string cookie);

        //Thằng này k cần thiết vì nó đã nằm trong api Businesses
        public Task<object> Businesses_user(string accessTokenInfo, string idbm, string cookie);
        public Task<bool> Delete_user_ad(string accessTokenInfo, string id_tkqc, string id_user, string cookie);

    }
    public class AccountService : IAccountService
    {
        private readonly ILogger<AccountService> _logger;
        public AccountService(ILogger<AccountService> logger)
        {
            _logger = logger;
        }

        public async Task<List<AdsAccountDTO>> AdAccount(string accessTokenInfo, string cookie)
        {
            try
            {
                var baseUrl = "https://graph.facebook.com/v14.0";
                var options = new RestClientOptions(baseUrl)
                {
                    MaxTimeout = -1,
                    UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/107.0.0.0 Safari/537.36",
                };
                var client = new RestClient(options);
                var request = new RestRequest("https://graph.facebook.com/v14.0/me/adaccounts?limit=50&fields=users,name,account_status,account_id,owner_business,created_time,next_bill_date,currency,adtrust_dsl,timezone_name,timezone_offset_hours_utc,business_country_code,disable_reason,adspaymentcycle{threshold_amount},balance,is_prepay_account,owner,all_payment_methods{pm_credit_card{display_string,exp_month,exp_year,is_verified},payment_method_direct_debits{address,can_verify,display_string,is_awaiting,is_pending,status},payment_method_paypal{email_address},payment_method_tokens{current_balance,original_balance,time_expire,type}},total_prepay_balance,insights.date_preset(maximum){spend}&access_token=" +
                  accessTokenInfo +//.Access_token +
                  "&summary=1&locale=en_US", Method.Get);
                request.AddHeader("authority", "graph.facebook.com");
                request.AddHeader("accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
                request.AddHeader("accept-language", "en-US,en;q=0.9");
                request.AddHeader("cache-control", "max-age=0");
                request.AddHeader("cookie", cookie);
                request.AddHeader("sec-ch-ua", "\"Google Chrome\";v=\"107\", \"Chromium\";v=\"107\", \"Not=A?Brand\";v=\"24\"");
                request.AddHeader("sec-ch-ua-mobile", "?0");
                request.AddHeader("sec-ch-ua-platform", "\"Windows\"");
                request.AddHeader("sec-fetch-dest", "document");
                request.AddHeader("sec-fetch-mode", "navigate");
                request.AddHeader("sec-fetch-site", "none");
                request.AddHeader("sec-fetch-user", "?1");
                request.AddHeader("upgrade-insecure-requests", "1");
                var body = @"";
                request.AddParameter("text/plain", body, ParameterType.RequestBody);
                RestResponse response = await client.ExecuteAsync(request);

                //Convert to Model View
                var adAccountResponse = JsonConvert.DeserializeObject<AdAccountResponseDTO>(response.Content.ToString());
                List<AdsAccountDTO> AllUserDTOs = new List<AdsAccountDTO>();
                foreach (var userDTO in adAccountResponse.data)
                {
                    var adsUser = new AdsAccountDTO
                    {
                        Status = AccountStatus.Active,//chưa đúng
                        AccountName = userDTO.name,
                        Id = userDTO.account_id,
                        Balance = Convert.ToDouble(userDTO.balance), // chưa đúng
                        Type = "Normal Personnal", // chưa đúng
                        ThreashHold = 0,
                        NumberUser = 0,
                        AmountSpent = 0,
                        Currency = userDTO.currency,
                        Limit = userDTO.adtrust_dsl,
                        IDBM = userDTO.id,
                        Users = new List<UserDTO>()
                    };
                    if (userDTO.adspaymentcycle != null)
                        adsUser.ThreashHold = userDTO.adspaymentcycle.data.Sum(e => e.threshold_amount);

                    if (userDTO.users != null)
                        adsUser.NumberUser = userDTO.users.data.Count();

                    if (userDTO.insights != null)
                        adsUser.AmountSpent = userDTO.insights.data.Sum(e => e.spend);
                    if (userDTO.users != null)
                        adsUser.Users = userDTO.users.data.Select(e => new UserDTO
                        {
                            Name = e.name,
                            UserId = e.id,
                            Role = Role.Admin // chưa đúng
                        }).ToList();
                    AllUserDTOs.Add(adsUser);
                }
                return AllUserDTOs;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new List<AdsAccountDTO>();
            }
        }

        //Thằng này chính là thằng Appeal page
        public async Task<List<AppealCheckPageDTO>> Account(string accessTokenInfo, string cookie)
        {
            try
            {
                var baseUrl = "https://graph.facebook.com/v14.0";
                var options = new RestClientOptions(baseUrl)
                {
                    MaxTimeout = -1,
                    UserAgent = " Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/107.0.0.0 Safari/537.36",
                };
                var client = new RestClient(options);
                var request = new RestRequest("https://graph.facebook.com/v14.0/me/accounts?limit=5000&access_token=" +
                                              accessTokenInfo +
                                              "&summary=1&locale=en_US", Method.Get);
                request.AddHeader("authority", " graph.facebook.com");
                request.AddHeader("accept", " text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
                request.AddHeader("accept-language", " en-US,en;q=0.9");
                request.AddHeader("cache-control", " max-age=0");
                request.AddHeader("cookie", cookie);
                request.AddHeader("sec-ch-ua", " \"Google Chrome\";v=\"107\", \"Chromium\";v=\"107\", \"Not=A?Brand\";v=\"24\"");
                request.AddHeader("sec-ch-ua-mobile", " ?0");
                request.AddHeader("sec-ch-ua-platform", " \"Windows\"");
                request.AddHeader("sec-fetch-dest", " document");
                request.AddHeader("sec-fetch-mode", " navigate");
                request.AddHeader("sec-fetch-site", " none");
                request.AddHeader("sec-fetch-user", " ?1");
                request.AddHeader("upgrade-insecure-requests", " 1");
                var body = @"";
                request.AddParameter("text/plain", body, ParameterType.RequestBody);
                RestResponse response = await client.ExecuteAsync(request);

                //Convert here
                var result = new List<AppealCheckPageDTO>();
                return result;
            }
            catch (Exception ex)
            {
                return new List<AppealCheckPageDTO>();
            }

        }
        public async Task<List<AdsAccountDTO>> Businesses(string accessTokenInfo, string cookie)
        {

            try
            {
                var baseUrl = "https://graph.facebook.com/v14.0";
                var options = new RestClientOptions(baseUrl)
                {
                    MaxTimeout = -1,
                    UserAgent = " Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/109.0.0.0 Safari/537.36",
                };
                var client = new RestClient(options);
                var request = new RestRequest("https://graph.facebook.com/v14.0/me/businesses?fields=owned_pixels,name,id,verification_status,business_users,allow_page_management_in_www,sharing_eligibility_status,created_time,permitted_roles,client_ad_accounts.summary(1).limit(5000),owned_ad_accounts.summary(1).limit(5000)&limit=50&access_token=" +
                  accessTokenInfo +
                  "&locale=en_US", Method.Get);
                request.AddHeader("authority", " graph.facebook.com");
                request.AddHeader("accept", " text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
                request.AddHeader("accept-language", " en-US,en;q=0.9");
                request.AddHeader("cache-control", " max-age=0");
                request.AddHeader("sec-ch-ua", " \"Not_A Brand\";v=\"99\", \"Google Chrome\";v=\"109\", \"Chromium\";v=\"109\"");
                request.AddHeader("sec-ch-ua-mobile", " ?0");
                request.AddHeader("sec-ch-ua-platform", " \"Windows\"");
                request.AddHeader("sec-fetch-dest", " document");
                request.AddHeader("sec-fetch-mode", " navigate");
                request.AddHeader("sec-fetch-site", " none");
                request.AddHeader("sec-fetch-user", " ?1");
                request.AddHeader("upgrade-insecure-requests", " 1");
                request.AddHeader("Cookie", cookie);
                RestResponse response = await client.ExecuteAsync(request);

                //Convert to View Model 
                //Tham Khảo chưa đúng!
                //var BMResponse = JsonConvert.DeserializeObject<BusinessResponseDTO>(response.ToString());

                //var GetAllBusiness = new List<BusinessDTO>();

                //foreach (var data in BMResponse.data)
                //{
                //    var account = new BusinessDTO
                //    {
                //        Status = data.sharing_eligibility_status == "enabled" ? BMStatus.Live : BMStatus.Die,
                //        Name = data.name,
                //        Type = BMType.BM1,
                //        Role = GetRoles(data.permitted_roles),
                //        Limit = BMLimit.BM350,
                //        Verified = data.verification_status == "not_verified" ? "VERIFIED" : "NOT VERIFIED",
                //        Created = Convert.ToDateTime(data.created_time),
                //        IDBM = data.id,
                //        NumberAdmin = 0,
                //        NumberAccount = 0,
                //        HiddenAdmin = 0,
                //        NumberPixel = 0,
                //        Quantity = "Good"
                //    };

                //    if (data.business_users != null)
                //    {
                //        account.NumberAdmin = data.business_users.data.Count();
                //        account.Admins = data.business_users.data.Select(e => new UserDTO
                //        {
                //            UserId = e.id,
                //            Name = e.name,
                //            Role = e.role == "ADMIN" ? Role.Admin : Role.Employee
                //        }).ToList();
                //        account.HiddenAdmin = account.NumberAdmin;
                //    }

                //    if (data.client_ad_accounts != null)
                //    {
                //        account.NumberAccount = data.client_ad_accounts.data.Count();
                //        account.Accounts = data.client_ad_accounts.data.Select(e => new UserDTO
                //        {
                //            UserId = e.id,
                //            Name = e.id,
                //            Role = Role.Client
                //        }).ToList();
                //    }

                //    if (data.owned_ad_accounts != null)
                //    {
                //        account.NumberAccount += data.client_ad_accounts.data.Count();
                //        account.Accounts.AddRange(data.client_ad_accounts.data.Select(e => new UserDTO
                //        {
                //            UserId = e.id,
                //            Name = e.id,
                //            Role = Role.Owned
                //        }).ToList()
                //        );
                //    }
                //    GetAllBusiness.Add(account);
                //}
                var result = new List<AdsAccountDTO>();
                return result;
            }
            catch (Exception ex)
            {
                return new List<AdsAccountDTO>();
            }

        }

        public async Task<object> Businesses_user(string accessTokenInfo, string idbm, string cookie)
        {

            try
            {
                var baseUrl = "https://graph.facebook.com/v14.0";
                var options = new RestClientOptions(baseUrl)
                {
                    MaxTimeout = -1,
                    UserAgent = " Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/107.0.0.0 Safari/537.36",
                };
                var client = new RestClient(options);
                var request = new RestRequest("https://graph.facebook.com/v14.0/" +
                idbm +
                "/business_users?access_token=" +
                accessTokenInfo +
                "&fields=email,+first_name,+last_name,+id,+pending_email,+role&limit=300&locale=en_US", Method.Get);
                request.AddHeader("authority", " graph.facebook.com");
                request.AddHeader("accept", " text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
                request.AddHeader("accept-language", " en-US,en;q=0.9");
                request.AddHeader("cache-control", " max-age=0");
                request.AddHeader("sec-ch-ua", " \"Google Chrome\";v=\"107\", \"Chromium\";v=\"107\", \"Not=A?Brand\";v=\"24\"");
                request.AddHeader("sec-ch-ua-mobile", " ?0");
                request.AddHeader("sec-ch-ua-platform", " \"Windows\"");
                request.AddHeader("sec-fetch-dest", " document");
                request.AddHeader("sec-fetch-mode", " navigate");
                request.AddHeader("sec-fetch-site", " none");
                request.AddHeader("sec-fetch-user", " ?1");
                request.AddHeader("upgrade-insecure-requests", " 1");
                request.AddHeader("Cookie", cookie);
                RestResponse response = await client.ExecuteAsync(request);
                return response.Content;
            }
            catch (Exception ex)
            {
                return new { Error = ex };
            }

        }

        public async Task<bool> Delete_user_ad(string accessTokenInfo, string id_tkqc, string id_user, string cookie)
        {

            try
            {
                var baseUrl = "https://graph.facebook.com/v14.0";
                var options = new RestClientOptions(baseUrl)
                {
                    MaxTimeout = -1,
                    UserAgent = " Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/107.0.0.0 Safari/537.36",
                };
                var client = new RestClient(options);
                var request = new RestRequest("https://graph.facebook.com/v14.0/act_" +
                id_tkqc +
                "/users/" +
                id_user +
                "?method=DELETE&access_token=" +
                accessTokenInfo +
                "&locale=en_US", Method.Get);
                request.AddHeader("authority", " graph.facebook.com");
                request.AddHeader("accept", " text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
                request.AddHeader("accept-language", " en-US,en;q=0.9");
                request.AddHeader("cache-control", " max-age=0");
                request.AddHeader("sec-ch-ua", " \"Google Chrome\";v=\"107\", \"Chromium\";v=\"107\", \"Not=A?Brand\";v=\"24\"");
                request.AddHeader("sec-ch-ua-mobile", " ?0");
                request.AddHeader("sec-ch-ua-platform", " \"macOS\"");
                request.AddHeader("sec-fetch-dest", " document");
                request.AddHeader("sec-fetch-mode", " navigate");
                request.AddHeader("sec-fetch-site", " none");
                request.AddHeader("sec-fetch-user", " ?1");
                request.AddHeader("upgrade-insecure-requests", " 1");
                request.AddHeader("Cookie", cookie);
                var body = @"";
                request.AddParameter("text/plain", body, ParameterType.RequestBody);
                RestResponse response = await client.ExecuteAsync(request);

                //return response.Content;
                //Cần lọc xem thằng nào xóa thành công thằng nào không
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
