Feature: Create New Email
	In order to be able to communicate with other email addressees
	As a user
	I want to be able to send an email

@mytag
Scenario: Create, Save as Draft and Send an Email
	Given I logged in to my email address
	And I have composed an email
	And I saved the email
	When I send it from drafts
	Then It should be sent
