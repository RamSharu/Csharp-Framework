@Certifier
Feature: EditMeansOfTransport

As a certifier, I want to see validation messages on the Means of Transport

Scenario: Certifier - Validation Information for not selecting Means of transport without its required details
	Given that I navigate to the DEFRA application
	When setup an application with all tasks with skip funtion via backend
	And submit an application with skip funtion via backend
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And application page is displayed
	Then search for a created application
	When I click in to the created application	
	And edit means of transport and not selecting with '<transportCondition>','<meansOfTransport>'
	Then verify all validation Information for a means of transport '<transportCondition>','<meansOfTransport>' without its required details '<withoutRequiredDetail>'

	Examples:
	| logininfo | transportCondition | meansOfTransport | withoutRequiredDetail |
	| certifier |  Chilled           |				    | 						|
	#Validation on Means of Transport not entered any transport method
	| certifier |  Chilled           | Railway          | Identifier			|
	| certifier |  Chilled           | Road             | Vehicle registration	|
	| certifier |  Chilled           | Road             | Trailer number		|
	| certifier |  Chilled           | Road             | Country				|
	| certifier |  Chilled           | Airplane         | Flight number			|
	| certifier |  Chilled           | Vessel           | Ship name				|
	| certifier |  Chilled           | Vessel           | Flag state			|
	| certifier |  Chilled           | Vessel           | IMO Number			|


Scenario: Certifier - Validation Information for not selecting Means of transports condition
	Given that I navigate to the DEFRA application
	When setup an application with all tasks with skip funtion via backend
	And submit an application with skip funtion via backend
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And application page is displayed
	Then search for a created application
	When I click in to the created application	
	And edit means of transport and not selecting with '<transportCondition>','<meansOfTransport>'
	Then verify Validation Information for not selecting Means of transports condition

	Examples:
	| logininfo | transportCondition | meansOfTransport |
	| certifier |			         |				    | 