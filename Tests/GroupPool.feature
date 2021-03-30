Feature: GroupPool
	Successful and unsuccessful tests that should ilustrate work of my framework against Group Pool

Scenario: Creating Group Pool
	Given unregistred user initiate his first doodle action
	And set a title of the occasion
	And add text options:
		| number | option       |
		| 1      | Every Monday |
		| 2      | Tomorrow     |
	And skip Pool settings
	When enter participant name 'TestUser' and email address
	Then invitation link should be created
	And participant name should be 'TestUser'
	And pool options should be
		| number | option       |
		| 1      | Every Monday |
		| 2      | Tomorrow     |

Scenario: Test that should fail and illustrate what should happen if test fails
	Given unregistred user initiate his first doodle action
	And set a title of the occasion
	And add text options:
		| number | option       |
		| 1      | Every Monday |
		| 2      | Tomorrow     |
	And skip Pool settings
	When enter participant name 'TestUser' and email address
	Then invitation link should be created
	And participant name should be 'TestUser'
	And pool options should be
		| number | option       |
		| 1      | Every Monday |
		| 2      | Tomorrows    |