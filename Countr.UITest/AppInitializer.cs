﻿using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Countr.UITest
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android
                    .EnableLocalScreenshots()
                    .ApkFile ("../../../Countr/Countr.Droid/bin/Release/com.JWeeKyear.Countr-Signed.apk")
                    .StartApp();
            }

            return ConfigureApp.iOS.EnableLocalScreenshots().StartApp();
        }
    }
}