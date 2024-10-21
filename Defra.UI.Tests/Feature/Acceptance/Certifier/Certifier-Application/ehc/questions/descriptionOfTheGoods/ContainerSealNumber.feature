Feature: ContainerSealNumber

As a Certifier edit delete the current entary and add new Container Seal Number entry and save

Scenario: Certifier delete Container Seal Number Entry
	Given that I navigate to the DEFRA application
	When setup an application with all tasks via backend '<logininfo>'
	And submit an application via backend
	And create a certificate via backend
	Then sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And on certifier application page is displayed
	And search for a created application
	When I click in to the created application
	When edit the Container Seal Number Tab delete current entry then add new entry and save '<containerNumber>' '<sealNumber>'

Examples:
	| logininfo | EHCNumber    | containerNumber | sealNumber |
	| certifier | EHC8361      | BICU1236451	 |  124356    |
