@Certifier 
Feature: SearchApplication

As a Defra customer able to Submit the application via backend and Search application on Certifier

Scenario: Submit Application as Exporter and Search application on Certifier 
	Given setup an application with all tasks via backend '<logininfo>'
	And submit an application via backend
	And create a certificate via backend
	When that I navigate to the DEFRA application
	Then sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And on certifier application page is displayed
	And search for a created application

	Examples: 
	| logininfo |  
	| certifier |

