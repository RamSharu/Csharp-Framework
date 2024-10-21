@Exporter
Feature: AddConsignor

As a Defra customer, I am able to add Consignor in new application

Scenario Outline: Exporter or Consignor - E2E flow and page validations
	Given that I navigate to the DEFRA application
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And setup an application via backend
	And I deeplink to the commodity selection page with certificate '<certificate>'
	And select commodity '<commodityNumber>' and continue
	And add commodity '<noOfIdentification>' for '<certificate>' data and continue  
	And verify commodity has been added successfully
	When I click on the exporter or consignor link from task list page
	And I navigate to consignor page
	Then I can validate the fields '<ExporterConsignorCaption>' '<SelectExporterDescription>' '<SelectExporterLink>' on Exporter or Consignor page
	And I click on select exporter or consignor link to reach the Find an exporter or consignor page
	And I validate the fields on 'Find an exporter or consignor' page
	And I search and select the consignor '<consignorName>' to continue
	And I am on the consignor activity selection page
	And I can validate the fields on consignor activity selection page
	And I select a consignor activity from the list of activities
	And I click on save and continue from select activity page
	And I can see that the consignor and selected activity are displayed on the consignor page

Examples: 
	| logininfo | certificate | commodityNumber | noOfIdentification | consignorName |	ExporterConsignorCaption | SelectExporterDescription | SelectExporterLink			   |
	| exporter  | 8361        | 030231          | 1                  | Defra eTrade  |	Persons involved		 | send this consignment	 | Select an exporter or consignor |

Scenario Outline: Add consignor to new application
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
	When I click on the exporter or consignor link from task list page
	And I navigate to consignor page
	And add consignor '<consignorName>' and continue
	Then verify consignor has been added successfully

Examples:
	| logininfo | reference      | certificate | commodityNumber | noofidentification | consignorName |
	| exporter  | automationtest | EHC8361     | 030231          | 1                  | Defra eTrade  |

Scenario Outline: View consignor activity on consignor page
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
	When I click on the exporter or consignor link from task list page
	And I navigate to consignor page
	And search for consignor '<consignorName>'
	Then verify consignor activity is displayed on consignor page

Examples:
	| logininfo | reference      | certificate | commodityNumber | noofidentification | consignorName |
	| exporter  | automationtest | EHC8361     | 030231          | 1                  | Defra etrade  |

Scenario Outline: Change exporter or consignor activity
	Given that I navigate to the DEFRA application
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And setup an application via backend
	And I deeplink to the commodity selection page with certificate '<certificate>'
	And select commodity '<commodityNumber>' and continue
	And add commodity '<noOfIdentification>' for '<certificate>' data and continue  
	And verify commodity has been added successfully
	When I click on the exporter or consignor link from task list page
	And I navigate to consignor page
	And I add the consignor '<consignorName>' and consignor activity '<consignorActivity>' to complete the consignor section
	And I am taken to the consignor page
	Then I can click on change activity link on the consignor page
	And I choose the new activity '<consignorNewActivity>' on the select activity page
	And I click on save and continue from select activity page
	And I can see that the '<consignorNewActivity>' is displayed on the consignor page

Examples: 
	| logininfo | certificate | commodityNumber | noOfIdentification | consignorName | consignorActivity | consignorNewActivity |
	| exporter  | 8361        | 030231          | 1                  | Defra eTrade  | Animal exporter   | Slaughterhouse       |