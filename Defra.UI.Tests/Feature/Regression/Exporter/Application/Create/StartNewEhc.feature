@Exporter
Feature: Start new EHC - Enter application reference

As an exporter, I am able to input a valid reference number on start new ehc page to create a new application

Scenario Outline: Add valid application reference number
	Given that I navigate to the DEFRA application
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And application page is displayed
	And I start a new application from applications home page
	And I click on start now button from Ehc New Landing page
	And I am on start new Ehc page to add a new application reference
	When I add a valid application reference '<appReference>'
	And I click on save and continue button
	Then The application reference is successfully saved as I am taken to the certificate look up page
Examples: 
	| logininfo | appReference              |
	| exporter  | TestTwentyFiveCharacterss |
	| exporter  | 1234567890123456789012345 |
	| exporter  | CharAndNumbers12345       |
	| exporter  | Test space 123 -._/		|
	| exporter  | SpecialChars -._/12       |
	| exporter  | -._/- ._/12				|

Scenario Outline: Add invalid application reference number
	Given that I navigate to the DEFRA application
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And application page is displayed
	And I start a new application from applications home page
	And I click on start now button from Ehc New Landing page
	And I am on start new Ehc page to add a new application reference
	Then I can see validation message upon entering invalid application reference
	| appReference			  |
	| T!"$^*(){}[];:@',\|#~<> |
	| Test_{}[]				  |
	| Test%					  |
	| Test£					  |
	| Test&					  |
	| Test%&£				  |
	| Test\					  |
	| Test  doubleSpace		  |
Examples: 
	| logininfo | 
	| exporter  |

Scenario Outline: Blank reference number
	Given that I navigate to the DEFRA application
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And application page is displayed
	And I start a new application from applications home page
	And I click on start now button from Ehc New Landing page
	And I am on start new Ehc page to add a new application reference
	When I leave the application reference blank and save
	Then I can see that error message for blank application reference is displayed
Examples: 
	| logininfo |
	| exporter  |