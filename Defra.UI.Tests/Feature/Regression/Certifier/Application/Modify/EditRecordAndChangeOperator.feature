@Certifier
Feature: EditRecordAndChangeOperator

As a Certifier edit the application, edit record and change operator

Scenario: Certifier edit record and change operator
	Given setup an application with all tasks via backend '<logininfo>'
	And submit an application via backend
	And create a certificate via backend
	When that I navigate to the DEFRA application
	Then sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And on certifier application page is displayed
	And search for a created application
	And I click in to the created application
	And I change commodity record operator
	Then I verify changed record operator

Examples:
	| logininfo | EHCNumber | 
	| certifier | EHC8361   |

