using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SpecflowDemo.Pages
{
	public class MainNavigationMenuPage
	{
		[FindsBy(How = How.XPath, Using = "//button[contains(@class, 'header-search')]")]
		public IWebElement SearchButton;

		public void ClickSearchButton()
		{
			SearchButton.Click();
		}
	}
}
