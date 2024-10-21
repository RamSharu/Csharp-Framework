@Regression @SmokeTest @Common
Feature: LoginLogout

As a Defra customer, I am able to sign in and sign out with valid credentials

Background: 
	Given that I navigate to the DEFRA application
	
Scenario: SignIn
	Then sign in with valid credentials with logininfo '<logininfo>'
	
	Examples: 
	| logininfo |
	| exporter  |
	| certifier |

Scenario: SignOut
	Then sign in with valid credentials with logininfo '<logininfo>'
	And  click on signout button and verify the signout message

	Examples: 
	| logininfo |
	| exporter  |
	| certifier |


