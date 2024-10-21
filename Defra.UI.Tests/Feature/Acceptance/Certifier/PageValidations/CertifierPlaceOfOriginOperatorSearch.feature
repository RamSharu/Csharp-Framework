@acceptance
Feature: CertifierPlaceOfOriginOperatorSearch

As a Certifier, I am able to see validation when missing fields for my operator search

Scenario Outline: Missing fields for Place of dispatch approval number search
	Given setup an application with all tasks via backend '<logininfo>'
	And submit an application via backend
	And create a certificate via backend
	And that I navigate to the DEFRA application
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And on certifier application page is displayed
	And search for a created application
	And I click in to the created application
	And I remove place of origin details
	And select a place of dispatch
	When search by approval number '<approvalnumber>'
	Then search by operator name '<operatorname>'
	And approval number alerts are cleared after searching by '<operatorname>'

	Examples: 
	| logininfo | approvalnumber | operatorname |
	| certifier | empty          | empty        |
	| certifier | empty          | Karro        |
	| certifier | GBVAT4556      | empty        |
	| certifier | GBVAT4556      | Karro        |

Scenario Outline: Missing fields for Place of loading approval number search
	Given setup an application with all tasks via backend '<logininfo>'
	And submit an application via backend
	And create a certificate via backend
	And that I navigate to the DEFRA application
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And on certifier application page is displayed
	And search for a created application
	And I click in to the created application
	And I remove place of origin details
	And select a place of loading
	When search by approval number '<approvalnumber>'
	Then search by operator name '<operatorname>'
	And approval number alerts are cleared after searching by '<operatorname>'

	Examples: 
	| logininfo | approvalnumber | operatorname |
	| certifier | empty          | empty        |
	| certifier | empty          | Karro        |
	| certifier | GBVAT4556      | empty        |
	| certifier | GBVAT4556      | Karro        |

Scenario Outline: Missing fields for Place of dispatch operator name search
	Given setup an application with all tasks via backend '<logininfo>'
	And submit an application via backend
	And create a certificate via backend
	And that I navigate to the DEFRA application
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And on certifier application page is displayed
	And search for a created application
	And I click in to the created application
	And I remove place of origin details
	And select a place of dispatch
	When search by operator name '<operatorname>'
	Then search by approval number '<approvalnumber>'
	And operator name alerts are cleared after searching by '<approvalnumber>'
	
	Examples: 
	| logininfo | operatorname | approvalnumber |
	| certifier | empty        | empty          |
	| certifier | empty        | 2060           |
	| certifier | defra        | empty          |
	| certifier | defra        | 2060           |

Scenario Outline: Missing fields for Place of loading operator name search
	Given setup an application with all tasks via backend '<logininfo>'
	And submit an application via backend
	And create a certificate via backend
	And that I navigate to the DEFRA application
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And on certifier application page is displayed
	And search for a created application
	And I click in to the created application
	And I remove place of origin details
	And select a place of loading
	When search by operator name '<operatorname>'
	Then search by approval number '<approvalnumber>'
	And operator name alerts are cleared after searching by '<approvalnumber>'
	
	Examples: 
	| logininfo | operatorname | approvalnumber |
	| certifier | empty        | empty          |
	| certifier | empty        | 2060           |
	| certifier | defra        | empty          |
	| certifier | defra        | 2060           |

Scenario Outline: No selection from Place of dispatch results
	Given setup an application with all tasks via backend '<logininfo>'
	And submit an application via backend
	And create a certificate via backend
	And that I navigate to the DEFRA application
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And on certifier application page is displayed
	And search for a created application
	And I click in to the created application
	And I remove place of origin details
	And select a place of dispatch
	When search by approval number '<approvalnumber>'
	Then I click save and continue
	And organisation alert is thrown
	When search by operator name '<operatorname>'
	Then I click save and continue
	And organisation alert is thrown
	Examples: 
	| logininfo | approvalnumber | operatorname |
	| certifier | GBVAT4556      | karro        |

Scenario Outline: No selection from Place of loading results
	Given setup an application with all tasks via backend '<logininfo>'
	And submit an application via backend
	And create a certificate via backend
	And that I navigate to the DEFRA application
	And sign in with valid credentials with logininfo '<logininfo>'
	And check the user is '<logininfo>'
	And on certifier application page is displayed
	And search for a created application
	And I click in to the created application
	And I remove place of origin details
	And select a place of loading
	When search by approval number '<approvalnumber>'
	Then I click save and continue
	And organisation alert is thrown
	When search by operator name '<operatorname>'
	Then I click save and continue
	And organisation alert is thrown
	Examples: 
	| logininfo | approvalnumber | operatorname |
	| certifier | GBVAT4556      | karro        |