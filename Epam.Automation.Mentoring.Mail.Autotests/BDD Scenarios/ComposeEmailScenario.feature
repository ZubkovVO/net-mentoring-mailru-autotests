Feature: ComposeEmailScenario
	In order to be able to communicate with other email users
	As a user
	I want to be able to send and email

	Background: 
	Given I navigated to the home page

@mytag
Scenario Outline: Create, Save as Draft and Send an Email
	Given I logged in to email using <login> and <password>
	And I have composed an email
	When I send it from drafts
	Then It should be sent
	Examples:
	| login              | password          |
	| tst_atmp_2020q2    | Administratum4199 |
	| tst_atmp_2020q2v2  | Administratum4199 |
	| won'tpass@this.com | Administratum4199 |
	| not123@this.one    | JustSome!.@pas    |