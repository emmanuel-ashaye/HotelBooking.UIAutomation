Feature: AddHotelBooking
	As a frequent traveller I would like to 
	make Hotel bookings whenever I need to travel

Scenario: 1. Can add hotel booking
	Given I visit the Hotel booking form
	And I enter these booking details
		| field       | value      |
		| Firstname   | Sam        |
		| Lastname    | White      |
		| TotalPrice  | 120        |
		| DepositPaid | false      |
		| Checkin     | 2021-02-18 |
		| Checkout    | 2021-02-23 |

	When I click the save button
	Then a new hotel booking is added