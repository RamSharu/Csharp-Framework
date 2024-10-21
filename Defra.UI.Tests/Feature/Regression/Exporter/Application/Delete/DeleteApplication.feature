@Exporter
Feature: Delete Application

As a Defra customer able to delete the applications in draft status

Scenario: Delete Application as Exporter
	Given that I navigate to the DEFRA application
	Then setup an application via backend
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And application page is displayed
	Then search for a created application
	And select '<filter>' filter from applications page
	And set status value as 'draft'
	When I click on the delete application
	Then The application is deleted successfully
	
	Examples: 
	| logininfo | filter |
	| exporter  | status |
