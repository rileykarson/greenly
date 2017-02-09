namespace RecycleApp
{
    using System;
    using Android.App;
    using Android.Graphics;
    using Android.OS;
    using Android.Widget;

    /// <summary>
    /// The screen to display the result of scanning an item.
    /// </summary>
    [Activity(Theme = "@android:style/Theme.Material.Light.NoActionBar")]
    public class ResultActivity : Activity
    {
        /// <summary>
        /// Android method called on creation of the activity.
        /// </summary>
        /// <param name="bundle">The page's previous state.</param>
        protected override void OnCreate(Bundle bundle)
        {
            if (this.Intent.HasExtra("typeBundle"))
            {
                bundle = this.Intent.GetBundleExtra("typeBundle");
            }

            base.OnCreate(bundle);
            var type = bundle.GetString("type");
            if (string.IsNullOrEmpty(type))
            {
                throw new Exception();
            }

            this.SetContentView(Resource.Layout.Result);
            var binLabel = this.FindViewById<TextView>(Resource.Id.binLabel);
            var typeFormatted = type.ToLower();
            binLabel.Text = $"{typeFormatted} bin";
            var rootLayout = this.FindViewById<LinearLayout>(Resource.Id.rootLayout);
            if (type == "Blue")
            {
                rootLayout.SetBackgroundColor(Color.SkyBlue);
            }

            if (type == "Compost")
            {
                rootLayout.SetBackgroundColor(Color.LawnGreen);
            }

            if (type == "Grey")
            {
                rootLayout.SetBackgroundColor(Color.LightGray);
            }

            if (type == "Error")
            {
                rootLayout.SetBackgroundColor(Color.IndianRed);
            }
        }
    }
}