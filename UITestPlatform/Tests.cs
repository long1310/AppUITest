using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITestPlatform
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
        }

        [Test]
        [TestCase("Buy some cat food", "The cats are hungry")]
        [TestCase("Learn F#", "Seems like a functional idea")]
        [TestCase("Learn to play guitar", "Noted")]
        [TestCase("Buy some new candles", "Pine and cranberry for that winter feel")]
        [TestCase("Complete holiday shopping", "Keep it a secret!")]
        public void TestCreateList(string a, string b)
        {
            //app.Repl();
            app.Tap(x => x.Text("Add"));
            app.ClearText("txtTitle");
            app.EnterText("txtTitle", a);
            app.DismissKeyboard();
            app.ClearText("txtDesc");
            app.EnterText("txtDesc", b);
            app.DismissKeyboard();
            app.Tap(x => x.Text("Save"));
            
            app.SwipeRightToLeft();

            app.SwipeLeftToRight();
        }
    }
}

