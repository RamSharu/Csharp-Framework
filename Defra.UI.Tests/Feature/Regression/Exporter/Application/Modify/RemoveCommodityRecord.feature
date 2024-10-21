@Exporter
Feature: RemoveCommodityRecord

Scenario Outline: EHC New Application - Remove commodity records
	Given that I navigate to the DEFRA application
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And application page is displayed
	And start a new application and click start now
	And enter a unique application reference '<reference>' and continue
	And select certificate for your export '<certificate>' and continue
	And select commodity '<commodityNumber>' and continue
	And add commodity '<noofidentification>' for '<certificate>' data and continue
	And I verify that commodity data is added successfully
	When I click on remove commodity link
	Then I can verify that the commodity has been removed successfully

	Examples:
	| logininfo | reference      | certificate | commodityNumber | noofidentification | 
	| exporter  | automationtest | EHC8361     | 030231          | 1                  |

