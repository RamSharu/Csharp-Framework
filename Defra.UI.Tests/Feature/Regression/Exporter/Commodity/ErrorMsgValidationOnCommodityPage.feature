@Regression
Feature: Error Message Validation on Commodity page
 
As a Defra customer, I should get the error message in commodity page when filled with all mandatory fields except the pacakage count,
I should get the error message in commodity page when filled with all mandatory fields except the package type,
I should get the error message in commodity page when filled with all mandatory fields except the Net Weight and
I should get the error message in commodity page when filled with all mandatory fields except the Weight Unit

Scenario Outline: Add Commodity with all mandatory fields but without specific mandatory field
	Given that I navigate to the DEFRA application
	When sign in with valid credentials with logininfo '<logininfo>'
	Then check the user is '<logininfo>'
	And application page is displayed
	When start a new application and click start now
	And enter a unique application reference '<reference>' and continue
	And select certificate for your export '<certificate>' and continue
	And select commodity '<commodityNumber>' and continue
	And add commodity <noofidentification> for '<certificate>' data without'<specificField>' and continue	 
	Then I verify validation error messages at the top of the Commodity page without '<specificField>'
	And Verify Skip validation error message and check box appears saying that I can select skip
    And I verify the error message is marked against the '<specificField>' 
		
Examples:
	| logininfo | reference      | certificate | commodityNumber | noofidentification | specificField |
	| exporter  | automationtest | EHC8361     | 030231          | 1                  | PkgCount     |
	| exporter  | automationtest | EHC8361     | 030231          | 1                  | PkgUnit       |
	| exporter  | automationtest | EHC8361     | 030231          | 1                  | Weight        |
	| exporter  | automationtest | EHC8361     | 030231          | 1                  | WeightUnit    |


	Scenario Outline: Skip validation (and checkbox) disappears from page where all mandatory details are populated
	Given that I navigate to the DEFRA application
	When sign in with valid credentials with logininfo '<logininfo>'
	Then check the user is '<logininfo>'
	And application page is displayed
	When start a new application and click start now
	And enter a unique application reference '<reference>' and continue
	And select certificate for your export '<certificate>' and continue
	And select commodity '<commodityNumber>' and continue
	When add commodity '<noofidentification>' for '<certificate>' data and continue 
	Then Verify the skip validation message (and checkbox) is removed 

	Examples:
	| logininfo | reference      | certificate | commodityNumber | noofidentification | specificField |
	| exporter  | automationtest | EHC8361     | 030231          | 1                  |     PkgCount  |        
	
