@Certifier 
Feature: EditRegionOfCertification

As a Certifier edit the application and change Region of Certification

Scenario: Certifier edit region of certification
	Given setup an application with all tasks via backend '<logininfo>'
	And submit an application via backend
	And create a certificate via backend
	When that I navigate to the DEFRA application
	Then sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And on certifier application page is displayed
	And search for a created application
	When I click in to the created application
	When I change region of certification
	Then I verify changed region of certification

Examples:
	| logininfo |
	| certifier |

