Feature: Login
	As a TOS user,
	I would like to be able to log into the pinSight platform.

@login
Scenario: Login as user
	Given Given that I navigate to pinSight application
	And And I enter testuser@mailinator.com as the username
	And I enter the password	
	When I press login
	Then I should land on the Hotel page
