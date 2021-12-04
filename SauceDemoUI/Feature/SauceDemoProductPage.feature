Feature: SauceDemoProductPage
	Regression test scenarios for product page of Sauce Demo

Background: 
	* Chrome Browser is opened
	* 'https://www.saucedemo.com' page is opened
	* 'standard_user' is entered as username
	* 'secret_sauce' is entered as password
	* Login button is clicked
	* Login operation is performed successfully

Scenario: SauceDemoAddingProductToCart
	* First product is clicked
	* Add to cart button is clicked	
	* Remove button is seen