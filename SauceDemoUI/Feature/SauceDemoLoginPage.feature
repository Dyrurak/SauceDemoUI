Feature: SauceDemoLoginPage
	Regression test scenarios for login page of Sauce Demo

Background: 
* Chrome Browser is opened
* 'https://www.saucedemo.com' page is opened
Scenario: SauceDemoSuccessfulLoginWithStandartUserAndCorrectPassword	
	* 'standard_user' is entered as username
	* 'secret_sauce' is entered as password
	* Login button is clicked
	* Login operation is performed successfully

Scenario: SauceDemoSuccessfulLoginWithProblemUserAndCorrectPassword	
	* 'problem_user' is entered as username
	* 'secret_sauce' is entered as password
	* Login button is clicked
	* Login operation is performed successfully

Scenario: SauceDemoSuccessfulLoginWithPerformanceGlitchUserAndCorrectPassword	
	* 'performance_glitch_user' is entered as username
	* 'secret_sauce' is entered as password
	* Login button is clicked
	* Login operation is performed successfully

Scenario: SauceDemoFailLoginWithLockedUsernameAndCorrectPassword	
	* 'locked_out_user' is entered as username
	* 'secret_sauce' is entered as password
	* Login button is clicked
	* 'Epic sadface: Sorry, this user has been locked out.' error is seen

Scenario: SauceDemoFailLoginWithCorrectUsernameAndWrongPassword	
	* 'standard_user' is entered as username
	* 'wrong_password' is entered as password
	* Login button is clicked
	* 'Epic sadface: Username and password do not match any user in this service' error is seen

Scenario: SauceDemoFailLoginWithWrongUsernameAndCorrectPassword	
	* 'wrong_user' is entered as username
	* 'secret_sauce' is entered as password
	* Login button is clicked
	* 'Epic sadface: Username and password do not match any user in this service' error is seen

Scenario: SauceDemoFailLoginWithWrongUsernameAndWrongPassword	
	* 'wrong_user' is entered as username
	* 'wrong_password' is entered as password
	* Login button is clicked
	* 'Epic sadface: Username and password do not match any user in this service' error is seen

Scenario: SauceDemoFailLoginWithCorrectUsernameAndEmptyPassword	
	* 'standard_user' is entered as username
	* '' is entered as password
	* Login button is clicked
	* 'Epic sadface: Password is required' error is seen

Scenario: SauceDemoFailLoginWithEmptyUsernameAndCorrectPassword	
	* '' is entered as username
	* 'secret_sauce' is entered as password
	* Login button is clicked
	* 'Epic sadface: Username is required' error is seen

Scenario: SauceDemoFailLoginWithEmptyUsernameAndEmptyPassword	
	* '' is entered as username
	* '' is entered as password
	* Login button is clicked
	* 'Epic sadface: Username is required' error is seen