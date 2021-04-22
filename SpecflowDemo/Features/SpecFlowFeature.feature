Feature: Feature1
	Basic search on the site

	Background: 
	Given I am on the 'Home' page

@High
Scenario: Search on the site through the header
	Given I click on Search icon in top header menu
	When I enter 'Ukraine' into the 'Search' field on the 'Search' form
	And I click 'Find' button on the 'Search' form
	Then Url equals to 'Ukraine'