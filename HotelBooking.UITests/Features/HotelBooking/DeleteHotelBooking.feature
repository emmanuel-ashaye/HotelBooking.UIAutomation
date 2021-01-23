Feature: DeleteHotelBooking
	As a frequent traveler I would like to
	delete hotel bookings when travel plans change

Background: 
	Given I visit the Hotel booking form
	And I have a Hotel booking
		| field       | value      |
		| Firstname   | Chris      |
		| Lastname    | Anderson   |
		| TotalPrice  | 120        |
		| DepositPaid | false      |
		| Checkin     | 2021-02-18 |
		| Checkout    | 2021-02-23 |

Scenario: 2. Can delete a hotel booking
	When I click the delete button against my booking
	Then my hotel booking is removed