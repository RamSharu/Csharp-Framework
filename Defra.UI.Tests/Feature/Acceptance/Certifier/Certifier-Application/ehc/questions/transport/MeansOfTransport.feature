Feature: MeansOfTransport

As a Certifier edit MeansOfTransport Panel under Transport Tab and Click save and continue without filling any details

Scenario: Certifier Save Means Of Transport
	Given that I navigate to the DEFRA application
	When setup an application with all tasks via backend '<logininfo>'
	And submit an application via backend
	And create a certificate via backend
	Then sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And on certifier application page is displayed
	And search for a created application
	When I click in to the created application
	When I click on Transport Tab
	When I click edit in Means of Transport Tab and click on save

Examples:
	| logininfo | EHCNumber    |
	| certifier | EHC8361      |
