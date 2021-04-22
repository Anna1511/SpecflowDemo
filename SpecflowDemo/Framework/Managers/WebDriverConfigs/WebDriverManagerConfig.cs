using OpenQA.Selenium;
using System;

namespace SpecflowDemo.Framework.Managers.WebDriverConfigs
{
	public abstract class WebDriverManagerConfig
	{
		public int ProcessID { get; set; } = 0;

		public WebDriverType DriverType { get; set; }

		public int Height { get; set; } = -1;

		public int Width { get; set; } = -1;

		public TimeSpan WaitTimeout { get; set; } = TimeSpan.FromSeconds(45);
		public TimeSpan SearchTimeout { get; set; } = TimeSpan.FromSeconds(30);
		public TimeSpan PageLoadTimeout { get; set; } = TimeSpan.FromSeconds(90);

		public TimeSpan PollingInterval { get; set; } = TimeSpan.FromSeconds(0.5);

		public bool IsGrid { get; set; } = false;

		public string GridUri { get; set; } = null;

		public string ApplicationName { get; set; } = "default";

		public IWebDriver CreateDriver()
		{
			IWebDriver driver = IsGrid
				? CreateRemoteDriver : CreateLocalDriver;

			if (Width == -1 && Height == -1)
			{
				driver.Manage().Window.Maximize();
			}
			else if (Width > 0 && Height > 0)
			{
				driver.Manage().Window.Size = new System.Drawing.Size(Width, Height);
				driver.Manage().Window.Position = new System.Drawing.Point(0, 0);
			}

			driver.Manage().Timeouts().ImplicitWait = SearchTimeout;
			driver.Manage().Timeouts().PageLoad = PageLoadTimeout;

			return driver;
		}

		public virtual IWebDriver CreateRemoteDriver { get; }

		public virtual IWebDriver CreateLocalDriver { get; }

		public override string ToString() => Width == -1 && Height == -1 ? $"{DriverType}" : $"{DriverType} {Width}x{Height}";
	}
}
