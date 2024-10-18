@Regression
Feature: Edit Border Control Post

As a Certifier edit the Border Control Post
As a Certifier, I should not see the Skip functionality

Scenario: Certifier - edit the Border Control Post
	Given setup an application with all tasks via backend '<logininfo>'
	And submit an application via backend
	And create a certificate via backend
	When that I navigate to the DEFRA application
	Then sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And on certifier application page is displayed
	And search for a created application
	And I click in to the created application
	And click on Part1 'Transport' tab
	And I click edit on application Border Control Post
	And change the broder control post with '<country>' and '<borderControlName>'
	Then verify change has added successfully

	Examples: 
	| logininfo |  country | borderControlName	   |
	| certifier |  XI      | Larne Harbour - MEA   |

Scenario: Certifier - Skip functionality cannot be accessed Border Control Post
	Given that I navigate to the DEFRA application
	When setup an application with all tasks with skip funtion via backend
	And submit an application with skip funtion via backend
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And application page is displayed
	Then search for a created application
	When I click in to the created application
	And click on Part1 'Transport' tab
	And I click edit on application Border Control Post
	Then verify skip functionality no longer on certifier page

	Examples: 
	| logininfo | 
	| certifier |