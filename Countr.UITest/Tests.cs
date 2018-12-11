﻿using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Countr.UITest
{
    [TestFixture(Platform.Android)]
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
        public void WelcomeTextIsDisplayed()
        {
            AppResult[] results = app.WaitForElement(c => c.Marked("Welcome to Xamarin.Forms!"));
            app.Screenshot("Welcome screen.");

            Assert.IsTrue(results.Any());
        }

        [Test]
        public void AddingACounterAddsItToTheCountersScreen()
        {
            // Arrange
            // Act
            app.Tap(c => c.Id("add_counter_button"));
            app.Screenshot("About to enter text");
            app.EnterText(c => c.Id("new_counter_name"), "My Counter");
            app.Tap(c => c.Text("Done")); 
            // Assert
            app.WaitForElement(c => c.Id("counter_name").Text("My Counter"));
            app.WaitForElement(c => c.Id("counter_count").Text("0"));
        }

        [Test]
        public void IncrementingACounterAddsOneToItsCount()
        {
            // Arrange
            app.Tap(c => c.Id("add_counter_button"));
            app.Screenshot("About to enter text");
            app.EnterText(c => c.Id("new_counter_name"), "My Counter");
            app.Tap(c => c.Text("Done"));
            // Act
            app.Tap(c => c.Id("add_image"));
            // Assert
            app.WaitForElement(c => c.Id("counter_count").Text("1"));
        }
    }
}
