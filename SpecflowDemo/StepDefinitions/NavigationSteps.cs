using OpenQA.Selenium;
using System;
using System.Configuration;
using TechTalk.SpecFlow;
using static SpecflowDemo.Framework.Data.ConfigurationData;

namespace SpecflowDemo.StepDefinitions
{
	[Binding]
	public class NavigationSteps : BaseSteps
	{
		public NavigationSteps(IWebDriver driver) : base(driver)
		{
		}

		[Given(@"I am on the 'Home' page")]
		public void NavigateToUrl()
		{
			//Driver = WebDriverManager.Init();
			Driver.Manage().Window.Maximize();
			NavigateToUrl(ConfigurationManager.AppSettings.Get(BaseUrl));
			Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
		}
	}
}
