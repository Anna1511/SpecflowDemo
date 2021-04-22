using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SpecflowDemo.Pages
{
	public class SearchForm
	{
		[FindsBy(How = How.XPath, Using = "//div[contains(@class, 'search__panel')]")]
		public IWebElement SearchPanel;

		[FindsBy(How = How.XPath, Using = "//input[contains(@id, 'form_search')]")]
		public IWebElement SearchInput;

		[FindsBy(How = How.XPath, Using = "//button[contains(@class, 'search__submit')]")]
		public IWebElement FindButton;

		public SearchForm EnterSearchQuery(string query)
		{
			SearchInput.SendKeys(query);
			return this;
		}

		public SearchForm ClickFindButton()
		{
			FindButton.Click();
			return this;
		}
	}
}
