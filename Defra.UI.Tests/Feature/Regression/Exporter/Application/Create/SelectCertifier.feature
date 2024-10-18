@Exporter
Feature: Select Certifier


As a Defra customer, I am able to Select Certifier

Scenario Outline: Select Certifier
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
	When navigate to select certifier page
	And select certifier '<certifierName>' and continue
	Then verify certifier has been added successfully

	Examples: 
	| logininfo | reference      | certificate | commodityNumber | noofidentification | certifierName	|
	| exporter  | automationtest | EHC8361     | 030231          | 1                  | ABC				|