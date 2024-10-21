Feature: EHCE2E_EHC8383

As a Defra customer, I am able to create and submit a new application

Scenario Outline: Create and submit a new EHC application EHC8383
	Given that I navigate to the DEFRA application
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And application page is displayed
	When start a new application and click start now
	And enter a unique application reference '<reference>' and continue
	And select certificate for your export '<EHCNumber>' and continue
	And select commodity '<commodityNumber>' and continue
	And add '<EHCNumber>' data and submit
	Then verify certificate '<reference>' has been added successfully
	 
@Exporter @Pre
Examples:
	| logininfo | reference         | EHCNumber | commodityNumber |
	| exporter  | automationE2E8383 | EHC8383   | 160100          |