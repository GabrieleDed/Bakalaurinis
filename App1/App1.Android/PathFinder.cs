using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using SysIO = System.IO;
using System.Threading.Tasks;

using Java.IO;

using Xamarin.Forms;

using App1.Droid;

[assembly: Dependency(typeof(PathFinder))]

namespace App1.Droid
{
    public class PathFinder : IPathFinder
    {
        public async Task<string> GetDBPath()
        {

            String dbPath = String.Empty;

            if (await PermissonManager.GetPermission(PermissonManager.PermissionsIdentifier.Storage))
            {

                String systemPath = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.RootDirectory.Path).Path;

                String tempFolderPath = SysIO::Path.Combine(systemPath, "MytestDBFolder");
                if (!SysIO::File.Exists(tempFolderPath))
                {
                    new File(tempFolderPath).Mkdirs();
                }

                dbPath = SysIO::Path.Combine(tempFolderPath, "EIPFA.db");

                if (!SysIO::File.Exists(dbPath))
                {
                    Byte[] dbArray;
                    using (var memoryStream = new SysIO::MemoryStream())
                    {
                        var dbAsset = MainActivity.assets.Open("EIPFA.db");
                        dbAsset.CopyTo(memoryStream);
                        dbArray = memoryStream.ToArray();
                    }

                    SysIO.File.WriteAllBytes(dbPath, dbArray);

                }

            }

            return dbPath;
        }
    }
}