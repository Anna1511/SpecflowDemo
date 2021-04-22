using BoDi;
using OpenQA.Selenium;
using SpecflowDemo.Framework.Managers;
using TechTalk.SpecFlow;
using static SpecflowDemo.Framework.Data.ConfigurationData;

namespace SpecflowDemo.Framework.Hooks
{
	[Binding]
	public sealed class WebDriverContext
	{
		private readonly IObjectContainer _objectContainer;
		private WebDriverManager _webDriverManager;
		private ScenarioContext _scenarioContext;
		private readonly IWebDriver _driver;

		public WebDriverContext(IObjectContainer objectContainer) => _objectContainer = objectContainer;

		[BeforeScenario]
		public void BeforeScenario(ScenarioContext scenarioContext)
		{
			_scenarioContext = scenarioContext;
			_webDriverManager = new WebDriverManager(scenarioContext);
			_scenarioContext[DriverContextName] = _webDriverManager;
			_objectContainer.RegisterInstanceAs(_driver);
		}

		[AfterScenario]
		public void TearDown()
		{
			using IWebDriver driver = _objectContainer.Resolve<IWebDriver>();
			driver.Close();
			driver.Dispose();
		}

		//	[BeforeFeature]
		//	public void Initialize()
		//	{
		//		//_driver = _webDriverManager.Init();
		//		//_driver.Manage().Window.Maximize();
		//		//_driver.Navigate().GoToUrl(ConfigurationManager.AppSettings.Get(BaseUrl));
		//		//_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
		//	}
	}
}
