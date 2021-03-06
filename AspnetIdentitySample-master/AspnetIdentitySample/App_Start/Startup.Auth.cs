﻿using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace AspnetIdentitySample
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
            // Use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            // created by Sabine Winkler
            app.UseFacebookAuthentication(
                appId: "742587635849118",
                appSecret: "66a555f1e5a8d900535b3285777f3a97");

            // created by Thomas Luger
            //app.UseFacebookAuthentication(
            //   appId: "651246251663929",
            //   appSecret: "53db0b08ad7991801fa7e4c3241993a2");

            // created by Sabine Winkler
            app.UseGoogleAuthentication(
                clientId: "816887489576-o25i68qjhrem827jau95rohsamcarou5.apps.googleusercontent.com",
                clientSecret: "jdva1YN9lDrJd-ZXnD7IhYlz");

            // created by Thomas Luger
            //app.UseGoogleAuthentication(
            //    clientId: "186277083551 - h4n1ue7lttp5ajnm0ai4b33m2l78fe7r.apps.googleusercontent.com",
            //    clientSecret: "mnsy3Zxqt-VhXB3mB2Uq_ItQ");
        }
    }
}