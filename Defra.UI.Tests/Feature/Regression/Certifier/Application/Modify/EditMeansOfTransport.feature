@Certifier
Feature: EditMeansOfTransport

As a Certifier edit the application and change means of transport

As a Certifier I can see all validation information for not selecting means of transport

As a Certifier, I should not see the Skip functionality


Scenario: Certifier edit means of transport
	Given setup an application with all tasks via backend '<logininfo>'
	And submit an application via backend
	And create a certificate via backend
	When that I navigate to the DEFRA application
	Then sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And on certifier application page is displayed
	And search for a created application
	When I click in to the created application
	When I change  means of transport
	Then I verify changed means of transport

Examples:
	| logininfo | 
	| certifier |

Scenario: Certifier - Skip functionality cannot be accessed means of transport
	Given that I navigate to the DEFRA application
	When setup an application with all tasks with skip funtion via backend
	And submit an application with skip funtion via backend
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And application page is displayed
	Then search for a created application
	When I click in to the created application
	And click on Part1 'Transport' tab
	And I click edit on application means of transport
	Then verify skip functionality no longer on certifier page

	Examples: 
	| logininfo | 
	| certifier |