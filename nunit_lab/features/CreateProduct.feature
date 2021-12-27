Feature: CreateProduct

Create NewProduct

@tag1
Scenario: [CreateProduct]
	Given [I pass authorisation]
	When [I go to "CreatePage"]
	And I fill "fields"
	Then [I go to "HomePage"]
