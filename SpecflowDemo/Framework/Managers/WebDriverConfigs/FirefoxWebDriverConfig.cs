using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;

namespace SpecflowDemo.Framework.Managers.WebDriverConfigs
{
	public class FirefoxWebDriverConfig : WebDriverManagerConfig
	{
		public FirefoxWebDriverConfig()
		{
			DriverType = WebDriverType.Firefox;
		}

		public override IWebDriver CreateLocalDriver
		{
			get
			{
				FirefoxDriverService driverService;
				string path = Environment.GetEnvironmentVariable("webdriver.gecko.driver", EnvironmentVariableTarget.Machine);
				if (path != null)
					driverService = FirefoxDriverService.CreateDefaultService(path);
				else
					driverService = FirefoxDriverService.CreateDefaultService();

				driverService.HideCommandPromptWindow = true;

				var ops = new FirefoxOptions();
				ops.SetPreference("security.enterprise_roots.enabled", true);
				ops.SetPreference("browser.link.open_newwindow", 3);

				ops.BrowserExecutableLocation = "C:\\Program Files\\Mozilla Firefox\\firefox.exe";

				var driver = new FirefoxDriver(driverService, ops);
				ProcessID = driverService.ProcessId;
				return driver;
			}
		}

		public override IWebDriver CreateRemoteDriver
		{
			get
			{
				var ops = new FirefoxOptions();
				ops.SetPreference("security.enterprise_roots.enabled", true);
				ops.SetPreference("network.http.response.timeout", 900);
				ops.SetPreference("dom.max_script_run_time", 30);
				ops.SetPreference("browser.link.open_newwindow", 3);

				ops.AcceptInsecureCertificates = true;

				return new RemoteWebDriver(new Uri(GridUri), ops.ToCapabilities());
			}
		}
	}
}