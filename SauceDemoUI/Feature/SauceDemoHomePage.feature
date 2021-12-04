Feature: SauceDemoHomePage
	Regression test scenarios for home page of Sauce Demo

Background: 
	* Chrome Browser is opened
	* 'https://www.saucedemo.com' page is opened
	* 'standard_user' is entered as username
	* 'secret_sauce' is entered as password
	* Login button is clicked
	* Login operation is performed successfully

Scenario: SauceDemoSuccessfulLogoutWithStandartUser	
	* Menu button is clicked
	* Logout button is clicked
	* Logout operation is performed successfully

Scenario: SauceDemoRedirectionToSauceLabsSiteAfterClickingAboutButton
	* Menu button is clicked
	* About button is clicked
	* 'https://saucelabs.com/' url is seen

Scenario: SauceDemoLoadingOfAllProductsSuccessfullyInHomePage
	* All the products are seen in home page

Scenario: SauceDemoLoadingOfAllProductsAfterClickingAllItemsButton
	* Cart button is clicked
	* Menu button is clicked
	* All items button is clicked
	* All the products are seen in home page