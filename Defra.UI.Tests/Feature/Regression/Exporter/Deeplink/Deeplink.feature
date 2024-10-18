@Exporter
Feature: Deeplinks
As a Defra customer, I am able to Deeplink to application and add new Commodity 
Scenario Outline: Deeplink Tests for adding new Commodity
	Given that I navigate to the DEFRA application
	Then sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	Then setup an application via backend
	Then I deeplink to the commodity selection page with certificate '<certificate>'
	Then select commodity '<commodityNumber>' and continue
	Then add commodity '<noofidentification>' for '<certificate>' data and continue  
	Then verify commodity has been added successfully

	Examples: 
	| logininfo | certificate | commodityNumber | noofidentification |
	| exporter  | 8361        | 030231          | 1                  |
