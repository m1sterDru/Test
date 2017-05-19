using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Security.Policy;

namespace SeleniumParallelTest
{
  public enum BrowserType
  {
    Chrome,
    Firefox,
    IE
  }
  [TestFixture]
  public class Hooks : Base
  {
    private BrowserType _browserType;
    public Hooks(BrowserType browser)
    {
      _browserType = browser;
    }

    [SetUp]
    public void InitializeTest()
    {
      ChooseDriverInstance(_browserType);
    }

    //private void ChooseDriverInstance(BrowserType browserType)
    //{
    //  if (browserType == BrowserType.Chrome)
    //    Driver = new ChromeDriver();
    //  else if (browserType == BrowserType.Firefox)
    //    Driver = new FirefoxDriver();
    //}


    public void ChooseDriverInstance(BrowserType browserType)
    {
      if (browserType == BrowserType.Chrome)
      {
        DesiredCapabilities cap = DesiredCapabilities.Chrome();
        //Driver = new RemoteWebDriver(new Uri("http://192.168.56.1:4444/wd/hub"), cap);
        //Driver = new RemoteWebDriver(new Uri("http://172.17.0.2:4446/wd/hub"), cap);
        //Driver = new RemoteWebDriver(new Uri("http://172.17.0.2:4446/grid/register"), cap);
        //Driver = new RemoteWebDriver(new Uri("http://localhost:4446/grid/register"), cap);
        //Driver = new RemoteWebDriver(new Uri("http://localhost:4444/grid/register"), cap);
        //Driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), cap);
        //Driver = new RemoteWebDriver(new Uri("http://172.17.0.2:4444/wd/hub"), cap);
        Driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), cap);
      }
      else if (browserType == BrowserType.Firefox)
      {
        DesiredCapabilities cap = DesiredCapabilities.Firefox();
        cap.SetCapability("version", "53");
        cap.SetCapability("platform", "LINUX");
        Driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), cap);
      }
    }

    //[TearDown]

    //public void CleanUp()
    //{
    //  Driver.Quit();
    //}

  }
}
