@Exporter
Feature: ComplelePlaceOfDestination
As a Defra customer, I am create an application and add Place of Destination

Scenario Outline: ComplelePlaceOfDestination
	Given that I navigate to the DEFRA application
	Then sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	Then setup an application via backend
	Then I deeplink to the commodity selection page with certificate '<certificate>'
	Then select commodity '<commodityNumber>' and continue
	Then add commodity '<noOfIdentification>' for '<certificate>' data and continue  
	Then verify commodity has been added successfully
	Then verify place of destination by adding '<PlaceOfDestCountry>' and '<PlaceOfDestination>'
	Then place of destination details added successfully
	
	Examples: 
	| logininfo | certificate | commodityNumber | noOfIdentification | PlaceOfDestCountry | PlaceOfDestination |
	| exporter  | 8361        | 030231          | 1                  | XI                 | Defra              |
