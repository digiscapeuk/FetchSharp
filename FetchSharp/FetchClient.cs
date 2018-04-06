using FetchSharp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace FetchSharp
{
    public class FetchClient
    {
        public const string ApiUrl = "https://api.fetcheveryone.com";

        private string _key;
        private string _secret;

        public FetchClient(string key, string secret)
        {
            _key = key;
            _secret = secret;
        }

        #region Auth Token

        private string GetAccessToken()
        {
            var url = $"{ApiUrl}/token.php";
            using (var client = new WebClient())
            {
                var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(_key + ":" + _secret)); ;
                client.Headers.Add("Authorization", $"Basic {credentials}");
                var json = client.DownloadString(url);
                var model = JsonConvert.DeserializeObject<AuthModel>(json);
                return model.Token;
            }
        }

        #endregion

        #region General API Calls

        public FetchResponse<AppUser> GetUsers()
        {
            return FetchGet<AppUser>("app/users");
        }

        /// <summary>
        /// Allows you to retrieve a basic list of training entries for a given uid, with the option to specify mindate to maxdate.
        /// </summary>
        /// <param name="uid">Id of user to search for</param>
        /// <param name="minDate">If null Fetch defaults to start of current month</param>
        /// <param name="maxDate">If null Fetch defaults to today</param>
        /// <returns></returns>
        public FetchResponse<TrainingEntry> GetTrainingEntries(int uid, DateTime? minDate = null, DateTime? maxDate = null)
        {
            var args = $"&uid={uid}";
            if (minDate.HasValue) { args += $"&mindate={minDate.Value.ToString("yyyy-MM-dd")}"; }
            if (maxDate.HasValue) { args += $"&mindate={maxDate.Value.ToString("yyyy-MM-dd")}"; }
            return FetchGet<TrainingEntry>("training/entries", args);
        }

        /// <summary>
        /// Lists the latest forum threads, with the option to specify a category, a start point, and a number of items
        /// </summary>
        /// <param name="category">Options: all | chat | training | races | shop | clinic | vlm | website | friday | tri</param>
        /// <param name="start"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public FetchResponse<ForumThread> GetForumThreads(string category = "all", int start = 0, int items = 10)
        {
            var args = $"&category={category}&start={start}&item={items}";
            return FetchGet<ForumThread>("forum/threads", args);
        }

        private FetchResponse<T> FetchGet<T>(string request, string args = "")
        {
            var token = GetAccessToken();
            var url = $"{ApiUrl}/api.php?request={request}{args}";

            using (var client = new WebClient())
            {
                client.Headers.Add("Authorization", $"Bearer {token}");
                var json = client.DownloadString(url);
                return JsonConvert.DeserializeObject<FetchResponse<T>>(json);
            }
        }

        #endregion
    }
}
