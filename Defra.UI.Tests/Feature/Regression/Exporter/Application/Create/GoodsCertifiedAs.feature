@Exporter
Feature: Goods Certified AS

As a Defra customer, I am able to add Good Certified as section
Scenario Outline: Select goods certified as
	Given that I navigate to the DEFRA application
	Then sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And application page is displayed
	Then start a new application and click start now
	And enter a unique application reference '<reference>' and continue
	And select certificate for your export '<certificate>' and continue
	Then select commodity '<commodityNumber>' and continue
	Then add commodity '<noofidentification>' for '<certificate>' data and continue
	And verify commodity has been added successfully
	When select goods certified as '<goodscertifiedas>' and continue
	Then verify goods certified has been added successfully

	Examples: 
	| logininfo | reference      | certificate | commodityNumber | noofidentification | goodscertifiedas |
	| exporter  | automationtest | EHC8361     | 030231          | 1                  | Human consumption |