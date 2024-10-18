@Exporter
Feature: Region Of Certification
As a Defra customer, I am able to select Region of Certification
Scenario Outline: Select Region of Certification
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
	And navigate to region of certification page
	And select the region of certification '<region>' and continue
	And verify region of certification has been completed successfully

	Examples: 
	| logininfo | reference      | certificate | commodityNumber | noofidentification | region		|
	| exporter  | automationtest | EHC8361     | 030231          | 1                  | England 	|