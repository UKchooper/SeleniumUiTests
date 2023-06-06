Feature: Calculator
	MainWindow of Calculator

Scenario: Verify Application version
	Given Calculator is launched
	When Setting is navigated to
	Then Verify application version

Scenario: Verify Calculator history
	Given Calculator is launched
	When History is navigated to
	Then Verify Calculator history is blank

Scenario: Add two numbers together and verify Calculator history
	Given Calculator is launched
	When Two numbers are added '1' and '5' together
	And Verify the result '6'

Scenario: Subtract two numbers together and verify Calculator history
	Given Calculator is launched
	When Two numbers are subtracted <FirstNumber> and <SecondNumber>
	Then Verify the result contains <Result>

	Examples:
		| FirstNumber | SecondNumber | Result |
		| 9           | 1            | 8      |
		| 5           | 5            | 0      |
		| 1           | 7            | -6     |

Scenario: Multiply and divide two numbers together and verify Calculator history
	Given Calculator is launched
	When Two numbers are <Operation> together <FirstNumber> and <SecondNumber>
	Then Verify the result contains <Result>

	Examples:
		| FirstNumber | Operation | SecondNumber | Result                |
		| 9           | *         | 1            | 9                     |
		| 5           | *         | 5            | 25                    |
		| 4           | *         | 0            | 0                     |
		| 9           | /         | 3            | 3                     |
		| 5           | /         | 5            | 1                     |
		| 2           | /         | 0            | Cannot divide by zero |
