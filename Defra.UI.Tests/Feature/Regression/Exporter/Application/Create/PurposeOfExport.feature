@Exporter
Feature: Purpose Of Export
As a Defra customer, I am able to select purpose Of export
Scenario Outline: Select purpose of export
	Given that I navigate to the DEFRA application
	When sign in with valid credentials with logininfo '<logininfo>'
	Then check the user is '<logininfo>'
	And application page is displayed
	And start a new application and click start now
	And enter a unique application reference '<reference>' and continue
	And select certificate for your export '<certificate>' and continue
	And select commodity '<commodityNumber>' and continue
	And add commodity '<noofidentification>' for '<certificate>' data and continue  
	And verify commodity has been added successfully
	And navigate to purpose of export page
	And click on save and continue without selecting any option
	And validation message is displayed
	And select the type of consignment '<consignmentType>' and continue
	And country validation message is displayed
	And select the purpose of export '<purposetype>' and continue
	And verify purpose of export has been completed successfully

	Examples: 
	| logininfo | reference      | certificate | commodityNumber | noofidentification | purposetype		     | consignmentType        |
	| exporter  | automationtest | EHC8361     | 030231          | 2                  | Re-entry consignment | In transit consignment |