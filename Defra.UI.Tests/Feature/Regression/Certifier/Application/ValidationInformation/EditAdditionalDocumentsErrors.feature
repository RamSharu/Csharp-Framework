@Certifier
Feature: Certifier - ErrorValidation for AdditionalDocuments

As a Certifier, I can edit the additional documents validate the error message

Scenario: Certifier - Edit additional documents
	Given setup an application with all tasks via backend '<logininfo>'
	And submit an application via backend
	And create a certificate via backend
	When that I navigate to the DEFRA application
	Then sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And on certifier application page is displayed
	And search for a created application
	And I click in to the created application
	And I click on the Additional Documents tab to open the documents section
	And I click on the edit link in the documents section and click save
	| Error names                    |
	| Document type is required      |
	| Document reference is required |
	| Date of issue is required      |
	| Please upload a file           |

	Examples:
	| logininfo |
	| certifier |



	