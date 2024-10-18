@Exporter
Feature: CompleteMeansofTransport
As a Defra customer, I am create an application and add Complete Means of Transport

Scenario Outline: CompleteMeansofTransport
	Given that I navigate to the DEFRA application
	Then sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	Then setup an application via backend
	Then I deeplink to the commodity selection page with certificate '<certificate>'
	Then select commodity '<commodityNumber>' and continue
	Then add commodity '<noOfIdentification>' for '<certificate>' data and continue  
	Then verify commodity has been added successfully
	Then verify means of transport page by adding valid details
	Then transport details added successfully
	
	Examples: 
	| logininfo | certificate | commodityNumber | noOfIdentification |
	| exporter  | 8361        | 030231          | 1                  |

	Scenario Outline: Complete MeansofTransport with Skip checkbox
	Given that I navigate to the DEFRA application
	Then sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	Then setup an application via backend
	Then I deeplink to the commodity selection page with certificate '<certificate>'
	Then select commodity '<commodityNumber>' and continue
	Then add commodity '<noOfIdentification>' for '<certificate>' data and continue  
	Then verify commodity has been added successfully
	Then complete means of transport with '<transportCondition>', '<meansOfTransport>' and '<skipcheckbox>'
	Then transport details added successfully
	
	Examples: 
	| logininfo | certificate | commodityNumber | noOfIdentification | transportCondition | meansOfTransport | skipcheckbox |
	| exporter  | 8361        | 030231          | 1                  | Chilled            | Railway          | No           |
	| exporter  | 8361        | 030231          | 1                  | Chilled            |                  | Yes          |
	| exporter  | 8361        | 030231          | 1                  |                    |                  | Yes          |
	| exporter  | 8361        | 030231          | 1                  | Chilled            | Multiple         | Yes          |
	| exporter  | 8361        | 030231          | 1                  | Chilled            | OneIncomplete    | Yes          |

	Scenario Outline: Verify MeansofTransport Skip validation message
	Given that I navigate to the DEFRA application
	Then sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	Then setup an application via backend
	Then I deeplink to the commodity selection page with certificate '<certificate>'
	Then select commodity '<commodityNumber>' and continue
	Then add commodity '<noOfIdentification>' for '<certificate>' data and continue  
	Then verify commodity has been added successfully
	Then complete means of transport with '<transportCondition>', '<meansOfTransport>' and '<skipcheckbox>'
	Then verify means of transport validation message information
	
	Examples: 
	| logininfo | certificate | commodityNumber | noOfIdentification | transportCondition | meansOfTransport | skipcheckbox |
	| exporter  | 8361        | 030231          | 1                  | Chilled            |                  | No           |
	| exporter  | 8361        | 030231          | 1                  | Chilled            | OneIncomplete    | No           |
	| exporter  | 8361        | 030231          | 1                  |                    | Railway          | No           |

Scenario Outline: Means Of Transport skip check box disappearance Checked after ticked  
	Given that I navigate to the DEFRA application
	Then sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	Then setup an application via backend
	Then I deeplink to the commodity selection page with certificate '<certificate>'
	Then select commodity '<commodityNumber>' and continue
	Then add commodity '<noOfIdentification>' for '<certificate>' data and continue  
	Then verify commodity has been added successfully
	Then complete means of transport with '<transportCondition>', '<meansOfTransport>' and '<skipcheckbox>'
	Then I can see means of transport skip checkbox has ticked and visible
	
	Examples: 
	| logininfo | certificate | commodityNumber | noOfIdentification | transportCondition | meansOfTransport | skipcheckbox |
	| exporter  | 8361        | 030231          | 1                  |                    |                  | Yes          |