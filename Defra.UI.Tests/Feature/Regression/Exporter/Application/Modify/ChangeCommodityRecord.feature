@Exporter
Feature: ChangeCommodityRecord

As a Defra customer, I am able to change Commodity Record
Scenario Outline: Change commodity record
	Given that I navigate to the DEFRA application
	When sign in with valid credentials with logininfo '<logininfo>'
	Then check the user is '<logininfo>'
	And application page is displayed
	And start a new application and click start now
	And enter a unique application reference '<reference>' and continue
	And select certificate for your export '<certificate>' and continue
	And select commodity '<commodityNumber>' and continue
	And add commodity '<noofidentification>' for '<certificate>' data and continue
	And change commodity record fields '<productDesc>', '<packageCount>' and '<netWeight>'
	And verify commodity record has been changed successfully

	Examples: 
	| logininfo | reference      | certificate | commodityNumber | noofidentification | productDesc  | packageCount | netWeight |
	| exporter  | automationtest | EHC8361     | 030231          | 1                  | Auto Product | 5            | 5         |
