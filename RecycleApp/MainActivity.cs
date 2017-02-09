namespace RecycleApp
{
    using System;
    using System.IO;
    using Android.App;
    using Android.Content;
    using Android.Graphics;
    using Android.OS;
    using Android.Views;
    using Android.Widget;
    using RecycleCross;

    /// <summary>
    /// First Activity to be launched. Contains a camera view.
    /// </summary>
    [Activity(Label = "Greenly", MainLauncher = true, Icon = "@drawable/icon", Theme = "@android:style/Theme.Material.Light.NoActionBar")]
    public class MainActivity : Activity
    {
        private Button captureButton;
        private TextureView textureView;

        /// <summary>
        /// Default Android method called on creation of the view.
        /// </summary>
        /// <param name="bundle">A bundle of the previous application state if any.</param>
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            this.SetContentView(Resource.Layout.Main);
            this.textureView = this.FindViewById<TextureView>(Resource.Id.cameraViewfinder);
            this.textureView.SurfaceTextureListener = new CameraViewfinderListener();
            this.captureButton = this.FindViewById<Button>(Resource.Id.captureButton);
            this.captureButton.Click += this.CaptureButtonClicked;
        }

        private async void CaptureButtonClicked(object sender, EventArgs e)
        {
            this.captureButton.Click -= this.CaptureButtonClicked;
            var base64String = string.Empty;
            var bitmap = this.textureView.Bitmap;
            using (var stream = new MemoryStream())
            {
                var scaledBitmap = Bitmap.CreateScaledBitmap(bitmap, 200, 200, false);
                await scaledBitmap.CompressAsync(Bitmap.CompressFormat.Png, 0, stream);
                var bytes = stream.ToArray();
                base64String = Convert.ToBase64String(bytes);
            }

            var type = await ObjectClassification.Classify(base64String);
            Intent intent = new Intent(this, typeof(ResultActivity));
            Bundle bundle = new Bundle();
            bundle.PutString("type", type.ToString());
            intent.PutExtra("typeBundle", bundle);
            this.StartActivity(intent);
            this.Finish();
        }
    }
}
