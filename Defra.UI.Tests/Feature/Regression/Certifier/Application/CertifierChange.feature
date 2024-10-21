@Certifier
Feature: CertifierChange


As a Defra customer able to change certifer on submitted application

Scenario: Change certifier of submitted application 
	Given setup an application with all tasks via backend '<logininfo>'
	And submit an application via backend
	And create a certificate via backend
	When that I navigate to the DEFRA application
	Then sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And on certifier application page is displayed
	And search for a created application
	And click on show button
	And assign another certifier '<newCertifierName>'
	And click on show button
	And verify assigned certifier '<newCertifierName>'
	And click in to the created application link
	And go to Certification Part2 
	And click on check application data against Traces
	And sign and approve the application
	And click on show button
	And verify assigned certifier '<OldCertifierName>'

	Examples: 
	| logininfo | newCertifierName | OldCertifierName |
	| certifier | etradeuser2      | Declan Certifier |


