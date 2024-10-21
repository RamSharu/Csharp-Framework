@Regression
Feature: EditDepartureAndArrival

As a Certifier edit the Departure and Arrival
As a Certifier, I should not see the Skip functionality
As a Certifier I verify validation for no Departure and Arrival date

Scenario: On Certifier edit the Departure and Arrival
	Given that I navigate to the DEFRA application
	When setup an application with all tasks via backend '<logininfo>'
	And submit an application via backend
	And create a certificate via backend
	Then sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And on certifier application page is displayed
	And search for a created application
	And I click in to the created application
	And click on Part1 'Transport' tab
	And I change Depature and Arrival date
	And I verify changed Depature and Arrival date

	Examples: 
	| logininfo | 
	| certifier | 

Scenario: Certifier - Skip functionality cannot be accessed on the departure and arrival page
	Given that I navigate to the DEFRA application
	When setup an application with all tasks with skip funtion via backend
	And submit an application with skip funtion via backend
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And application page is displayed
	Then search for a created application
	When I click in to the created application
	And click on Part1 'Transport' tab
	And I click edit on application departure and arrival
	Then verify skip functionality no longer on certifier page

	Examples:
	| logininfo |
	| certifier |

	Scenario: Certifier - verify validation information continuing without Departure and Arrival date
	Given that I navigate to the DEFRA application
	When setup an application with all tasks with skip funtion via backend
	And submit an application with skip funtion via backend
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And application page is displayed
	Then search for a created application
	When I click in to the created application
	And click on Part1 'Transport' tab
	And I continue with '<depatureDate>' and '<arrivalDate>'
	And I verify Departure and Arrival '<validationInformation>'

	Examples: 
	| logininfo | depatureDate | arrivalDate | validationInformation           |
	| certifier |              |  True       | Enter a departure date          |
	| certifier |  True        |             | Enter an estimated arrival date |
