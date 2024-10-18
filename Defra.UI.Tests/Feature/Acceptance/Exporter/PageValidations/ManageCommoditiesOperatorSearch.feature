﻿@acceptance
Feature: ManageCommoditiesOperatorSearch

As a Defra customer, I am able to see validation when missing fields for approved establishments operator search

Scenario Outline: Missing fields for approval number search
	Given that I navigate to the DEFRA application
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And application page is displayed
	And start a new application and click start now
	And enter a unique application reference '<reference>' and continue
	And select certificate for your export '<certificate>' and continue
	And select commodity '<commodityNumber>' and continue
	And select a manufacturing plant
	And select a country 
	When search by approval number '<approvalnumber>'
	Then search by operator name '<operatorname>'
	And approval number alerts are cleared after searching by '<operatorname>'

	Examples: 
	| logininfo | reference     | certificate | commodityNumber | noofidentification | approvalnumber | operatorname |
	| exporter  | emptyboth     | EHC8361     | 030231          | 1                  | empty          | empty        | 
	| exporter  | emptyapproval | EHC8361     | 030231          | 1                  | empty          | Karro        | 
	| exporter  | emptyoperator | EHC8361     | 030231          | 1                  | GBVAT4556      | empty        | 
	| exporter  | noneempty     | EHC8361     | 030231          | 1                  | GBVAT4556      | Karro        | 


Scenario Outline: Missing fields for operator name search
	Given that I navigate to the DEFRA application
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And application page is displayed
	And start a new application and click start now
	And enter a unique application reference '<reference>' and continue
	And select certificate for your export '<certificate>' and continue
	And select commodity '<commodityNumber>' and continue
	And select a manufacturing plant
	And select a country 
	When search by operator name '<operatorname>'
	Then search by approval number '<approvalnumber>'
	And operator name alerts are cleared after searching by '<approvalnumber>'

	Examples: 
	| logininfo | reference     | certificate | commodityNumber | noofidentification | operatorname | approvalnumber |
	| exporter  | emptyboth     | EHC8361     | 030231          | 1                  | empty        | empty          | 
	| exporter  | emptyoperator | EHC8361     | 030231          | 1                  | empty        | 2060           | 
	| exporter  | emptyapproval | EHC8361     | 030231          | 1                  | defra        | empty          |
	| exporter  | noneempty     | EHC8361     | 030231          | 1                  | defra        | 2060           |  


Scenario Outline: No selection from results
	Given that I navigate to the DEFRA application
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And application page is displayed
	And start a new application and click start now
	And enter a unique application reference '<reference>' and continue
	And select certificate for your export '<certificate>' and continue
	And select commodity '<commodityNumber>' and continue
	And select a manufacturing plant
	And select a country 
	When search by approval number '<approvalnumber>'
	Then I click save and continue
	And organisation alert is thrown
	When search by operator name '<operatorname>'
	Then I click save and continue
	And organisation alert is thrown

	Examples:
	| logininfo | reference   | certificate | commodityNumber | noofidentification | approvalnumber | operatorname |
	| exporter  | noselection | EHC8361     | 030231          | 1                  | GBVAT4556      | karro        |