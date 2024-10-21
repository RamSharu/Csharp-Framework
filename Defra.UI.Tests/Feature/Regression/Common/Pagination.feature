@Regression @Common
Feature: Pagination

As a defra customer, I am able to see pagination on home page

Background: 
	Given that I navigate to the DEFRA application

Scenario Outline: Validate first page
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And application page is displayed
	Then I can validate that first page is displayed by default
	And I can see the number of applications

Examples: 
	| logininfo |
	| exporter  |
	| certifier |

Scenario Outline: Validate Next link on pagination
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And application page is displayed
	And I can validate that first page is displayed by default
	When I click the Next link on pagination
	Then I can see that the next page is displayed
	And I can see the number of applications

Examples: 
	| logininfo |
	| exporter  |
	| certifier |

Scenario Outline: Validate last page on pagination
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And application page is displayed
	And I can validate that first page is displayed by default
	When I click on the last page link
	Then I can see that the last page is displayed
	And the applications in last page are displayed

Examples: 
	| logininfo |
	| exporter  |
	| certifier |