@Certifier 
Feature: CertifierHomepageValidations

As a Certifier I Want To validate all fields on the homepage

Scenario: Validate functionality on Certifier homepage
	Given that I navigate to the DEFRA application
	And sign in with valid credentials with logininfo '<logininfo>'
	When check the user is '<logininfo>'
	Then on certifier application page is displayed
	And title is displayed
	And search box is displayed
	And filters are displayed
	And application record table is displayed	
	And page numbers are displayed

	Examples: 
	| logininfo |  
	| certifier |

Scenario: Validate Certifier can Assign application from homepage
	Given setup an application with all tasks via backend '<logininfo>'
	And submit an application via backend
	And create a certificate via backend
	When that I navigate to the DEFRA application
	Then sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And on certifier application page is displayed
	And search for a created application
	And assign application

	Examples: 
	| logininfo |  
	| certifier |

Scenario: Validate Certifier can Cancel application from homepage
	Given setup an application with all tasks via backend '<logininfo>'
	And submit an application via backend
	And create a certificate via backend
	When that I navigate to the DEFRA application
	Then sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And on certifier application page is displayed
	And search for a created application
	And cancel application

	Examples: 
	| logininfo |  
	| certifier |