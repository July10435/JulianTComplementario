using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TapiaExamen.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(SqlClient))]
namespace TapiaExamen.Droid
{
    class SqlClient : DataBsea
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documetPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documetPath, "ComplementarioT.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}