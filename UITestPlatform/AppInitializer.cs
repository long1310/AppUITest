using System;
using System.IO;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITestPlatform
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android
                    .ApkFile(@"C:\Users\ThLongLy\source\repos\AppUITest\AppUITest\AppUITest.Android\bin\Release\com.companyname.AppUITest.apk").StartApp();
            }

            return ConfigureApp
                .iOS
                .StartApp();
        }
    }
}

