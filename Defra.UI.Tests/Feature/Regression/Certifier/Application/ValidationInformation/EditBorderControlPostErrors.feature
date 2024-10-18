@Certifier
Feature: Edit BCP to validate fields and errors

As a Certifier, I am able to edit the BCP section of a submitted application and validate the error messages that appear
Scenario:Certifier edit Border Control Post
	Given setup an application with all tasks via backend '<logininfo>'
	And submit an application via backend
	And create a certificate via backend
	When that I navigate to the DEFRA application
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	Then on certifier application page is displayed
	And search for a created application
	And I click in to the created application
	And click on Part1 'Transport' tab
	Then I submit Border Control Post without answering bcp value
	And I verify error message for Border Control Post 'Select a country from the provided list'

Examples:
	| logininfo |
	| certifier |