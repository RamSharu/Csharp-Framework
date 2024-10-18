@Certifier 
Feature: ReturnToCertifierDashboard

As A Certifier I Want To click into an application and click back So That I can return to certifier dashboard

Scenario: Click into a created application on Certifier and then click back
	Given setup an application with all tasks via backend '<logininfo>'
	And submit an application via backend
	And create a certificate via backend
	When that I navigate to the DEFRA application
	Then sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And on certifier application page is displayed
	And search for a created application
	And click on show button
	And click in to the created application link
	And click on back button
	And on certifier application page is displayed

	Examples: 
	| logininfo |  
	| certifier |

