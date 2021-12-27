Feature: Logout

I want to disconnect from Northwind DATABASE

@tag1
Scenario: [Logout]
	Given [I am on "HomePage"]
	When [I click logout]
	Then [I go to "LoginPage"]
	