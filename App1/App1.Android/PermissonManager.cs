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
using System.Threading.Tasks;
using Android;
using Android.Content.PM;
using Android.Support.V4.App;
namespace App1.Droid
{
    public class PermissonManager
    {

        public enum PermissionsIdentifier
        {
            Storage // Here you can add more identifiers.
        }

        private static String[] GetPermissionsRequired(PermissionsIdentifier identifier)
        {

            String[] permissions = null;


            if (identifier == PermissionsIdentifier.Storage)

                permissions = PermissionExternalStorage;


            return permissions;

        }

        private static Int32 GetRequestId(PermissionsIdentifier identifier)
        {

            Int32 requestId = -1;


            if (identifier == PermissionsIdentifier.Storage)

                requestId = ExternalStorageRequestId;


            return requestId;

        }


        public static TaskCompletionSource<Boolean> PermissionTCS;


        public static readonly String[] PermissionExternalStorage = new String[] { Manifest.Permission.ReadExternalStorage, Manifest.Permission.WriteExternalStorage };

        public const Int32 ExternalStorageRequestId = 2;



        public static async Task<Boolean> GetPermission(PermissionsIdentifier identifier)
        {

            Boolean isPermitted = false;

            if ((Int32)Build.VERSION.SdkInt < 23)

                isPermitted = true;

            else

                isPermitted = await GetPermissionOnSdk23OrAbove(GetPermissionsRequired(identifier), GetRequestId(identifier));


            return isPermitted;

        }



        private static Task<Boolean> GetPermissionOnSdk23OrAbove(String[] permissions, Int32 requestId)
        {

            PermissionTCS = new TaskCompletionSource<Boolean>();

            if (MainApplication.CurrentContext.CheckSelfPermission(permissions[0]) == (Int32)Permission.Granted)

                PermissionTCS.SetResult(true);

            else

                ActivityCompat.RequestPermissions((Activity)MainApplication.CurrentContext, permissions, requestId);


            return PermissionTCS.Task;

        }


        public static void OnRequestPermissionsResult(Permission[] grantResults)
        {

            PermissionTCS.SetResult(grantResults[0] == Permission.Granted);

        }

    }
}