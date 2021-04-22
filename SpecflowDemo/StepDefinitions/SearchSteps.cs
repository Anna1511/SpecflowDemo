using FluentAssertions;
using OpenQA.Selenium;
using SpecflowDemo.Pages;
using TechTalk.SpecFlow;

namespace SpecflowDemo.StepDefinitions
{
	[Binding]
	public class SearchSteps : BaseSteps
	{
		private readonly MainNavigationMenuPage MainNavigationMenu;
		private readonly SearchForm SearchForm;

		public SearchSteps(IWebDriver driver) : base(driver)
		{
			MainNavigationMenu = new MainNavigationMenuPage();
			SearchForm = new SearchForm();
		}

		[Given(@"I click on Search icon in top header menu")]
		public void ClickSearchIconInHeader()
		{
			MainNavigationMenu.ClickSearchButton();
		}

		[When(@"I enter '(.*)' into the 'Search' field on the 'Search' form")]
		public void EnterSearchQuery(string query)
		{
			SearchForm.EnterSearchQuery(query);
		}

		[When(@"I click 'Find' button on the 'Search' form")]
		public void ClickFindButton()
		{
			SearchForm.ClickFindButton();
		}

		[Then(@"Url equals to '(.*)'")]
		public void VerifyUrlEqualsTo(string expectedUrl)
		{
			WebDriverManager.CurrentUrl.Should().BeEquivalentTo(expectedUrl);
		}
	}
}
