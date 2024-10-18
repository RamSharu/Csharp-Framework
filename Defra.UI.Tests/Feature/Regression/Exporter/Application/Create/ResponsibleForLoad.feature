@Exporter
Feature: Responsible For Load

As a Defra customer, I am able to complete responsible for load section
Scenario Outline: Responsible For Load
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
	When I navigate to responsible for load page
	And complete responsible for load '<responsibleforloadcountry>' and '<responsibleforloadoperator>' and continue
	Then verify responsible for load has been added successfully

Examples:
	| logininfo | reference      | certificate | commodityNumber | noofidentification | responsibleforloadcountry | responsibleforloadoperator |
	| exporter  | automationtest | EHC8361     | 030231          | 1                  | XI                        | defra                      |