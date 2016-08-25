Feature: BusinessController
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario Outline: Add two numbers
	Given I have entered <FirstNumber> into the calculator
	And I have also entered <SecondNumber> into the calculator
	When I press add
	Then the result should be <Result> on the screen

	Examples: 
		| FirstNumber | SecondNumber | Result |
		| 50          | 70           | 120    |
		| 60          | 70           | 130    |
		| 100         | 70           | 170    |
		| 10000       | 70           | 10070  |
		| 10          | 70           | 80     |
		| 1			  | 70           | 710    |
		| 547         | 70           | 617    |
		| 7527        | 70           | 7597   |
		| 727         | 70           | 797    |
