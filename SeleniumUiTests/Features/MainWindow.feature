Feature: Calculator
	MainWindow of Calculator

# This Scenario is just an example of how to get the Page Source data
# Page source data displays the supported attributes which can be used for the xpath
# If you're stuck trying to find an attribute (Name, ClassName, etc) getting the page source may help

Scenario: Get Page Source
	Given Calculator is launched
	When Get page source data

Scenario: Verify Application version
	Given Calculator is launched
	When Setting is navigated to
	Then Verify application version

Scenario: Verify Calculator history
	Given Calculator is launched
	When History is navigated to
	Then Verify Calculator history is blank

Scenario: Verify default Calculator memory buttons
	Given Calculator is launched
	Then Verify default memory buttons

Scenario: Add two numbers together and verify Calculator history
	Given Calculator is launched
	When Two numbers are added '1' and '5' together
	And Verify the result '6'

# This Scenario uses Examples as a data source.
# 1. Each example needs to be in brackets e.g. <First Number>
# 2. The text should match what is in the Examples table
# 3. The Data Type can be changed in the steps section e.g. WhenTwoNumbersAreSubtractedAnd(string firstNum, int secondNum)

Scenario Outline: Subtract two numbers together and verify Calculator history
	Given Calculator is launched
	When Two numbers are subtracted <First Number> and <Second Number>
	Then Verify the result contains <Result>

	Examples:
		| First Number | Second Number | Result |
		| 9            | 1             | 8      |
		| 5            | 5             | 0      |
		| 1            | 7             | -6     |

# This Scenario uses a .xlsx file as a data source.
# 1. The data source defaults to the features folder. e.g. @DataSource:Examples.xlsx
# 2. Data source can be moved into another folder by going back a folder to the main (SeleniumUiTests folder)
# then finding setting the location of the data source e.g. @DataSource:../TestResources/FeatureData/Calculations.xlsx
# .. goes back a folder /TestResources/FeatureData are the folders the .xlsx file is in /Examples.xlsx is the file
# 3. @DataSet:MultiplAndDivideSheet is the excel sheet name

@DataSource:../TestResources/FeatureData/Examples.xlsx @DataSet:MultiplyAndDivideSheet
Scenario: Multiply and divide two numbers together and verify Calculator history
	Given Calculator is launched
	When Two numbers are <Operation> together <FirstNumber> and <SecondNumber>
	Then Verify the result contains <Result>

	#Note: The below table is now referenced from an excel sheet (Examples.xlsx)
	#Examples:
	#	| FirstNumber | Operation | SecondNumber | Result                |
	#	| 9           | *         | 1            | 9                     |
	#	| 5           | *         | 5            | 25                    |
	#	| 4           | *         | 0            | 0                     |
	#	| 9           | /         | 3            | 3                     |
	#	| 5           | /         | 5            | 1                     |
	#	| 2           | /         | 0            | Cannot divide by zero |
