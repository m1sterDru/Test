using System;
using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumParallelTest
{
  [TestFixture]
  [Parallelizable]
  public class FirefoxTesting : Hooks
  {
    public FirefoxTesting() : base(BrowserType.Firefox)
    {
    }
    [Test]
    public void FireFoxGoogleTest()
    {
      Driver.Manage().Window.Maximize();
      Driver.Navigate().GoToUrl("https://www.google.com.ua/");
      Driver.FindElement(By.Name("q")).SendKeys("Selenium");
      Driver.FindElement(By.Name("btnG")).Click();
      Assert.That(Driver.PageSource.Contains("Selenium"), Is.EqualTo(true), 
                                       "The text selenium does not exist");
    }
  }

  [TestFixture]
  [Parallelizable]
  public class ChromeTesting : Hooks
  {
    public ChromeTesting() : base(BrowserType.Chrome)
    {
    }

    [Test]
    public void ChromeGoogleTest()
    {
      Driver.Manage().Window.Maximize();
      Driver.Navigate().GoToUrl("https://www.google.com.ua/");
      Driver.FindElement(By.Name("q")).SendKeys("ExecuteAutomation");
      Driver.FindElement(By.Name("btnG")).Click();
      Assert.That(Driver.PageSource.Contains("ExecuteAutomation"), Is.EqualTo(true),
                                       "The text selenium does not exist");
    }
  }
}
