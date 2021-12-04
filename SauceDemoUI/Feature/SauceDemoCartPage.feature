Feature: SauceDemoCartPage
		Regression test scenarios for cart page of Sauce Demo

Background: 
	* Chrome Browser is opened
	* 'https://www.saucedemo.com' page is opened
	* 'standard_user' is entered as username
	* 'secret_sauce' is entered as password
	* Login button is clicked
	* Login operation is performed successfully

Scenario: SauceDemoRemovingAllProductsFromCartSuccessfully
	* All products are added to cart
	* Cart button is clicked
	* Quantity of products is checked in cart
	* All products are removed in cart successfully

Scenario: SauceDemoSuccessfulPurchase
	* All products are added to cart
	* Cart button is clicked
	* Checkout button is clicked
	* 'first name' is written as First Name
	* 'last name' is written as Last Name
	* 'zip postal code' is written as Zip/Postal Code
	* Continue button is clicked
	* Finish button is clicked
	* 'Your order has been dispatched, and will arrive just as fast as the pony can get there!' message is seen
