using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;

namespace SpecflowDemo.Framework.Managers.WebDriverConfigs
{
	public class ChromeWebDriverConfig : WebDriverManagerConfig
	{
		public ChromeWebDriverConfig()
		{
			DriverType = WebDriverType.Chrome;
		}

		public override IWebDriver CreateLocalDriver
		{
			get
			{
				ChromeDriverService driverService;
				var path = Environment.GetEnvironmentVariable("webdriver.chrome.driver", EnvironmentVariableTarget.Machine);
				if (path != null)
					driverService = ChromeDriverService.CreateDefaultService(path);
				else
					driverService = ChromeDriverService.CreateDefaultService();

				driverService.EnableVerboseLogging = true;
				driverService.HideCommandPromptWindow = true;
				var options = GetOptions();

				var driver = new ChromeDriver(driverService, options);
				ProcessID = driverService.ProcessId;
				return driver;
			}
		}

		public ChromeOptions GetOptions()
		{
			var options = new ChromeOptions();
			
			options.AddArgument("disable-infobars");
			options.AddArgument("disable-blink-features=BlockCredentialedSubresources");

			options.AddAdditionalCapability("applicationName", ApplicationName, true);

			return options;
		}

		public override IWebDriver CreateRemoteDriver => new RemoteWebDriver(new Uri(GridUri), GetOptions().ToCapabilities());
	}
}
