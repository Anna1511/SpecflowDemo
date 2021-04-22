using OpenQA.Selenium;
using SpecflowDemo.Framework.Managers.WebDriverConfigs;
using System.Configuration;
using TechTalk.SpecFlow;
using static SpecflowDemo.Framework.Data.ConfigurationData;

namespace SpecflowDemo.Framework.Managers
{
	public class WebDriverManager
	{
		private IWebDriver _webDriver;
		private readonly ScenarioContext _scenarioContext;

		public WebDriverManager(ScenarioContext scenarioContext)
		{
			_scenarioContext = scenarioContext;
		}

		public IWebDriver Init()
		{
			if (_webDriver == null)
			{
				_webDriver = ConfigurationManager.AppSettings[BrowserName] switch
				{
					"Chrome" => new ChromeWebDriverConfig().CreateDriver(),
					"Firefox" => new FirefoxWebDriverConfig().CreateDriver(),
					_ => throw new System.Exception("This type of browser isn't supported")
				};
			}

			return _webDriver;
		}

		public void MaximizeWindow()
		{
			_webDriver.Manage().Window.Maximize();
		}

		public string CurrentUrl => _webDriver.Url;

		public void QuitCurrentDriver()
		{
			_webDriver.Quit();
		}
	}
}