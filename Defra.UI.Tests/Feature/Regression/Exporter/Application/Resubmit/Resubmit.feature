Feature: ResubmitApplication

As a Defra customer able to resubmit the application

Scenario: Resubmit Application as Exporter
	Given that I navigate to the DEFRA application
	When setup an application via backend
	And submit an application via backend
	And resubmit an application via backend
	Then application submitted date is not overwritten
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And application page is displayed
	And search for a created application
	And select '<filter>' filter from applications page
	And set status value as 'submitted'
	And user clicks the view application and verify
	
	Examples: 
	| logininfo |  filter |
	| exporter  |  status |
