
@Regression @SmokeTest @Common
Feature: Account

As a Defra customer able to Sign in and Sign out with Valid credintials

Background: 
	Given that I navigate to the DEFRA application
	
Scenario: Expoter
	Then sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'

	@EnvCheck @Common
	Examples: 
	| logininfo |
	| exporter  |

Scenario: Certifier
	Then sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'

	@EnvCheck @Common
	Examples: 
	| logininfo |
	| certifier |


