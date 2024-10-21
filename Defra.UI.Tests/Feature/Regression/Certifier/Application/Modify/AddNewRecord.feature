@Certifier
Feature: AddEditCommodityRecords

As a certifier, I am able to add and edit the commodity records for a submitted application. 
I also should not see the skip functionality as it is implemented for Exporter.

Scenario Outline: Certifier add new record
	Given setup an application with all tasks via backend '<logininfo>'
	And submit an application via backend
	And create a certificate via backend
	When that I navigate to the DEFRA application
	Then sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And on certifier application page is displayed
	And search for a created application
	When I click in to the created application
 	When add '<EHCNumber>' data for new commodity record 
	Then I verify new commodity record added successfully

Examples:
	| logininfo | EHCNumber | 
	| certifier | EHC8361   |

Scenario Outline: Certifier remove records and keep at list one record
	Given setup an application with all tasks via backend '<logininfo>'
	And submit an application via backend
	And create a certificate via backend
	When that I navigate to the DEFRA application
	Then sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And on certifier application page is displayed
	And search for a created application
	When I click in to the created application
 	When add '<EHCNumber>' data for new commodity record 
	And I remove first commodity record and keep one record
	Then I verify new commodity record added successfully

Examples:
	| logininfo | EHCNumber | 
	| certifier | EHC8361   |

Scenario Outline: Certifier - Skip functionality cannot be accessed on the commodities page
	Given that I navigate to the DEFRA application
	When setup an application with all tasks with skip funtion via backend
	And submit an application with skip funtion via backend
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And application page is displayed
	Then search for a created application
	When I click in to the created application
	And I click on application commodity details
	Then verify skip functionality no longer on certifier page

Examples:
	| logininfo |
	| certifier |

Scenario Outline: Validate error messages on continuing without adding commodity data through 'Add new'link
	Given that I navigate to the DEFRA application
	And setup an application with all tasks via backend '<logininfo>'
	And submit an application via backend
	And create a certificate via backend
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And on certifier application page is displayed
	And I search and click on the certificate to proceed to the certifier view page
	When I click Add new link in the commodity section to add a new commodity record
	And I click Save and continue button without adding mandatory fields
	Then I can see validation messages displayed for all the mandatory fields in the commodity identification data modal
Examples:
	| logininfo |
	| certifier |