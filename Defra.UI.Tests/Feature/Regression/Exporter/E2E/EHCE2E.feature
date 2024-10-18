Feature: EHCE2E_ALL

As a Defra customer, I am able to create and submit a new application

Scenario Outline: Create and submit a new EHC application
	Given that I navigate to the DEFRA application
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And application page is displayed
	When start a new application and click start now
	And enter a unique application reference '<reference>' and continue
	And select certificate for your export '<EHCNumber>' and continue
	And select commodity '<commodityNumber>' and continue
	And add '<EHCNumber>' data and submit
	Then verify certificate '<reference>' has been added successfully
	 
Examples:
	| logininfo | reference         | EHCNumber | commodityNumber |
	| exporter  | automationE2E8361 | EHC8361   | 030231          |


Examples:
	| logininfo | reference         | EHCNumber | commodityNumber |
	| exporter  | automationE2E8361 | EHC8361   | 030231          |
	| exporter  | automationE2E8305 | EHC8305   | 230910          |
	| exporter  | automationE2E8368 | EHC8368   | 020210          |
	| exporter  | automationE2E8369 | EHC8369   | 02068099        |
	| exporter  | automationE2E8324 | EHC8324   | 230910          |
	| exporter  | automationE2E8350 | EHC8350   | 151710          |
	| exporter  | automationE2E8325 | EHC8325   | 230910          |
	| exporter  | automationE2E8461 | EHC8461   | 1501            |
	| exporter  | automationE2E8333 | EHC8333   | 230910          |
	| exporter  | automationE2E8328 | EHC8328   | 41019000        |
	| exporter  | automationE2E8370 | EHC8370   | 1501            |
	| exporter  | automationE2E8364 | EHC8364   | 03089010        |
	| exporter  | automationE2E8371 | EHC8371   | 020713          |
	| exporter  | automationE2E8390 | EHC8390   | 3503            |
	| exporter  | automationE2E8391 | EHC8391   | 04090000        |
	| exporter  | automationE2E8383 | EHC8383   | 160100          |
	| exporter  | automationE2E8385 | EHC8385   | 160232          |
	| exporter  | automationE2E8467 | EHC8467   | 040690          |
	| exporter  | automationE2E8435 | EHC8435   | 0105120         |