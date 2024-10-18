@Exporter
Feature: Place of origin

As a Defra customer, I am able to add Place of origin in new application

Scenario Outline: Complete Place of origin to new application
	Given that I navigate to the DEFRA application
	When sign in with valid credentials with logininfo '<logininfo>'
	Then check the user is '<logininfo>'
	And application page is displayed
	And start a new application and click start now
	And enter a unique application reference '<reference>' and continue
	And select certificate for your export '<certificate>' and continue
	And select commodity '<commodityNumber>' and continue
	And add commodity '<noofidentification>' for '<certificate>' data and continue
	And verify commodity has been added successfully
	When I navigate to place of origin page
	And complete place of origin with '<CountryOfOrigin>','<PlaceOfDispatchCountry>', '<PlaceOfDispatch>', '<PlaceOfLoadingCountry>', '<PlaceOfLoading>' and continue
	And verify place of origin has been added successfully

Examples:
	| logininfo | reference      | certificate | commodityNumber | noofidentification | CountryOfOrigin | PlaceOfDispatchCountry | PlaceOfDispatch | PlaceOfLoadingCountry | PlaceOfLoading |
	| exporter  | automationtest | EHC8361     | 030231          | 1                  | GB              | GB                     | Defra eTrade    | GB                    | Defra eTrade   |

Scenario Outline: Place of origin - Add place of dispatch and skip place of loading
	Given that I navigate to the DEFRA application
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And setup an application via backend
	And I deeplink to the commodity selection page with certificate '<certificate>'
	And select commodity '<commodityNumber>' and continue
	And add commodity '<noOfIdentification>' for '<certificate>' data and continue  
	And verify commodity has been added successfully
	When I navigate to place of origin page from Task list page
	And I complete place of dispatch with '<PlaceOfDispatchCountry>' '<PlaceOfDispatch>' skipping the place of loading
	And I have ticked the skip checkbox for place of origin and continue
	And I navigate to place of origin page
	Then I can still see Place of loading is blank with the skip tickbox still checked
Examples:
	| logininfo | reference      | certificate | commodityNumber | noOfIdentification | CountryOfOrigin | PlaceOfDispatchCountry | PlaceOfDispatch |
	| exporter  | skiptest       | EHC8361     | 030231          | 1                  | GB              | GB                     | Defra eTrade    |

Scenario Outline: Place of origin - Add place of loading and skip place of dispatch
	Given that I navigate to the DEFRA application
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And setup an application via backend
	And I deeplink to the commodity selection page with certificate '<certificate>'
	And select commodity '<commodityNumber>' and continue
	And add commodity '<noOfIdentification>' for '<certificate>' data and continue  
	And verify commodity has been added successfully
	When I navigate to place of origin page from Task list page
	And I complete place of loading with '<PlaceOfLoadingCountry>' '<PlaceOfLoading>' skipping the place of dispatch
	And I have ticked the skip checkbox for place of origin and continue
	And I navigate to place of origin page
	Then I can still see Place of dispatch is blank with the skip tickbox still checked
Examples:
	| logininfo | reference      | certificate | commodityNumber | noOfIdentification | PlaceOfLoadingCountry | PlaceOfLoading	 |
	| exporter  | skiptest       | EHC8361     | 030231          | 1                  | GB                    | Defra eTrade     |

Scenario Outline: Skip checkbox to be displayed on removing any inputs
	Given that I navigate to the DEFRA application
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And setup an application via backend
	And I deeplink to the commodity selection page with certificate '<certificate>'
	And select commodity '<commodityNumber>' and continue
	And add commodity '<noOfIdentification>' for '<certificate>' data and continue  
	And verify commodity has been added successfully
	When I navigate to place of origin page from Task list page
	And complete place of origin with '<CountryOfOrigin>','<PlaceOfDispatchCountry>', '<PlaceOfDispatch>', '<PlaceOfLoadingCountry>', '<PlaceOfLoading>'
	And I can see that the skip checkbox is no longer there
	And I remove the section '<RemoveSection>'
	Then The skip checkbox is displayed
Examples:
	| logininfo | reference      | certificate | commodityNumber | noOfIdentification | CountryOfOrigin | PlaceOfDispatchCountry | PlaceOfDispatch | PlaceOfLoadingCountry | PlaceOfLoading	 |	RemoveSection		|
	| exporter  | skiptest       | EHC8361     | 030231          | 1                  | GB              | GB                     | Defra eTrade    | GB                    | Defra eTrade    |	Place of dispatch	|
	| exporter  | skiptest       | EHC8361     | 030231          | 1                  | GB              | GB                     | Defra eTrade    | GB                    | Defra eTrade    |	Place of loading	|

Scenario Outline: Place of origin - Search operators by approval number 
	Given that I navigate to the DEFRA application
	When sign in with valid credentials with logininfo '<logininfo>'
	Then check the user is '<logininfo>'
	And application page is displayed
	And start a new application and click start now
	And enter a unique application reference '<reference>' and continue
	And select certificate for your export '<certificate>' and continue
	And select commodity '<commodityNumber>' and continue
	And add commodity '<noofidentification>' for '<certificate>' data and continue
	And verify commodity has been added successfully
	When I navigate to place of origin page
	And complete place of origin with '<CountryOfOrigin>','<PlaceOfDispatchCountry>', '<PlaceOfDispatch>', '<PlaceOfLoadingCountry>', '<PlaceOfLoading>', '<SearchByOpearetor>' and continue
	And verify place of origin has been added successfully
Examples:
	| logininfo | reference      | certificate | commodityNumber | noofidentification | CountryOfOrigin | PlaceOfDispatchCountry | PlaceOfDispatch | PlaceOfLoadingCountry | PlaceOfLoading | SearchByOpearetor |
	| exporter  | automationtest | EHC8361     | 030231          | 1                  | GB              | GB                     | Defra eTrade    | GB                    | Defra eTrade	| true				|
	| exporter  | automationtest | EHC8361     | 030231          | 1                  | GB              | GB                     | GBVAT4556       | GB                    | GBVAT4556		| false             |