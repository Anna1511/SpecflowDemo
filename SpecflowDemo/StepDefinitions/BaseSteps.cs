using OpenQA.Selenium;
using SpecflowDemo.Framework.Managers;
using TechTalk.SpecFlow;
using static SpecflowDemo.Framework.Data.ConfigurationData;

namespace SpecflowDemo.StepDefinitions
{
	[Binding]
	public class BaseSteps : Steps
	{
		protected IWebDriver Driver { get; }
		public WebDriverManager WebDriverManager;

		public BaseSteps(IWebDriver driver)
		{
			Driver = driver;
			WebDriverManager = (WebDriverManager)ScenarioContext[DriverContextName];
		}
		//protected LoginPage LoginPage { get; }

		[Given(@"I navigate to the '(.*)' page")]
		public virtual void NavigateToUrl(string url)
		{
			Driver.Navigate().GoToUrl(url);
		}
	}
}
