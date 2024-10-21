@acceptance
Feature: Gross Weight

As a exporter, I am able to add a decimal as Gross Weight

Scenario Outline: Exporter can mark gross weight with decimal points during application
	Given that I navigate to the DEFRA application
	Then sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And application page is displayed
	Then start a new application and click start now
	And enter a unique application reference '<reference>' and continue
	And select certificate for your export '<certificate>' and continue
	Then select commodity '<commodityNumber>' and continue
	Then add commodity '<noofidentification>' for '<certificate>' data and continue
	And verify commodity has been added successfully
	When complete Gross Weight as '<grossweightamount>' and '<grossweightunit>'
	Then verify Gross Weight has been added successfully
	And the value is saved with the decimal points '<grossweightamount>'

	Examples: 
	| logininfo | reference      | certificate | commodityNumber | noofidentification | grossweightamount | grossweightunit |
	| exporter  | acceptanceTest | EHC8361     | 030231          | 1                  | 10.11             | KGM             |


Scenario Outline: Exporter can mark gross weight with decimal points from check your answers page
	Given that I navigate to the DEFRA application
	When sign in with valid credentials with logininfo '<logininfo>'
	Then check the user is '<logininfo>'
	And application page is displayed
	And start a new application and click start now
	And enter a unique application reference '<reference>' and continue
	And select certificate for your export '<certificate>' and continue
	And select commodity '<commodityNumber>' and continue
	And add '<certificate>' data
    Then I can see the apply section whereby the review and submit application hyperlink is clickable and this directs me to the check your answers page
    And I am able to review 'Gross weight'
	When add Gross Weight as '<grossweightamount>' and '<grossweightunit>'
	And I am taken to Check your answers page
	And I press back from check your answers page
	Then verify Gross Weight has been added successfully
	And the value is saved with the decimal points '<grossweightamount>'

	Examples: 
	| logininfo | reference      | certificate | commodityNumber | noofidentification | grossweightamount | grossweightunit |
	| exporter  | acceptanceTest | EHC8361     | 030231          | 1                  | 10.11             | KGM             |

