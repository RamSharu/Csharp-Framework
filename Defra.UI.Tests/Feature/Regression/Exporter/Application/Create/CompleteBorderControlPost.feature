@Exporter
Feature: CompleteBorderControlPost
As a Defra customer, I am create an application and add Complete Border Control Post

Scenario Outline: CompleteBorderControlPost
	Given that I navigate to the DEFRA application
	Then sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	Then setup an application via backend
	Then I deeplink to the commodity selection page with certificate '<certificate>'
	Then select commodity '<commodityNumber>' and continue
	Then add commodity '<noOfIdentification>' for '<certificate>' data and continue  
	Then verify commodity has been added successfully
	Then verify border control page by adding valid details '<country>' with '<borderControlName>'
	Then border control details added successfully
	
	Examples: 
	| logininfo | certificate | commodityNumber | noOfIdentification | country | borderControlName		|
	| exporter  | 8361        | 030231          | 1                  | XI      | Belfast Port - DAERA   |

Scenario Outline: Complete BorderControlPost with Skip checkbox
	Given that I navigate to the DEFRA application
	Then sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	Then setup an application via backend
	Then I deeplink to the commodity selection page with certificate '<certificate>'
	Then select commodity '<commodityNumber>' and continue
	Then add commodity '<noOfIdentification>' for '<certificate>' data and continue  
	Then verify commodity has been added successfully
	Then verify border control page by adding valid details '<country>' with '<borderControlName>' and '<skipcheckbox>'
	Then border control details added successfully
	
	Examples: 
	| logininfo | certificate | commodityNumber | noOfIdentification | country | borderControlName    | skipcheckbox |
	| exporter  | 8361        | 030231          | 1                  |         |                      |      Yes     |

	Scenario Outline: BorderControlPost Skip validation message
	Given that I navigate to the DEFRA application
	Then sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	Then setup an application via backend
	Then I deeplink to the commodity selection page with certificate '<certificate>'
	Then select commodity '<commodityNumber>' and continue
	Then add commodity '<noOfIdentification>' for '<certificate>' data and continue  
	Then verify commodity has been added successfully
	Then verify border control page by adding valid details '<country>' with '<borderControlName>' and '<skipcheckbox>'
	Then verify Border Control Post validation message information
	
	Examples: 
	| logininfo | certificate | commodityNumber | noOfIdentification | country | borderControlName    | skipcheckbox |
	| exporter  | 8361        | 030231          | 1                  |         |                      |      No      |

	Scenario Outline: Check BorderControlPost skip function on Review Answers section
	Given that I navigate to the DEFRA application
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And setup an application with all tasks via backend
	Then I deeplink to the EHC summary page
	Then change Border Control Post with skip flag
	Then verify Border Control Post not entered on review page
	
	Examples: 
	| logininfo |
	| exporter  |