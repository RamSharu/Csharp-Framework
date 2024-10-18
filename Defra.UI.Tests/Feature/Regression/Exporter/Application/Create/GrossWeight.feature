@Exporter
Feature: Gross Weight
As a Defra customer, I am able to complete Gross Weight section

Scenario Outline: Gross Weight
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

Examples:
	| logininfo | reference      | certificate | commodityNumber | noofidentification | grossweightamount | grossweightunit |
	| exporter  | automationtest | EHC8361     | 030231          | 1                  | 10                | KGM             |

Scenario Outline: On Exporter enter Gross Weight with decimal places
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
	When complete Gross Weight as '<grossWeightInput>' and '<grossweightunit>'
	Then verify Gross Weight has been added successfully
	And the value is saved with the decimal points '<grossWeightOutput>'

Examples:
	| logininfo | reference      | certificate | commodityNumber | noofidentification | grossWeightInput | grossWeightOutput | grossweightunit |
	| exporter  | multiplezeros  | EHC8361     | 030231          | 1                  | 100.0000000      | 100               | KGM             | 
	| exporter  | 1dp            | EHC8361     | 030231          | 1                  | 100.9	         | 100.9             | KGM             | 
	| exporter  | 2dp            | EHC8361     | 030231          | 1                  | 100.99	         | 100.99            | KGM             | 
	| exporter  | 3dp            | EHC8361     | 030231          | 1                  | 100.999          | 100.99            | KGM             | 



Scenario Outline: Gross weight against net weight validation
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
	Then verify Gross Weight validation displayed against Net Weight

Examples:
	| logininfo | reference      | certificate | commodityNumber | noofidentification | grossweightamount | grossweightunit |
	| exporter  | automationtest | EHC8361     | 030231          | 1                  | 1                 | KGM             |

Scenario Outline: Gross weight validation from check your answers page
	Given that I navigate to the DEFRA application
	When setup an application with all tasks via backend
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And application page is displayed
	And search for a created application
	And user clicks the view application and verify application reference
	When I click on the review and submit application hyperlink
	And I am taken to Check your answers page
	Then I am on check your answers page to update 'Commodities' section
	And update '<netWeight>' amount and go to check your answers page
	Then verify Gross Weight validation displayed against Net Weight

Examples:
	| logininfo | netWeight |
	| exporter  | 500       |

Scenario Outline: Gross weight validation remain until save and continue is clicked
	Given that I navigate to the DEFRA application
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And application page is displayed
	When start a new application and click start now
	And enter a unique application reference '<reference>' and continue
	And select certificate for your export '<certificate>' and continue
	And select commodity '<commodityNumber>' and continue
	And add commodity '<noofidentification>' for '<certificate>' data and continue
	And I click on gross weight link from task list page
	When I click save and continue button without adding gross weight amount and units
	Then verify skip error validation displayed on page "Select if you have answered as many questions as you can"

Examples:
	| logininfo | reference      | certificate | commodityNumber | noofidentification |
	| exporter  | automationtest | EHC8361     | 030231          | 1                  |


Scenario Outline: Gross weight amount validation remain until save and continue is clicked
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
	Then verify Gross Weight amount validation displayed on page "Enter the gross weight of the commodities in the consignment."
	When I fill Gross Weight unit without clicking save and continue button
	Then verify Gross Weight amount validation displayed on page "Enter the gross weight of the commodities in the consignment."

Examples:
	| logininfo | reference      | certificate | commodityNumber | noofidentification | grossweightamount | grossweightunit |
	| exporter  | automationtest | EHC8361     | 030231          | 1                  |                   | KGM             |

Scenario Outline: Gross weight unit validation remain until save and continue is clicked
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
	Then verify Gross Weight unit validation displayed on page "Select the unit weight for the consignment."
	When I fill Gross Weight amount without clicking save and continue button
	Then verify Gross Weight unit validation displayed on page "Select the unit weight for the consignment."

Examples:
	| logininfo | reference      | certificate | commodityNumber | noofidentification | grossweightamount | grossweightunit |
	| exporter  | automationtest | EHC8361     | 030231          | 1                  | 10                |                 |


@Ignore
Scenario Outline: Gross Weight with Skip checkbox
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
	When complete Gross Weight as '<grossweightamount>', '<grossweightunit>' and '<skipcheckbox>'
	Then verify Gross Weight has been added successfully

Examples:
	| logininfo | reference      | certificate | commodityNumber | noofidentification | grossweightamount | grossweightunit | skipcheckbox |
	| exporter  | automationtest | EHC8361     | 030231          | 1                  |                   |                 | Yes          |
	| exporter  | automationtest | EHC8361     | 030231          | 1                  | 10                | KGM             | No           |

@Ignore
Scenario Outline: Gross Weight Skip validation message
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
	When complete Gross Weight as '<grossweightamount>', '<grossweightunit>' and '<skipcheckbox>'
	Then verify Gross Weight validation message information

Examples:
	| logininfo | reference      | certificate | commodityNumber | noofidentification | grossweightamount | grossweightunit | skipcheckbox |
	| exporter  | automationtest | EHC8361     | 030231          | 1                  |                   |                 | No           |
	| exporter  | automationtest | EHC8361     | 030231          | 1                  |                   | KGM             | No           |
	| exporter  | automationtest | EHC8361     | 030231          | 1                  | 10                |                 | No           |
