@acceptance
Feature: CancelAndReplace

As an exporter I want to check that the original and new applications are linked on the application dashboard when an application has been cancelled and replaced

Background: 
	Given that I navigate to the DEFRA application

Scenario: Exporter can view link from the original certificate to the replacement application on the application dashboard
	And sign in with valid credentials with logininfo 'exporter'
	And check the user is 'exporter'
	And application page is displayed
	Then select 'status' filter from applications page
	Then check the below table with 'status' works correctly 'pending replacement'
	Then I can see that the original certificate is 'PENDING REPLACEMENT'
    And I can view a link to View Replacement application


Scenario: Exporter can view link from the replacement application to the original certificate on the application dashboard 
	And sign in with valid credentials with logininfo 'exporter'
	And check the user is 'exporter'
	And application page is displayed
	Then select 'status' filter from applications page
	Then check the below table with 'status' works correctly '<app>'
	Then I can see that the original certificate is '<status>'
    And I can view a link to View Original application for '<app>'

	Examples: 
	| app         | status      |
	| replaced    | REPLACED    |
	| replacement | REPLACEMENT |

