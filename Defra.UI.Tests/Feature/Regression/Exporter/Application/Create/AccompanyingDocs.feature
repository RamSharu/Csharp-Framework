@Exporter
Feature: Accompanying documents
As a Defra customer, I am able to add accompanying documents in the new application
Scenario Outline: Adding documents in the accompanyimg documents section
	Given that I navigate to the DEFRA application
	Then sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And application page is displayed
	And start a new application and click start now
	And enter a unique application reference '<reference>' and continue
	And select certificate for your export '<certificate>' and continue
	And select commodity '<commodityNumber>' and continue
	And add commodity '<noofidentification>' for '<certificate>' data and continue  
	And verify commodity has been added successfully
	When I click on the accompanying documents link from task list page
	And I am on accompanying documents page
	Then I can add document details '<documentType>' '<documentRef>' and attach documents in the documents section
	And I can verify that the accompanying document is added successfully
	
	Examples: 
	| logininfo | reference      | certificate | commodityNumber | noofidentification |documentType |documentRef |
	| exporter  | automationtest | EHC8361     | 030231          | 1                  |740			|Test		 |
