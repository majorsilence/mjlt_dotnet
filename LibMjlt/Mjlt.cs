// Copyright (c) 2013, Majorsilence Solutions Inc.
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without modification,
// are permitted provided that the following conditions are met:
//
//  Redistributions of source code must retain the above copyright notice, this
//  list of conditions and the following disclaimer.
//
//  Redistributions in binary form must reproduce the above copyright notice, this
//  list of conditions and the following disclaimer in the documentation and/or
//  other materials provided with the distribution.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
// DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR
// ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
// (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
// LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON
// ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
// (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
// SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.


using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibMjlt
{
    public class Mjlt
    {

        private string baseUrl = "http://mjlt.biz";

        private string _userAgent = "";
        /// <summary>
        /// Used to append a custom value to the built in user agent.
        /// </summary>
        /// <remarks>
        /// The built in user agent is "libmjlt/1.0 by majorsilence" or something similar.
        /// This property can be used to append to the user agent.  For example it could become
        /// "libmjlt/1.0 by majorsilence SomeBot/3.1 by SomePerson".
        /// </remarks>
        public string UserAgent 
        { 
            get
            {
                return _userAgent; 
            } 
            set
            {
                if (value.StartsWith(" "))
                {
                    _userAgent = value;
                }
                else
                {
                    _userAgent = " " + value;
                }
            }
        }

        /// <summary>
        /// Create a new short url. 
        /// </summary>
        /// <param name="originalUrl"></param>
        /// <returns>A new short url</returns>
        public string Create(string originalUrl)
        {
            string url = baseUrl + "/url/create.php";

            WebClient client = new WebClient();

            client.Headers.Add(HttpRequestHeader.UserAgent, UrlInfo.UserAgent + this.UserAgent);
            NameValueCollection inputValues = new NameValueCollection();
            inputValues.Add("submit", originalUrl);
            byte[] b = client.UploadValues(url, inputValues);

            string value = System.Text.Encoding.UTF8.GetString(b);
            return value;


        }

        /// <summary>
        /// Retreive a list of random sites.
        /// </summary>
        /// <param name="siteCount"></param>
        /// <returns></returns>
        public List<LibMjlt.Poco.RandomSites> GetRandomSites(int siteCount)
        {

            string url = baseUrl + "/v1/random.php?count=" + siteCount;
            WebClient client = new WebClient();
            client.Headers.Add(HttpRequestHeader.UserAgent, UrlInfo.UserAgent + this.UserAgent);

            string value = client.DownloadString(url);
#if Android
			var returnValue = Newtonsoft.Json.JsonConvert.DeserializeObject<List<LibMjlt.Poco.RandomSites>> (value);
			return returnValue;

#else
			var j = new System.Web.Script.Serialization.JavaScriptSerializer();
			var returnValue = j.Deserialize<List<LibMjlt.Poco.RandomSites>>(value);
			return returnValue;
#endif


            
        }



        private List<LibMjlt.Poco.TopSites> GetTopSites(string url)
        {

            WebClient client = new WebClient();

            client.Headers.Add(HttpRequestHeader.UserAgent, UrlInfo.UserAgent + this.UserAgent);
            string value = client.DownloadString(url);

#if Android
			var returnValue = Newtonsoft.Json.JsonConvert.DeserializeObject<List<LibMjlt.Poco.TopSites>> (value);
			return returnValue;

#else
            var j = new System.Web.Script.Serialization.JavaScriptSerializer();
            var returnValue = j.Deserialize<List<LibMjlt.Poco.TopSites>>(value);
			return returnValue;
#endif

            

        }


        /// <summary>
        /// Retrieve a list of the top 50 popular sites.
        /// </summary>
        /// <returns></returns>
        public List<LibMjlt.Poco.TopSites> GetTopFiftySites()
        {

            string url = baseUrl + "/v1/topfifty.php?type=json";

            return GetTopSites(url);

        }

        /// <summary>
        /// Retrieve a list of the top 100 popular sites.
        /// </summary>
        /// <returns></returns>
        public List<LibMjlt.Poco.TopSites> GetTopOneHundredSites()
        {

            string url = baseUrl + "/v1/toponehundred.php?type=json";

            return GetTopSites(url);

        }

        /// <summary>
        /// Retrieve a list of the top 10 popular sites.
        /// </summary>
        /// <returns></returns>
        public List<LibMjlt.Poco.TopSites> GetTopTenSites()
        {

            string url = baseUrl + "/v1/topten.php?type=json";

            return GetTopSites(url);

        } 


    }
}
