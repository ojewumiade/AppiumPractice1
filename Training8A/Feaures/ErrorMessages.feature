Feature: ErrorMessages
	

@mytag
Scenario Outline: InValid Registration for Error Messages
	Given I navigate to the site
	When Click on register link
	And I enter firstname
	And I enter last name
	And I enter incomplete emailadd "cjoh@"
	
	And I enter mobile number
	And I enter password
	And I confirm incomplete password "de4"
	
	And the click on signUp
	Then the Error "<message>" is displayed for "<test>"

	Examples:
	| test                   | message                                          |
	| IncompleteCompleteEmail | Please Enter A Valid Email Address               |
	| ConfirmPassword         | Your Password Must Be At Least 5 Characters Long |  
