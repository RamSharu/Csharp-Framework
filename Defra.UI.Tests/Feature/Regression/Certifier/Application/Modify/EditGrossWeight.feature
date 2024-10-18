@Regression
Feature: EditGrossWeight

As a Certifier edit the Gross Weight
As a Certifier, I should not see the Skip functionality

Scenario: On Certifier edit Gross Weight
	Given that I navigate to the DEFRA application
	When setup an application with all tasks via backend '<logininfo>'
	And submit an application via backend
	And create a certificate via backend
	Then sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And on certifier application page is displayed
	And search for a created application
	And I click in to the created application
	And I change Gross Weight to '<grossWeightAmount>' and '<grossWeightUnit>'
	And I verify changed Gross Weight as '<grossWeightAmount>'

	Examples: 
	| logininfo | grossWeightAmount | grossWeightUnit |
	| certifier | 20                | KGM             |

Scenario: Certifier - Skip functionality cannot be accessed on gross weight
	Given that I navigate to the DEFRA application
	When setup an application with all tasks with skip funtion via backend
	And submit an application with skip funtion via backend
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And application page is displayed
	Then search for a created application
	When I click in to the created application
	And I click edit on application gross weight
	Then verify skip functionality no longer on certifier page

	Examples:
	| logininfo |
	| certifier |

Scenario Outline: On Certifier edit Gross Weight with decimal places
	Given that I navigate to the DEFRA application
	And setup an application with all tasks via backend '<logininfo>'
	And submit an application via backend
	And create a certificate via backend
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And on certifier application page is displayed
	And search for a created application
	When I click in to the created application
	Then I change Gross Weight to '<grossWeightInput>' and '<grossWeightUnit>'
	And I verify changed Gross Weight as '<grossWeightOutput>'
	
	Examples: 
	| logininfo | grossWeightInput | grossWeightOutput | grossWeightUnit |
	| certifier | 100.0000000	   | 100               | KGM             |
	| certifier | 100.9			   | 100.9             | KGM             |
	| certifier | 100.99           | 100.99            | KGM             |
	| certifier | 100.999          | 100.99            | KGM             |