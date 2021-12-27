Feature: login

I want to connect to NwApp

@tag1
Scenario: [Login]

	Given [I open "http://localhost:5000" url]
	When [I enter in login field "user" and enter in the password field "user"]
	Then [I go to HomePage]
