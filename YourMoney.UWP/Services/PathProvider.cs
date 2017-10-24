using System;
using System.IO;
using Windows.ApplicationModel;
using YourMoney.Standard.Core.Utils;

namespace YourMoney.UWP.Services
{
    public class PathProvider: IPathProvider
    {
        private const string DbName = "Transactions.db";

        public string GetDbPath()
        {
            return DbName;
        }
    }
}