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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MjltTest
{
    class Program
    {
        static void Main(string[] args)
        {

            var c = new LibMjlt.Mjlt();
            c.UserAgent = "mjlt test suite";
            //string shortUrl = c.Create("http://www.fsdaily.com/EndUser/Using_Solr_With_TYPO3_On_Debian_Wheezy");

            var r = c.GetRandomSites(11);
            Debug.Assert(r.Count == 11);
            foreach (var site in r)
            {
                System.Console.WriteLine(site.Code);
                System.Console.WriteLine(site.Url);
            }


            var top10 = c.GetTopTenSites();
            Debug.Assert(top10.Count == 10);
            foreach (var site in top10)
            {
                System.Console.WriteLine(site.Count);
                System.Console.WriteLine(site.Url);
                System.Console.WriteLine(site.Url_Id);
            }

            var top50 = c.GetTopFiftySites();
            Debug.Assert(top50.Count == 50);
            foreach (var site in top50)
            {
                System.Console.WriteLine(site.Count);
                System.Console.WriteLine(site.Url);
                System.Console.WriteLine(site.Url_Id);
            }

            var top100 = c.GetTopOneHundredSites();
            Debug.Assert(top100.Count == 100);
            foreach (var site in top100)
            {
                System.Console.WriteLine(site.Count);
                System.Console.WriteLine(site.Url);
                System.Console.WriteLine(site.Url_Id);
            }

        }
    }
}
