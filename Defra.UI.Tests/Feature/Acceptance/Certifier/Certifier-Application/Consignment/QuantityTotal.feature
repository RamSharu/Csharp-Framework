@acceptance
Feature: QuantityTotal

As a Certifier edit the Quantity Total and check validations


Scenario: Certifier edit Net Quantity Total
	Given that I navigate to the DEFRA application
	When setup an application with all tasks via backend '<logininfo>'
	And submit an application via backend
	And create a certificate via backend
	Then sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And on certifier application page is displayed
	And search for a created application
	When I click in to the created application
	When click to expand the Commodity Details Panel
	When edit the Quantity Totals in certifier commodity details and save
	| grossWeightAmount | grossWeightUnit | errorMessage																			|
	| 					| KGM             | Enter the gross weight of the commodities												|
	| 5                 | KGM             | The gross weight of the commodities cannot be less than the net weight					|
	| 15                |                 | Select the unit of weight for the commodities											|
	|					|                 | Enter the gross weight of the commodities-Select the unit of weight for the commodities	|

Examples:
	| logininfo | EHCNumber         |
	| certifier | EHC8361           |              
