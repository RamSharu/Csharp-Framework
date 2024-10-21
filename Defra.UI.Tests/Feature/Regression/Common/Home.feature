@Regression @Common
Feature: Home page

As a defra customer, I am able to see all the mandatory fields on home page

Background:
	Given that I navigate to the DEFRA application

Scenario Outline: Validate Home page fields
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	Then application home page is displayed
	And I can validate mandatory fields on the home page for '<logininfo>'
	And I can validate the filters and texts on the filters '<countryFilterText>' '<DateFilterText>' '<StatusFilterText>'
Examples: 
	| logininfo | countryFilterText | DateFilterText | StatusFilterText |
	| exporter  | Filter by Country | Filter by Date | Filter by Status |
	| certifier | Filter by Country | Filter by Date | Filter by Status |

Scenario Outline: Validate Applications table
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	Then application home page is displayed
	And I can see that applications table is displayed
	And the table headers display correct texts for '<logininfo>' as in '<headerTexts>'
	And the applications are displayed in table rows
	And the show link on click displays certificate data and '<buttonTexts>' related to the application for '<logininfo>'
Examples: 
	| logininfo | headerTexts                                                                           | buttonTexts										   |
	| exporter  | Serial No.,Reference,Exporter,Country,Created,Exported,Status,Show all                | View application,Copy application,Delete application |
	| certifier | Serial No.,Reference,Organisation,Exporter,Country,Submitted,Exported,Status,Show all | Cancel application								   |