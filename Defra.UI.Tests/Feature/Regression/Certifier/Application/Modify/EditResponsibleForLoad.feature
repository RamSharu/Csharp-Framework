@Certifier 
Feature: EditResponsibleForLoad

As a Certifier edit the application and change Responsible for Load

Scenario: Certifier edit responsoible for load
	Given setup an application with all tasks via backend '<logininfo>'
	And submit an application via backend
	And create a certificate via backend
	When that I navigate to the DEFRA application
	Then sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And on certifier application page is displayed
	And search for a created application
	When I click in to the created application
	When I change responsible for load
	Then I verify changed responsible for load

Examples:
	| logininfo |
	| certifier |


	Scenario: Certifier verify responsoible for load validation Information
	Given that I navigate to the DEFRA application
	When setup an application with all tasks via backend '<logininfo>'
	And submit an application via backend
	And create a certificate via backend
	Then sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And on certifier application page is displayed
	And search for a created application
	And I click in to the created application
	And click on Part1 'Persons Involved' tab
	And I edit and continue responsible for load '<organisationName>''<countryName>'
	And verify responsoible for load '<validationInformation>'

Examples:
	| logininfo | organisationName  | countryName |	validationInformation			               |
	| certifier | Defra				|			  | Select a country							   |
	| certifier |				    |	XI		  | Enter a responsible for load organisation name |