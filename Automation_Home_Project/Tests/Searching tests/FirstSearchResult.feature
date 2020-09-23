Feature: FirstSearchResult
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Check the name of the first article against a specified value
	Given the specified value is <Chuggington: Badge Quest: Home Sweet Home>
	When user is navigate to the News page
	And user is not logining in
	And user input search word
	Then the the name of the first article should be like a specified value