using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Google.YouTube.Player;

namespace YouTubeAndroidPlayer.Demo
{
    [Activity(Label = "YouTubeAndroidPlayer.Demo", MainLauncher = true, Icon = "@drawable/icon")]
    public class FragmentActivity : YouTubeFailureRecoveryActivity
    {

        protected override IYouTubePlayerProvider GetYouTubePlayerProvider()
        {
            return FragmentManager.FindFragmentById<YouTubePlayerFragment>(Resource.Id.youtube_fragment);
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            YouTubePlayerFragment youTubePlayerFragment = FragmentManager.FindFragmentById<YouTubePlayerFragment>(Resource.Id.youtube_fragment);
            youTubePlayerFragment.Initialize("AIzaSyA5KXnyVL-eHiqGlfgJbbhbC-CFZl3J9xc", this);

        }

        public override void OnInitializationSuccess(IYouTubePlayerProvider provider, IYouTubePlayer player, bool wasRestored)
        {
            if (!wasRestored)
            {
                player.CueVideo("wKJ9KzGQq0w");
            }
        }
    }
}

