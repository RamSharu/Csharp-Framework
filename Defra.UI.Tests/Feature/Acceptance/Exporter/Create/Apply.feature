@acceptance
Feature: Tasklist - Apply

As an exporter, I want the task list to show an "apply" section, so that it highlights I need to add additional info to tasks in order to progress with the application.

Background: 
	Given that I navigate to the DEFRA application

Scenario: Exporter can see a section called "Apply" whereby they cannot review and submit the application UNTIL all mandatory sections have been completed
	Then setup an application via backend
	And sign in with valid credentials with logininfo 'exporter'
	And check the user is 'exporter'
	And application page is displayed
	Then search for a created application
	Then user clicks the view application and verify
	Then I can see '. Apply'
	And I can see 'Once you have completed all required sections, review your answers and submit your application.' 
    And I can see 'Review and submit application'
    And the status of the section shows 'CANNOT START YET'

@DataSource:commodities.csv
Scenario: Exporter can see a section called "Apply" which I can access upon completing all mandatory sections
	When sign in with valid credentials with logininfo '<logininfo>'
	Then check the user is '<logininfo>'
	And application page is displayed
	And start a new application and click start now
	And enter a unique application reference '<reference>' and continue
	And select certificate for your export '<certificate>' and continue
	And select commodity '<commodityNumber>' and continue
	And add '<certificate>' data
    Then the status of the section shows 'NOT STARTED'
    And I can see 'You have completed all sections, you can now review and submit your answers'
	And I can see the apply section whereby the review and submit application hyperlink is clickable and this directs me to the check your answers page

@DataSource:commodities.csv
Scenario: Exporter can see a section called "Apply" which shows "COMPLETED" when the application has been submitted
	When sign in with valid credentials with logininfo '<logininfo>'
	Then check the user is '<logininfo>'
	And application page is displayed
	And start a new application and click start now
	And enter a unique application reference '<reference>' and continue
	And select certificate for your export '<certificate>' and continue
	And select commodity '<commodityNumber>' and continue
	And add '<certificate>' data and submit
	Then verify certificate '<reference>' has been added successfully
	And user clicks the view application and verify
	And I press back from check your answers page
	And the status of the section shows 'COMPLETE'

