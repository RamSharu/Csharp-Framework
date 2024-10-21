@Exporter
Feature: ViewApplication

As a Defra customer able to view the applications in draft status

Scenario: View Application as Exporter
	Given that I navigate to the DEFRA application
	Then setup an application via backend
	Then sign in with valid credentials with logininfo '<logininfo>'
	Then check the user is '<logininfo>'
	And application page is displayed
	Then search for a created application
	And select '<filter>' filter from applications page
	And set status value as 'draft'
	And user clicks the view application and verify application reference
	
	Examples: 
	| logininfo |  filter |
	| exporter  |  status |
