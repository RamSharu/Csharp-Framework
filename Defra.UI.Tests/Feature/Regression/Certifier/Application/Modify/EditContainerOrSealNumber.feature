@Certifier
Feature: Edit Container Or Seal Number

As a Certifier edit the application and change container Or seal number

Scenario: Certifier edit container Or seal number

	Given setup an application with all tasks via backend '<logininfo>'
	And submit an application via backend
	And create a certificate via backend
	When that I navigate to the DEFRA application
	Then sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And on certifier application page is displayed
	And search for a created application
	When I click in to the created application
	And I change container or seal number as '<containerNumber>' and '<sealNumber>'
	Then I verify changed container or seal number
	
	Examples:
	| logininfo | containerNumber | sealNumber |
	| certifier | BICZ1000007	  | 012346     |