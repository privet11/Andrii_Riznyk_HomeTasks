Feature: SpecFlowFeature1
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Check the headline article
	Given the test headline article is "US to ban TikTok and WeChat downloads in 48 hours"
	When user navigating to the News page
	Then the headline article at the News page should be
