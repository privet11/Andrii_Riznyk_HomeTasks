Feature: SpecFlowFeature2
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Check the secondary articles
	Given the expected secondary articles is <searchResults>
	When user navigating to the news page
	Then the search results should contain expected articles
Examples: 
| searchResults                                                                                       |
|The justice, an iconic champion of women's rights, dies at 87 after suffering from pancreatic cancer.The forest fires have had a devastating impact on the wildlife of the world's largest wetland.|