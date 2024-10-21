﻿using BoDi;
using Defra.UI.Tests.Configuration;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Reflection;

namespace Defra.UI.Tests.Data.Users
{
    public class User
    {
        public string UserName { get; set; }
        public string password { get; set; }
        public string LoginInfo { get; set; }
        public string Environment { get; set; }
        public bool HomePage { get; set; }

    }
    public interface IUserObject
    {
        public User GetUser(string info);
    }
    internal class UserObject : IUserObject
    {
        private IObjectContainer _objectContainer;

        public UserObject(IObjectContainer objectContainer) => _objectContainer = objectContainer;
        private readonly object _lock = new object();
        private User User = null;

        public User GetUser(string info)
        {
            lock (_lock)
            {
                string jsonPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var filePath = Path.Combine(jsonPath, "Data", "Users", "Users.json");

                var builder = new ConfigurationBuilder();
                builder.AddJsonFile(filePath, false, true);
                var settings = builder.Build();
                var usersList = settings.GetSection("Users").Get<List<User>>();
                string environment = ConfigSetup.BaseConfiguration.TestConfiguration.Environment;
                if (environment != null && !environment.ToLower().Contains("uk.trade.defra.gov.uk")) {
                    environment = environment.ToLower().Substring("https://".Length);
                    environment = environment.ToLower().Replace("-uk.trade.azure.defra.cloud", "");
                }else
                {
                    environment = "prd";
                }
                
                var filterList = environment.ToLower().Contains("localhost", StringComparison.CurrentCultureIgnoreCase)
                    ? usersList.FindAll(d => d.LoginInfo.Equals(info) && d.Environment.ToLower().Contains("dev/tst"))
                    : usersList.FindAll(d => d.LoginInfo.Equals(info) && d.Environment.ToLower().Contains(environment));

                Random rng = new Random();
                User = filterList[rng.Next(filterList.Count)];

            }
            return User;
        }
    }
}
