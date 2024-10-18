@Certifier
Feature: Certifier - EditAdditionalDocuments

As a Certifier, I can edit the additional documents that has been added in an application

Scenario Outline: Certifier - Edit additional documents
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
	And I click on the edit link in the documents section
	Then I can add document details '<documentType>' '<documentRef>' and attach documents in the documents section
	And I can verify that the document is added successfully by the certifier
Examples:
	| logininfo | EHCNumber | documentType | documentRef |
	| certifier | EHC8361   | 720		   | EditDoc	 | 