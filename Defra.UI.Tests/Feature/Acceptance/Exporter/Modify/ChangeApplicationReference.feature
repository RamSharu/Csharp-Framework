@acceptance
Feature: ChangeApplicationReference

As an exporter I want to be able to change the application reference once the application has been created

Background: 
	Given that I navigate to the DEFRA application
	Then setup an application via backend

Scenario: Exporter change application reference
	And sign in with valid credentials with logininfo 'exporter'
	And check the user is 'exporter'
	And application page is displayed
	Then search for a created application
	Then user clicks the view application and verify
	When I click change by application reference 
    Then I am directed to input a new reference page whereby I can input and save a new reference

Scenario: Exporter enters reference with more than 25 characters
	And sign in with valid credentials with logininfo 'exporter'
	And check the user is 'exporter'
	And application page is displayed
	Then search for a created application
	Then user clicks the view application and verify
	When I click change by application reference 
	When I provide a reference with greater than 25 characters
    Then I am shown validation 'The application reference must be 25 characters or less'