Feature: HomeTask1
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Check that team scores display correctly
	Given the Home page is open
	And the team names is <firstTeam>  <secondTeam>
	And the team scores is <firstScore>  <secondScore>
	And the league is Scottish Prem
	And the month is AUG
	When user is navigate to the sport page
	And user is'nt logining in
	And user is navigate to the football page
	And user selecting league
	And user selecting month
	Then there must be specified teams with the specified scores
	When user navigating to the match page
	Then there must be same teams with the same scores
Examples: 
| firstTeam  | secondTeam    | firstScore | secondScore |
| Celtic     | Motherwell    | 3          | 0           |
| Hibernian  | Aberdeen      | 0          | 1           |
| Kilmarnock | Dundee United | 4          | 0           |
| Livingston | Ross County   | 1          | 0           |


@mytag
Scenario: Check link sharing work correctly
	Given the BBC Home page is open
	When I go to News
	And click on "Entertainment & Arts" tab
	And click the first article
	And click Share
	And copy the link
	And navigate the link
	Then the same article is open