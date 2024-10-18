@acceptance
Feature: PlaceOfDestinationOperatorSearch

As a Defra customer, I am able to see validation when missing fields for approved establishments operator search

Scenario Outline: Missing fields for Place of destination search
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
	And I navigate to place of destination
	When select a place of destination
	Then search by '<destinationCountry>' and '<destinationName>'

	Examples: 
	| logininfo | reference    | certificate | commodityNumber | noofidentification | destinationCountry | destinationName |
	| exporter  | emptyname    | EHC8361     | 030231          | 1                  | XI                 | empty           |
	| exporter  | emptycountry | EHC8361     | 030231          | 1                  | empty              | defra           |
	| exporter  | emptyboth    | EHC8361     | 030231          | 1                  | empty              | empty           |


Scenario Outline: No selection from Place of destination results
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
	And I navigate to place of destination
	When select a place of destination
	Then search by '<destinationCountry>' and '<destinationName>'
	And I click save and continue
	And organisation alert is thrown

	Examples:
	| logininfo | reference   | certificate | commodityNumber | noofidentification | destinationCountry | destinationName |
	| exporter  | noselection | EHC8361     | 030231          | 1                  | XI                 | defra           |