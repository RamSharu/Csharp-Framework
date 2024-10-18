@acceptance
Feature: CertifierPlaceOfDestinationOperatorSearch

As a Certifier, I am able to see validation when missing fields for my operator search

Scenario Outline: Missing fields for Place of destination search
	Given setup an application with all tasks via backend '<logininfo>'
	And submit an application via backend
	And create a certificate via backend
	And that I navigate to the DEFRA application
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And on certifier application page is displayed
	And search for a created application
	And I click in to the created application
	And I remove place of destination
	When select a place of destination
	Then search by '<destinationCountry>' and '<destinationName>'
	
	Examples: 
	| logininfo | destinationCountry | destinationName |
	| certifier | XI                 | empty           |
	| certifier | empty              | defra           |
	| certifier | empty              | empty           |

Scenario Outline: No selection from Place of destination results
	Given setup an application with all tasks via backend '<logininfo>'
	And submit an application via backend
	And create a certificate via backend
	And that I navigate to the DEFRA application
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And on certifier application page is displayed
	And search for a created application
	And I click in to the created application
	And I remove place of destination
	When select a place of destination
	Then search by '<destinationCountry>' and '<destinationName>'
	And I click save and continue
	And organisation alert is thrown
	
	Examples: 
	| logininfo | destinationCountry | destinationName |
	| certifier  | XI                 | defra          |