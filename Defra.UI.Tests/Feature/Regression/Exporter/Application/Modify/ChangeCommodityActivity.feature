@Exporter
Feature: ChangeCommodityActivity

As a Defra customer, I am able to change Commodity activity
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
	And change commodity activity to '<activityName>'
	And verify commodity activity '<activityName>' has been changed successfully
	Examples: 
	| logininfo | reference      | certificate | commodityNumber | noofidentification | activityName       |
	| exporter  | automationtest | EHC8361     | 030231          | 1                  | Minced meat plant  |