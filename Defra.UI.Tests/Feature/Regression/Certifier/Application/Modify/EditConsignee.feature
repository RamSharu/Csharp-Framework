@Certifier
Feature: EditConsignee

As a Defra customer able to edit Consignee on Certifier side

Scenario: Edit Consignee on Certifier side
	Given setup an application with all tasks via backend '<logininfo>'
	And submit an application via backend
	And create a certificate via backend
	When that I navigate to the DEFRA application
	Then sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And on certifier application page is displayed
	And search for a created application
	And I click in to the created application
	And click on Part1 'Persons Involved' tab
	And edit Consignee details to '<Country>','<NewConsignee>'
	And Verify changed Consignee '<NewConsignee>' details

	Examples: 
	| logininfo | Country | NewConsignee   |
	| certifier | XI      | KARRO FOOD LTD |


