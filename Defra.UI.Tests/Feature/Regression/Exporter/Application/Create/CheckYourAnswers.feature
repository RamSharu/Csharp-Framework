@Exporter
Feature: Check your answers

As a Defra customer, I am able to review the inputs to the new application that is being created and update the inputs where necessary

Scenario Outline: Check your answers and update the sections
	Given that I navigate to the DEFRA application
	When setup an application with all tasks via backend
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And application page is displayed
	And search for a created application
	And user clicks the view application and verify application reference
	When I click on the review and submit application hyperlink
	And I am taken to Check your answers page
	Then I review the commodities section by clicking on the change commodities link
	And I am on check your answers page to update 'Gross weight' section
	And I update the gross weight section with gross weight amount '100' and gross weight unit 'KTN'
	And I am on check your answers page to update 'Goods certified as' section
	And I update the goods certified as section by selecting 'Human consumption' radio option
	And I am on check your answers page to update 'Container number/seal number' section
	And I update the Container number/seal number section with container number 'BICU9876543' and seal number '543210'
	And I am on check your answers page to update 'Purpose of export' section
	And I update the purpose of export section by selecting 'Re-entry consignment' radio option
	And I am on check your answers page to update 'Accompanying documents' section
	And I can update document type '740' reference 'Test' and attach documents in the documents section
	And I am on check your answers page to update 'Consignor or Exporter' section
	And I update the consignor or exporter section with the consignor 'Karro Food'
	And I am on check your answers page to update 'Consignee or Importer' section
	And I update the consignee or importer section with the consignee 'Karro Food' and country 'XI'
	And I am on check your answers page to update 'Certifier' section
	And I update the certifier section with the certifier 'RajaCertifier'
	And I am on check your answers page to update 'Region of certification' section
	And I update the region of certification section by selecting 'Wales'
	And I am on check your answers page to update 'Responsible for load' section
	And I update the responsible for load section with the inputs 'XI' and country 'karro food'
	And I am on check your answers page to update 'Departure and arrival' section
	And I update the departure and arrival section
	And I am on check your answers page to update 'Place of origin' section
	And I update the place of origin section with country of origin 'GB' region of origin 'GB-04'
	#And I click on the review and submit application hyperlink to update 'Entry border control post' section
	And I am on check your answers page to update 'Means of transport' section
	And I update the transport conditon
	And I am on check your answers page to update 'Place of destination' section
	And I remove and add place of destination with country 'XI' and place 'Defra'
	And I am taken to Check your answers page
	And I proceed to submit the updated application
	And The submitted application is displayed on the application page
	Examples: 
	| logininfo |
	| exporter  |

Scenario Outline: Check your answers page has the same answers that were entered before on Place of origin section
	Given that I navigate to the DEFRA application
	And setup an application with all tasks via backend
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And application page is displayed
	And search for a created application
	And user clicks the view application and verify application reference
	When I click on the review and submit application hyperlink
	And I am taken to Check your answers page
	Then I am on check your answers page to update 'Place of origin' section
	And I get place of origin data from place of origin page
	And Place of origin details are same on check your answers page and place of origin page

	Examples: 
	| logininfo |
	| exporter  |

Scenario Outline: Change links next to place of origin sections takes us to place of origin main page
	Given that I navigate to the DEFRA application
	And setup an application with all tasks via backend
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And application page is displayed
	And search for a created application
	And user clicks the view application and verify application reference
	And I click on the review and submit application hyperlink
	And I am taken to Check your answers page
	When I click on change link next to 'Country of origin' on Check your answers page
	Then I am taken to place of origin main page
	When I click on change link next to 'Region of origin' on Check your answers page
	Then I am taken to place of origin main page
	When I click on change link next to 'Place of dispatch' on Check your answers page
	Then I am taken to place of origin main page
	When I click on change link next to 'Place of loading' on Check your answers page
	Then I am taken to place of origin main page

	Examples: 
	| logininfo |
	| exporter  |