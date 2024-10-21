@Exporter @SmokeTest
Feature: PreviewCertificate

As a Defra customer, I am able to click the Preview Certificate link and download the certificate

Scenario Outline: Preview Certificate in new application
	Given that I navigate to the DEFRA application
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And application page is displayed
	And start a new application and click start now
	And enter a unique application reference '<reference>' and continue
	And select certificate for your export '<certificate>' and continue
	And select commodity '<commodityNumber>' and continue
	And add commodity '<noofidentification>' for '<certificate>' data and continue  
	And verify commodity has been added successfully
	When I click on the preview certificate link
	Then I can see the certificate details and a link to download the certificate

Examples: 
	| logininfo | reference      | certificate | commodityNumber | noofidentification |
	| exporter  | automationtest | EHC8361     | 030231          | 1                  |

