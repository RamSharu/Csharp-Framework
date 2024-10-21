@acceptance
Feature: CheckYourAnswers

As an exporter, I want to be able to clearly see what answers I have given and what I have skipped for the place of origin section, 
so that I can properly review the information I have given or left for the certifier to populate

Scenario: Exporter answers all questions
	Given that I navigate to the DEFRA application
	When setup an application with all tasks via backend
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And application page is displayed
	And search for a created application
	And user clicks the view application and verify
	When I click on the review and submit application hyperlink
	And I am taken to Check your answers page
	Then I can see the answers I provided for place of origin '<origin>', place of dispatch '<dispatch>' and place of loading '<loading>' (and optional region if provided) '<region>'

	Examples: 
	| logininfo | origin              | region | dispatch                                    | loading                                     |
	| exporter  | United Kingdom (GB) | GB-1   | Defra eTrade Exporters LTD (Hertsmere, HA8) | Defra eTrade Exporters LTD (Hertsmere, HA8) |

Scenario: Exporter answers 2 questions and skips the remaining 2 - partially fills 
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
	And complete place of origin with '<CountryOfOrigin>' and region
	And I have ticked the skip checkbox for place of origin and continue
	When complete Gross Weight as '', '' and 'Yes'
	And select goods certified as 'Human Consumption' and continue
	Then navigate to purpose of export page
	And select the purpose of export 'Re-entry consignment' and continue
	And add consignor 'Defra eTrade' for 'GB' and continue
	And add consignee 'Defra eTrade' for 'XI' and continue
	When navigate to select certifier page
	And select certifier 'ABC' and continue
	Then navigate to region of certification page
	And select the region of certification 'England' and continue
	When I navigate to departure and arrival page
	And complete Departure And Arrival dates
	Then verify border control page by adding valid details 'XI' with 'Belfast Port - DAERA'
	And verify means of transport page by adding valid details
	Then verify place of destination by adding 'XI' and 'Defra'
	When I click on the review and submit application hyperlink
	And I am taken to Check your answers page
	Then I can see the answers I provided for place of origin '<origin>', place of dispatch '<dispatch>' and place of loading '<loading>' (and optional region if provided) '<region>'

Examples:
	| logininfo | reference      | certificate | commodityNumber | noofidentification | CountryOfOrigin | origin              | region | dispatch    | loading     |
	| exporter  | acceptancetest | EHC8361     | 030231          | 1                  | GB              | United Kingdom (GB) | GB-0   | Not entered | Not entered |

Scenario: Exporter skips all mandatory questions and leaves region blank
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
	When complete Gross Weight as '', '' and 'Yes'
	And select goods certified as 'Human Consumption' and continue
	Then navigate to purpose of export page
	And select the purpose of export 'Internal market' and continue
	And add consignor 'Defra eTrade' for 'GB' and continue
	And add consignee 'Defra eTrade' for 'XI' and continue
	When navigate to select certifier page
	And select certifier 'ABC' and continue
	Then navigate to region of certification page
	And select the region of certification 'England' and continue
	When I navigate to departure and arrival page
	And complete Departure And Arrival dates
	Then verify border control page by adding valid details 'XI' with 'Belfast Port - DAERA'
	And verify means of transport page by adding valid details
	Then verify place of destination by adding 'XI' and 'Defra'
	When I click on the review and submit application hyperlink
	And I am taken to Check your answers page
	Then I can see the answers I provided for place of origin '<origin>', place of dispatch '<dispatch>' and place of loading '<loading>' (and optional region if provided) '<region>'

Examples:
	| logininfo | reference      | certificate | commodityNumber | noofidentification | CountryOfOrigin | origin              | region        | dispatch    | loading     |
	| exporter  | acceptancetest | EHC8361     | 030231          | 1                  | GB              | United Kingdom (GB) | Not entered   | Not entered | Not entered |

Scenario: Exporter provides the place of origin
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
	When complete Gross Weight as '', '' and 'Yes'
	And select goods certified as 'Human Consumption' and continue
	Then navigate to purpose of export page
	And select the purpose of export 'Internal market' and continue
	And add consignor 'Defra eTrade' for 'GB' and continue
	And add consignee 'Defra eTrade' for 'XI' and continue
	When navigate to select certifier page
	And select certifier 'ABC' and continue
	Then navigate to region of certification page
	And select the region of certification 'England' and continue
	When I navigate to departure and arrival page
	And complete Departure And Arrival dates
	Then verify border control page by adding valid details 'XI' with 'Belfast Port - DAERA'
	And verify means of transport page by adding valid details
	Then verify place of destination by adding 'XI' and 'Defra'
	When I click on the review and submit application hyperlink
	And I am taken to Check your answers page
	Then I can see the answers I provided for place of origin '<origin>', place of dispatch 'Not entered' and place of loading 'Not entered' (and optional region if provided) 'Not entered'
	Then I am on check your answers page to update 'Place of origin' section
	And I have unticked skip on the main page of place of origin
	When complete place of origin with 'GB','GB', 'Defra eTrade', 'GB', 'Defra eTrade' and continue
	Then I can see the answers I provided for place of origin '<origin>', place of dispatch '<dispatch>' and place of loading '<loading>' (and optional region if provided) '<region>'

Examples:
	| logininfo | reference      | certificate | commodityNumber | noofidentification | CountryOfOrigin | origin              | region | dispatch                                    | loading                                     |
	| exporter  | acceptancetest | EHC8361     | 030231          | 1                  | GB              | United Kingdom (GB) | GB-0   | Defra eTrade Exporters LTD (Hertsmere, HA8) | Defra eTrade Exporters LTD (Hertsmere, HA8) |

Scenario: Exporter decides to skip the place of origin
	Given that I navigate to the DEFRA application
	When setup an application with all tasks via backend
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And application page is displayed
	And search for a created application
	And user clicks the view application and verify
	When I click on the review and submit application hyperlink
	And I am taken to Check your answers page
	Then I am on check your answers page to update 'Place of origin' section
	And I remove the place of origin data and skip
	Then I can see the answers I provided for place of origin '<origin>', place of dispatch '<dispatch>' and place of loading '<loading>' (and optional region if provided) '<region>'

Examples:
	| logininfo | reference      | certificate | commodityNumber | noofidentification | CountryOfOrigin | origin              | region		  | dispatch    | loading     |
	| exporter  | acceptancetest | EHC8361     | 030231          | 1                  | GB              | United Kingdom (GB) | Not entered   | Not entered | Not entered |

Scenario: All "change" links enable exporter to access relevant pages for place of origin
	Given that I navigate to the DEFRA application
	When setup an application with all tasks via backend
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And application page is displayed
	And search for a created application
	And user clicks the view application and verify
	When I click on the review and submit application hyperlink
	And I am taken to Check your answers page
	Then I am on check your answers page to update 'Place of origin' section
	When I press save and continue
	And I am taken to Check your answers page
	Then I am on check your answers page to update 'Region of origin' section
	When I press save and continue
	And I am taken to Check your answers page
	Then I am on check your answers page to update 'Place of dispatch' section
	And I am on place of dispatch page from place of origin
	When I press back from place of origin page
	And I am taken to Check your answers page
	Then I am on check your answers page to update 'Place of loading' section
	And I am on place of loading page from place of origin

Examples: 
	| logininfo |
	| exporter  |

	
