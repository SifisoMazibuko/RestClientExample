﻿using System;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using static System.Console;
using System.Collections.Generic;
using System.Net;
using Flurl.Util;
using ServiceStack;

namespace RestClientExample
{
    public class Program
    {
        static void Main(string[] args)
        {
           var repositories = ProcessRepositories().Result;
            foreach (var repo in repositories)
            {
                WriteLine(repo.Name);
                WriteLine(repo.Description);
                WriteLine(repo.GitHubHomeUrl);
                WriteLine(repo.Homepage);
                WriteLine(repo.Watchers);
                WriteLine(repo.LastPush);
                WriteLine();
            }

        }
        private static async Task<List<Repository>> ProcessRepositories()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
                client.DefaultRequestHeaders.Add(ReqConstant.UserAgent, ReqConstant.UserAgentValue);

                var serializer = new DataContractJsonSerializer(typeof(List<Repository>));

                var streamtask = client.GetStreamAsync(ReqConstant.BaseUrl);
                var repositories = serializer.ReadObject(await streamtask) as List<Repository>;
                return repositories;
            }
        }
    }
}
