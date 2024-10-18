@Exporter
Feature: Departure And Arrival
As a Defra customer, I am able to complete Departure and Arrival section

Scenario Outline: Complete Departure And Arrival
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
	When I navigate to departure and arrival page
	And complete Departure And Arrival dates
	Then verify Departure And Arrival section has been added successfully

	Examples:
	| logininfo | reference      | certificate | commodityNumber | noofidentification |
	| exporter  | automationtest | EHC8361     | 030231          | 1                  |

Scenario Outline: Departure And Arrival complete with and without choosing skip
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
	When I navigate to departure and arrival page
	And complete Departure And Arrival dates with '<skipcheckbox>'
	Then verify Departure And Arrival section has been added successfully

	Examples:
	| logininfo | reference      | certificate | commodityNumber | noofidentification | skipcheckbox |
	| exporter  | automationtest | EHC8361     | 030231          | 1                  | Yes          |
	| exporter  | automationtest | EHC8361     | 030231          | 1                  | No           |

Scenario Outline: Departure And Arrival validation message information
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
	When I navigate to departure and arrival page
	And complete Departure And Arrival dates with '<skipcheckbox>'
	Then verify Departure And Arrival validation message information

	Examples:
	| logininfo | reference      | certificate | commodityNumber | noofidentification | skipcheckbox		|
	| exporter  | automationtest | EHC8361     | 030231          | 1                  | Message information |

Scenario Outline: Departure and Arrival skip check box ticked verify after skipping the departure and arrival date
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
	When I navigate to departure and arrival page
	And complete Departure And Arrival dates with '<skipcheckbox>'
	And verify Departure And Arrival section has been added successfully
	And I click back Departure and Arrival to verify skip check box still ticked

	Examples:
	| logininfo | reference      | certificate | commodityNumber | noofidentification | skipcheckbox |
	| exporter  | automationtest | EHC8361     | 030231          | 1                  | Yes          |

	Scenario Outline: Departure And Arrival date validation Information verify
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
	When I navigate to departure and arrival page
	And complete with '<departureValue>' And '<arrivalValue>'
	Then verify Departure And Arrival '<validationError>' Information

	Examples:
	| logininfo | reference      | certificate | commodityNumber | noofidentification | departureValue | arrivalValue | validationError                 |
	| exporter  | automationtest | EHC8361     | 030231          | 1                  | FutureDate     | Empty        | Enter an estimated arrival date |
	| exporter  | automationtest | EHC8361     | 030231          | 1                  | Empty          | FutureDate   | Enter a departure date          |