using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPortal.Domain.Logging
{
    public class LoggingEvents
    {
        public const int GenerateItems = 1000;
        public const int ListItems = 1001;
        public const int GetItem = 1002;
        public const int InsertItem = 1003;
        public const int UpdateItem = 1004;
        public const int DeleteItem = 1005;

        public const int SendPage = 2000;

        public const int Login = 3000;
        public const int Logout = 3001;
        public const int ChangePassword = 3002;

        public const int GetItemNotFound = 4000;
        public const int UpdateItemNotFound = 4001;

        public const int BuildWebHost = 5000;
        public const int MigrateDatabase = 5001;
        public const int SeedDatabase = 5002;
        public const int RunWebHost = 5003;

        public const int AddService = 6000;
        public const int DevelopmentMode = 6001;
    }
}
