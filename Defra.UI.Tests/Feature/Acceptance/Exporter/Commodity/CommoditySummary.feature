@acceptance
Feature: CommoditySummary

As an exporter, I want the commodity data summary page to reflect the new skip functionality experience, so that I can modify commodity records and have the option to skip mandatory fields.

Background: 
	Given that I navigate to the DEFRA application

Scenario Outline: Skipped mandatory fields and optional fields within a commodity record are shown as "Not Entered" when left blank
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And application page is displayed
	When start a new application and click start now
	And enter a unique application reference '<reference>' and continue
	And select certificate for your export '<certificate>' and continue
	Then select commodity '<commodityNumber>' and continue
	And I have left some mandatory fields blank and chosen to skip
    When I expand the commodity record on the review commodities page
    Then I can see the sections that were left blank labelled as 'Not entered'

Examples:
	| logininfo | reference			| certificate | commodityNumber | noofidentification | 
	| exporter  | acceptanceSkip	| EHC8361     | 030231          | 1                  |

Scenario Outline: Skipped mandatory fields and optional fields via change/copy a commodity record are shown as "Not Entered" when left blank
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And application page is displayed
	When start a new application and click start now
	And enter a unique application reference '<reference>' and continue
	And select certificate for your export '<certificate>' and continue
	Then select commodity '<commodityNumber>' and continue
	And I have left some mandatory fields blank and chosen to skip
	When I click 'Change' 
	Then I have left some mandatory fields blank and chosen to skip
    When I expand the commodity record on the review commodities page
    Then I can see the sections that were left blank labelled as 'Not entered'

Examples:
	| logininfo | reference			| certificate | commodityNumber | noofidentification | 
	| exporter  | acceptanceSkip	| EHC8361     | 030231          | 1                  |

Scenario Outline: Selecting 'Change' on a skipped commodity record 
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And application page is displayed
	When start a new application and click start now
	And enter a unique application reference '<reference>' and continue
	And select certificate for your export '<certificate>' and continue
	Then select commodity '<commodityNumber>' and continue
	And I have left some mandatory fields blank and chosen to skip
	When I click 'Change' 
	Then I can see the skip checkbox is checked

Examples:
	| logininfo | reference			| certificate | commodityNumber | noofidentification | 
	| exporter  | acceptanceSkip	| EHC8361     | 030231          | 1                  |

Scenario Outline: Selecting 'Change' on a commodity record with all mandatory fields filled in
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And application page is displayed
	When start a new application and click start now
	And enter a unique application reference '<reference>' and continue
	And select certificate for your export '<certificate>' and continue
	Then select commodity '<commodityNumber>' and continue
	Then add commodity '<noofidentification>' for '<certificate>' data and continue  
	And verify commodity has been added successfully
	When I click on the manage commodities link from task list page
	When I click 'Change' 
    Then I can see that the skip checkbox is still not there
	
Examples:
	| logininfo | reference			| certificate | commodityNumber | noofidentification | 
	| exporter  | acceptanceSkip	| EHC8361     | 030231          | 1                  |

Scenario Outline: Selecting 'Copy' on a skipped commodity record
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And application page is displayed
	When start a new application and click start now
	And enter a unique application reference '<reference>' and continue
	And select certificate for your export '<certificate>' and continue
	Then select commodity '<commodityNumber>' and continue
	And I have left some mandatory fields blank and chosen to skip
	When I click 'Copy' 
	Then I can see the skip checkbox is unchecked

Examples:
	| logininfo | reference			| certificate | commodityNumber | noofidentification | 
	| exporter  | acceptanceSkip	| EHC8361     | 030231          | 1                  |

Scenario Outline: Selecting 'Copy' on a commodity record with all mandatory fields filled in
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And application page is displayed
	When start a new application and click start now
	And enter a unique application reference '<reference>' and continue
	And select certificate for your export '<certificate>' and continue
	Then select commodity '<commodityNumber>' and continue
	Then add commodity '<noofidentification>' for '<certificate>' data and continue  
	And verify commodity has been added successfully
	When I click on the manage commodities link from task list page
	When I click 'Copy' 
    Then I can see that the skip checkbox is still not there

Examples:
	| logininfo | reference			| certificate | commodityNumber | noofidentification | 
	| exporter  | acceptanceSkip	| EHC8361     | 030231          | 1                  |