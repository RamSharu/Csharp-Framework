@acceptance
Feature: NetWeight

As an exporter, I want the ability to mark net weight as a decimal value, so that I can correctly specify the exact weight to ensure it matches correctly and won't be turned away at BCP's

Scenario Outline: Exporter can mark net weight with decimal points during application
    Given that I navigate to the DEFRA application
	When sign in with valid credentials with logininfo '<logininfo>'
	Then check the user is '<logininfo>'
	And application page is displayed
	And start a new application and click start now
	And enter a unique application reference '<reference>' and continue
	And select certificate for your export '<certificate>' and continue
	And select commodity '<commodityNumber>' and continue
	And add commodity '<noofidentification>' for '<certificate>' data with '<netWeight>' and continue
	Then the value is saved with the decimal points '<netWeight>' for 'New' record

	Examples: 
	| logininfo | reference      | certificate | commodityNumber | noofidentification | netWeight |
	| exporter  | acceptanceNet  | EHC8361     | 030231          | 1                  |  5.2	  |

Scenario Outline: Exporter can mark net weight with decimal points during application - change
Given that I navigate to the DEFRA application
	When sign in with valid credentials with logininfo '<logininfo>'
	Then check the user is '<logininfo>'
	And application page is displayed
	And start a new application and click start now
	And enter a unique application reference '<reference>' and continue
	And select certificate for your export '<certificate>' and continue
	And select commodity '<commodityNumber>' and continue
	And add commodity '<noofidentification>' for '<certificate>' data and continue
	And change commodity record fields '<productDesc>', '<packageCount>' and '<netWeight>'
	And verify commodity record has been changed successfully
	Then the value is saved with the decimal points '<netWeight>' for 'Change' record

	Examples: 
	| logininfo | reference      | certificate | commodityNumber | noofidentification | productDesc  | packageCount | netWeight |
	| exporter  | acceptanceNet  | EHC8361     | 030231          | 1                  | Auto Product | 5            | 5.2	    |


Scenario Outline: Exporter can mark net weight with decimal points during application - Copy
	Given that I navigate to the DEFRA application
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And application page is displayed
	And start a new application and click start now
	And enter a unique application reference '<reference>' and continue
	And select certificate for your export '<certificate>' and continue
	And select commodity '<commodityNumber>' and continue
	And add commodity '<noofidentification>' for '<certificate>' data and continue
	And I verify that commodity data is added successfully
    When copy commodity record fields '<productDesc>', '<packageCount>' and '<netWeight>'
	Then the value is saved with the decimal points '<netWeight>' for 'Copy' record

	Examples: 
	| logininfo | reference      | certificate | commodityNumber | noofidentification | productDesc  | packageCount | netWeight |
	| exporter  | acceptanceNet  | EHC8361     | 030231		     | 1                  | Auto Product | 5            | 5.2	    |

Scenario Outline: Exporter can mark net weight with decimal points from check your answers page
	Given that I navigate to the DEFRA application
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And application page is displayed
	When start a new application and click start now
	And enter a unique application reference '<reference>' and continue
	And select certificate for your export '<EHCNumber>' and continue
	And select commodity '<commodityNumber>' and continue
 	Then add '<EHCNumber>' data
	And I can see the apply section whereby the review and submit application hyperlink is clickable and this directs me to the check your answers page
	And I am able to review 'Commodities'
	Then I am able to amend the net weight of a commodity using a decimal point to '<netWeight>'
	And the value is saved with the decimal points '<netWeight>' for 'Change' record
	
	Examples: 
	| logininfo | reference         | EHCNumber | commodityNumber | netWeight |
	| exporter  | automationE2Etest | EHC8361   | 030231          | 5.2       |

