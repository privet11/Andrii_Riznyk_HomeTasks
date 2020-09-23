Feature: TeamScores
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Check that team scores display correctly
	And the names of teams is <firstTeam>  <secondTeam>
	And the match scores is <firstScore>  <secondScore>
	And the test league is Scottish Prem
	And the test month is AUG
	When user navigate to the sport page
	And user is'nt logining
	And user navigate to the football page
	And user select league
	And user select month
	Then there must be specified teams with the specified match scores
	When user is navigate to the match page
	Then there must be same teams with the same match scores
Examples: 
| firstTeam  | secondTeam    | firstScore | secondScore |
| Celtic     | Motherwell    | 3          | 0           |
| Hibernian  | Aberdeen      | 0          | 1           |
| Kilmarnock | Dundee United | 4          | 0           |
| Livingston | Ross County   | 1          | 0           |

