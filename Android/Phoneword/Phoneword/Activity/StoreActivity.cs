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

namespace Phoneword
{
    [Activity(Label = "Store Activity", MainLauncher = true)]
    public class StoreActivity : Activity
    {
        static readonly List<string> storeName = new List<string>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.WineStores);

            // Create your application here
            Button btnWall = FindViewById<Button>(Resource.Id.btnWall);
            Button btnPP = FindViewById<Button>(Resource.Id.btnPP);
            Button btnSec = FindViewById<Button>(Resource.Id.btnSec);

            btnWall.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(EnoListing));
                storeName.Add("Wall");
                intent.PutStringArrayListExtra("storeName", storeName);
                StartActivity(intent);
            };
            btnPP.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(EnoListing));
                storeName.Add("Secaucas");
                intent.PutStringArrayListExtra("storeName", storeName);
                StartActivity(intent);
            };
            btnSec.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(EnoListing));
                storeName.Add("Point Pleasant");
                intent.PutStringArrayListExtra("storeName", storeName);
                StartActivity(intent);
            };
        }
    }
}