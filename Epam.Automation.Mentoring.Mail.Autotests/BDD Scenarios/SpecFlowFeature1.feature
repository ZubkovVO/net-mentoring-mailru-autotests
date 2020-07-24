Feature: Create New Email
In order to be able to communicate with other email addressees
As a user
I want to be able to send an email

Background:
Given I navigated to the home page
And logged in the email using <login> and <password>

@mytag
Scenario Outline: Create, Save as Draft and Send an Email
And I have composed an email
And I saved the email
When I send it from drafts
Then It should be sent
Examples:
| login    | password |
| testsdsd | hsdsdsd  |
| sdsdsd   | sdsddd   |