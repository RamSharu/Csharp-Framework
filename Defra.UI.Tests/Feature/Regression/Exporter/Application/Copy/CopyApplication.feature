@Exporter
Feature: CopyApplication

As a Defra customer, I am able to copy the application based on the selected checkboxes

Background: 
	Given that I navigate to the DEFRA application
	Then setup an application with all tasks via backend

Scenario Outline: Copy application page validation
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And application page is displayed
	Then search for a created application
	When I click on the copy application
	Then the copy application page is displayed
	And I can validate all the fields on copy application page

	Examples: 
	| logininfo |
	| exporter  |

Scenario Outline: Copy application - Click 'Yes' to copy everything from the application radio
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
	When I navigate to commodity summary page
	And I click on "no" to add another commodity on summary page and continue
	Then I am taken to Check your answers page
	And I can see the list of tasks that need to be completed followed by the full list of tasks for the application

	Examples: 
	| logininfo |
	| exporter  |

Scenario Outline: Copy application Click 'No' to copy everything from the application radio
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And application page is displayed
	Then search for a created application
	When I click on the copy application
	And the copy application page is displayed
	And I click on "no" to copy everything from the application
	And I click on Continue button
	And I select any one checkbox on the which sections to copy page
	And I enter a new reference on the copy application reference page
	And I click Create copy button
	When I navigate to commodity summary page
	And I click on "no" to add another commodity on summary page and continue
	Then I am taken to Check your answers page
	And I can see the list of tasks that need to be completed followed by the full list of tasks for the application

	Examples: 
	| logininfo |
	| exporter  |

Scenario Outline: Validate gross weight page leaving gross weight field blank on a copied application
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
	When I navigate to commodity summary page
	And I click on "no" to add another commodity on summary page and continue
	Then I am taken to Check your answers page
	And I can see the list of tasks that need to be completed followed by the full list of tasks for the application
	And I am on check your answers page to update 'Gross weight' section
	When I add gross weight unit '<grossweightunit>' leaving gross weight amount blank
	Then verify Gross Weight validation message information

	Examples: 
	| logininfo | grossweightunit | 
	| exporter  | KGM			  |