Feature: Login
	In order to write letters
	As a user
	I want to be able to login to my email

@mytag
Scenario: Login to email
	Given I have navigated to the home page
	And I have entered the email and password
	When I press submit
	Then I should be logged in
