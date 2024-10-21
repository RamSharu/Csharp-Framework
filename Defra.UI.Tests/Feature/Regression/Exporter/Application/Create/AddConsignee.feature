@Exporter
Feature: AddConsignee

As a Defra customer, I am able to add Consignee in new application
Scenario Outline: Add consignee to new application
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
	And add consignee '<consigneeName>' for '<consigneeCountry>' and continue
	And verify consignee has been added successfully

	Examples: 
	| logininfo | reference      | certificate | commodityNumber | noofidentification | consigneeName | consigneeCountry |
	| exporter  | automationtest | EHC8361     | 030231          | 1                  | Defra eTrade  | XI               |