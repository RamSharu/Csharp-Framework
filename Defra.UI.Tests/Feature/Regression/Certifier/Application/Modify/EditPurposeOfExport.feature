@Certifier

Feature: EditPurposeOfExport
As a Certifier edit the application and change purpose of export

Scenario: Certifier edit purpose of export

	Given setup an application with all tasks via backend '<logininfo>'
	And submit an application via backend
	And create a certificate via backend
	When that I navigate to the DEFRA application
	Then sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And on certifier application page is displayed
	And search for a created application
	When I click in to the created application
	When I change change purpose of export
	Then I verify changed change purpose of export
	
	Examples:
	| logininfo |
	| certifier |