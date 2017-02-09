namespace RecycleApp
{
    using System;
    using Android.Graphics;
    using Android.Views;
    using Camera = Android.Hardware.Camera;

    /// <summary>
    /// Listener that populates a TextureView with a Camera viewfinder/preview.
    /// </summary>
    public class CameraViewfinderListener : Java.Lang.Object, TextureView.ISurfaceTextureListener
    {
        private Camera camera;

        /// <summary>
        /// When the SurfaceTexture is available, attach the camera to it and begin a preview.
        /// </summary>
        /// <param name="surface"> The SurfaceTexture to draw on.</param>
        /// <param name="w">Width of the texture.</param>
        /// <param name="h">Height of the texture.</param>
        public void OnSurfaceTextureAvailable(SurfaceTexture surface, int w, int h)
        {
            this.camera = Camera.Open();
            this.camera.SetDisplayOrientation(90);

            try
            {
                this.camera.SetPreviewTexture(surface);
                this.camera.StartPreview();
            }
            catch (Java.IO.IOException ex)
            {
                // TODO: Change failure behaviour.
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// When the surface texture is destroyed, stop the camera and release it.
        /// </summary>
        /// <param name="surface">The SurfaceTexture being destroyed.</param>
        /// <returns>Return true if this is the final event?</returns>
        public bool OnSurfaceTextureDestroyed(SurfaceTexture surface)
        {
            this.camera.StopPreview();
            this.camera.Release();
            return true;
        }

        /// <summary>
        /// Don't need to do anything in this method - it's automatically handled.
        /// </summary>
        /// <param name="surface">The SurfaceTexture that changed size.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        public void OnSurfaceTextureSizeChanged(SurfaceTexture surface, int width, int height)
        {
        }

        /// <summary>
        /// Don't need to do anything in this method - it's automatically handled.
        /// </summary>
        /// <param name="surface">The updated SurfaceTexture</param>
        public void OnSurfaceTextureUpdated(SurfaceTexture surface)
        {
        }
    }
}