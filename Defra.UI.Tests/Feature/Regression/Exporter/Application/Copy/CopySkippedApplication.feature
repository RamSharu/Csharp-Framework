Feature: CopySkippedApplication

As a Defra customer, I am able to copy the skipped application and check the details original application

Scenario Outline: Copy Skipped application - Commodity summary page shows skipped labelled as 'not entered'
	Given that I navigate to the DEFRA application
	When setup an application with all tasks with skip funtion via backend
	And submit an application with skip funtion via backend
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And application page is displayed
	Then search for a created application
	When I click on the copy application
	And the copy application page is displayed
	And I click on "yes" to copy everything from the application
	And I click on Continue button
	And I enter a new reference on the copy application reference page
	And I click Create copy button
	And I navigate to commodities summary page
	When I expand the commodity record on the commodities summary page
	Then I can see the sections that skipped labelled as 'Not Entered'

	Examples: 
	| logininfo |
	| exporter  |

Scenario Outline: Copy Skipped application - Commodity Identification entry page shows skip check box checked
	Given that I navigate to the DEFRA application
	When setup an application with all tasks with skip funtion via backend
	And submit an application with skip funtion via backend
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And application page is displayed
	Then search for a created application
	When I click on the copy application
	And the copy application page is displayed
	And I click on "yes" to copy everything from the application
	And I click on Continue button
	And I enter a new reference on the copy application reference page
	And I click Create copy button
	And I navigate to commodities summary page
	When I click 'Change' 
	Then I verify skip check box ticked in Identification entry page

	Examples: 
	| logininfo |
	| exporter  |

Scenario Outline: Copy Skipped application - Check your answers page shows 'not entered' for skipped features
	Given that I navigate to the DEFRA application
	When setup an application with all tasks with skip funtion via backend
	And submit an application with skip funtion via backend
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And application page is displayed
	Then search for a created application
	When I click on the copy application
	And the copy application page is displayed
	And I click on "yes" to copy everything from the application
	And I click on Continue button
	And I enter a new reference on the copy application reference page
	And I click Create copy button
	And I navigate to commodities summary page
	And I click 'No' to add more records on commodities summary page
	And I am taken to Check your answers page
	Then I can see the features that skipped labelled as 'Not Entered' 

	Examples: 
	| logininfo |
	| exporter  |

Scenario Outline: Copy Skipped application - Check your answers page shows in commodities section the number of records for the number of commodities
	Given that I navigate to the DEFRA application
	When setup an application with all tasks with skip funtion via backend
	And submit an application with skip funtion via backend
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And application page is displayed
	Then search for a created application
	When I click on the copy application
	And the copy application page is displayed
	And I click on "yes" to copy everything from the application
	And I click on Continue button
	And I enter a new reference on the copy application reference page
	And I click Create copy button
	And I navigate to commodities summary page
	And I click 'No' to add more records on commodities summary page
	And I am taken to Check your answers page
	Then I can see the number of records in commodities section

	Examples: 
	| logininfo |
	| exporter  |