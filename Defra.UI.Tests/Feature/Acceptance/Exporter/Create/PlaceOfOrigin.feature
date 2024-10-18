@acceptance  @Regression
Feature: PlaceOfOrigin

As an exporter, I want the ability to skip place of origin, so that I continue with my application and submit it to the certifier to help complete the information I did not know

Scenario: Exporter tries to continue with blank fields without choosing skip
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
	And I press save and continue
    Then I can see the validation informing me to select the skip checkbox validation

Examples:
	| logininfo | reference      | certificate | commodityNumber | noofidentification | CountryOfOrigin | PlaceOfDispatchCountry | PlaceOfDispatch | PlaceOfLoadingCountry | PlaceOfLoading |
	| exporter  | skiptest       | EHC8361     | 030231          | 1                  | GB              | GB                     | Defra eTrade    | GB                    | Defra eTrade   |

Scenario: Skip validation (and checkbox) disappears from bottom of page where all mandatory details are populated
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
	And I press save and continue
    Then I can see the validation informing me to select the skip checkbox validation
	When complete place of origin with '<CountryOfOrigin>','<PlaceOfDispatchCountry>', '<PlaceOfDispatch>', '<PlaceOfLoadingCountry>', '<PlaceOfLoading>'
	Then the skip validation message and checkbox is removed

Examples:
	| logininfo | reference      | certificate | commodityNumber | noofidentification | CountryOfOrigin | PlaceOfDispatchCountry | PlaceOfDispatch | PlaceOfLoadingCountry | PlaceOfLoading |
	| exporter  | skiptest       | EHC8361     | 030231          | 1                  | GB              | GB                     | Defra eTrade    | GB                    | Defra eTrade   |

Scenario: Exporter continues after selecting skip with some blank place of origin fields
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
	And I have ticked the skip checkbox for place of origin and continue
	When I navigate to place of origin page
    Then I can still see the blank fields that I skipped with the skip tickbox still checked

Examples:
	| logininfo | reference      | certificate | commodityNumber | noofidentification | CountryOfOrigin | PlaceOfDispatchCountry | PlaceOfDispatch | PlaceOfLoadingCountry | PlaceOfLoading |
	| exporter  | skiptest       | EHC8361     | 030231          | 1                  | GB              | GB                     | Defra eTrade    | GB                    | Defra eTrade   |

Scenario: Skip checkbox no longer displayed when all mandatory place of origin fields are provided
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
	And complete place of origin with '<CountryOfOrigin>','<PlaceOfDispatchCountry>', '<PlaceOfDispatch>', '<PlaceOfLoadingCountry>', '<PlaceOfLoading>'
	Then I can see that the skip checkbox is no longer there

Examples:
	| logininfo | reference      | certificate | commodityNumber | noofidentification | CountryOfOrigin | PlaceOfDispatchCountry | PlaceOfDispatch | PlaceOfLoadingCountry | PlaceOfLoading |
	| exporter  | skiptest       | EHC8361     | 030231          | 1                  | GB              | GB                     | Defra eTrade    | GB                    | Defra eTrade   |

	Scenario Outline: Check operator approval no present in the operator search result in place of dispatch
	Given that I navigate to the DEFRA application
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And setup an application via backend
	And I deeplink to the commodity selection page with certificate '<certificate>'
	And select commodity '<commodityNumber>' and continue
	And add commodity '<noOfIdentification>' for '<certificate>' data and continue  
	And verify commodity has been added successfully
	When I navigate to place of origin page from Task list page
	Then Check Operator Approval no present in the operator search in Place of Despatch with '<CountryOfOrigin>','<PlaceOfDispatchCountry>', '<PlaceOfDispatch>'

Examples:
	| logininfo | reference      | certificate | commodityNumber | noOfIdentification | CountryOfOrigin | PlaceOfDispatchCountry | PlaceOfDispatch | PlaceOfLoadingCountry | PlaceOfLoading	 |	RemoveSection		|
	| exporter  | skiptest       | EHC8361     | 030231          | 1                  | GB              | GB                     | Defra eTrade    | GB                    | Defra eTrade    |	Place of dispatch	|

	Scenario Outline: Check operator approval no present in the operator search result in place of loading
	Given that I navigate to the DEFRA application
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And setup an application via backend
	And I deeplink to the commodity selection page with certificate '<certificate>'
	And select commodity '<commodityNumber>' and continue
	And add commodity '<noOfIdentification>' for '<certificate>' data and continue  
	And verify commodity has been added successfully
	When I navigate to place of origin page from Task list page
	Then Check Operator Approval no present in the operator search in Place of Loading with '<CountryOfOrigin>','<PlaceOfLoadingCountry>', '<PlaceOfLoading>'

Examples:
	| logininfo | reference      | certificate | commodityNumber | noOfIdentification | CountryOfOrigin | PlaceOfDispatchCountry | PlaceOfDispatch | PlaceOfLoadingCountry | PlaceOfLoading	 |	RemoveSection		|
	| exporter  | skiptest       | EHC8361     | 030231          | 1                  | GB              | GB                     | Defra eTrade    | GB                    | Defra eTrade    |	Place of dispatch	|


	Scenario Outline: Check operator approval no present after selection of place of dispatch and place of loading
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
	Then verify approval no present in the place of dispatch and place of loading selections

Examples:
	| logininfo | reference      | certificate | commodityNumber | noOfIdentification | CountryOfOrigin | PlaceOfDispatchCountry | PlaceOfDispatch | PlaceOfLoadingCountry | PlaceOfLoading	 |	RemoveSection		|
	| exporter  | skiptest       | EHC8361     | 030231          | 1                  | GB              | GB                     | Defra eTrade    | GB                    | Defra eTrade    |	Place of dispatch	|