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
using Google.YouTube.Player;

namespace YouTubeAndroidPlayer.Demo
{
    [Activity(Label = "YouTubeFailureRecoveryActivity")]
    public abstract class YouTubeFailureRecoveryActivity : YouTubeBaseActivity, IYouTubePlayerOnInitializedListener
    {
        private static int RECOVERY_DIALOG_REQUEST = 1;
        public void OnInitializationFailure(IYouTubePlayerProvider provider, YouTubeInitializationResult errorReason)
        {
            if (errorReason.IsUserRecoverableError)
            {
                errorReason.GetErrorDialog(this, RECOVERY_DIALOG_REQUEST).Show();
            }
            else
            {
                String errorMessage = String.Format(GetString(Resource.String.error_player), errorReason.ToString());
                Toast.MakeText(this, errorMessage, ToastLength.Long).Show();
            }
        }

        public virtual void OnInitializationSuccess(IYouTubePlayerProvider provider, IYouTubePlayer player, bool wasRestored)
        {

        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (requestCode == RECOVERY_DIALOG_REQUEST)
                GetYouTubePlayerProvider().Initialize("AIzaSyA5KXnyVL-eHiqGlfgJbbhbC-CFZl3J9xc", this);
        }

        protected abstract IYouTubePlayerProvider GetYouTubePlayerProvider();

    }
}