// <copyright file="MainActivity.cs" company="Behr, Michael">
// Copyright Behr, Michael 2018-2020.
// All rights reserved.
// Use of this code is subject to the terms of our license.
// See license.txt file in the project root for full license information.
// </copyright>

namespace CovidASH.Droid
{
    using Android.App;
    using Android.Content.PM;
    using Android.OS;
    using Android.Runtime;

    /// <summary>
    /// Defines the <see cref="MainActivity" />.
    /// </summary>
    [Activity(Label = "CovidASH", Icon = "@mipmap/icon", Theme = "@style/MainTheme.Splash", MainLauncher = true, NoHistory = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        #region Methods

        /// <summary>
        /// The OnRequestPermissionsResult.
        /// </summary>
        /// <param name="requestCode">The requestCode<see cref="int"/>.</param>
        /// <param name="permissions">The permissions<see cref="string[]"/>.</param>
        /// <param name="grantResults">The grantResults<see cref="Android.Content.PM.Permission[]"/>.</param>
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        /// <summary>
        /// The OnCreate.
        /// </summary>
        /// <param name="savedInstanceState">The savedInstanceState<see cref="Bundle"/>.</param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            this.SetTheme(Resource.Style.MainTheme);

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        #endregion Methods
    }
}