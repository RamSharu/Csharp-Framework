@Certifier
Feature: Part 2 - CertificationValidation

As a certifier, I can validate if all mandatory fields are displayed on the certification page for the certifier to certify an EHC

Scenario Outline: Validate OV Disease clearance check date box on part 2 certification page
	Given that I navigate to the DEFRA application
	And I set up an application with all tasks via backend for EHCs having disease clearance
	And submit an application via backend
	And create a certificate via backend
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And on certifier application page is displayed
	And I search and click on the certificate to proceed to the certifier view page
	When I click on Part II Certification tab
	Then I can validate that disease clearance check date box is displayed
Examples: 
	| logininfo | 
	| certifier |