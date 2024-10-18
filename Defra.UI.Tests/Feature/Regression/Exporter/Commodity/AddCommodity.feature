@Exporter
Feature: AddCommodityData

As an Exporter, I am able to add commodity data, operator and operator activities as I create a new application

Scenario Outline: Add commodity data to a new application
	Given I navigate to the DEFRA application
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And application page is displayed
	And start a new application and click start now
	And enter a unique application reference '<reference>' and continue
	And select certificate for your export '<certificate>' and continue
	When select commodity '<commodityNumber>' and continue
	Then add commodity '<noofidentification>' for '<certificate>' data and continue  
	And verify commodity has been added successfully

Examples:
	| logininfo | reference      | certificate | commodityNumber | noofidentification | 
	| exporter  | automationtest | EHC8361     | 030231          | 1                  |

Scenario Outline: Multiple activities with similar names to be displayed as one on commodity screen
	Given I navigate to the DEFRA application
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And setup an application via backend
	And I deeplink to the commodity selection page with certificate '<certificate>'
	And select commodity '<commodityNumber>' and continue
	And I am on the Identification page
	When I click on select manufacturing plant link
	And I am on the Establishment lookup page
	And I search for an operator '<operatorName>' that has multiple of the same activity
	Then I can see that multiple activities with similar names are displayed as one in the activities section of searched operator
Examples:
	| logininfo | reference      | certificate | commodityNumber | operatorName		  | 
	| exporter  | automationtest | EHC8361     | 030231          | Defra              |

Scenario Outline: Activity selection screen displays all the activities for all their classification groups and classifications
	Given I navigate to the DEFRA application
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And setup an application via backend
	And I deeplink to the commodity selection page with certificate '<certificate>'
	And select commodity '<commodityNumber>' and continue
	And I am on the Identification page
	When I click on select manufacturing plant link
	And I am on the Establishment lookup page
	And I search for an operator '<operatorName>' that has multiple of the same activity
	And I select '<operatorName>' from the operator search results and click save and continue
	And I am on the establishment lookup page where list of operator activities are displayed
	Then I can validate all the mandatory fields on establishment lookup page
	And I can see all the activities for all the classification groups and classifications displayed
	And the activities are displayed in alphabetical order by activity and then classification
Examples:
	| logininfo | reference      | certificate | commodityNumber | operatorName		  | 
	| exporter  | automationtest | EHC8361     | 030231          | Defra              |

Scenario Outline: Validation where no activity selected for the operator
	Given I navigate to the DEFRA application
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And setup an application via backend
	And I deeplink to the commodity selection page with certificate '<certificate>'
	And select commodity '<commodityNumber>' and continue
	And I am on the Identification page
	When I click on select manufacturing plant link
	And I am on the Establishment lookup page
	And I search for the operator '<operatorName>'
	And I select '<operatorName>' from the operator search results and click save and continue
	And I am on the establishment lookup page where list of operator activities are displayed
	And I click on Save and continue button without selecting operator activity
	Then I can see that validation messages are displayed as operator activity is not selected
Examples:
	| logininfo | reference      | certificate | commodityNumber | operatorName		  | 
	| exporter  | automationtest | EHC8361     | 030231          | Defra              |