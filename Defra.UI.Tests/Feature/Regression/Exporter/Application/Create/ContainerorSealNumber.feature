@Exporter
Feature: Container or Seal Number

As a Defra customer, I am able to add Container and seal number section

Scenario Outline: Container or Seal Number
	Given that I navigate to the DEFRA application
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And application page is displayed
	And start a new application and click start now
	And enter a unique application reference '<reference>' and continue
	And select certificate for your export '<certificate>' and continue
	And select commodity '<commodityNumber>' and continue
	And add commodity '<noofidentification>' for '<certificate>' data and continue
	And verify commodity has been added successfully
	When I navigate to container seal number page
	And complete '<containerno>' and '<sealno>' and continue
	Then verify container and seal number has been added successfully

	Examples: 
	| logininfo | reference      | certificate | commodityNumber | noofidentification | containerno | sealno |
	| exporter  | automationtest | EHC8361     | 030231          | 1                  | BICU1234567 | 012345 |