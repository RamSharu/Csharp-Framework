@Regression @Common
Feature: Filter

As a Defra customer able to Filter the application when the respective country, date and status selected 

Scenario: Filter 
	Given that I navigate to the DEFRA application
	Then sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	Then application page is displayed
	Then select '<filter>' filter from applications page
	Then check the below table with '<filter>' works correctly '<filterValue>'

	Examples:
	| logininfo | filter	| filterValue		|
	| exporter  | date	    | last14			|
	| exporter  | status	| cancelled			|