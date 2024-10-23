Feature: NewUserTests

Scenario: CheckoutAsNewUser
	Given open home page
	When open category 'Laptops & Notebooks'
	And filter in stock items
	And add product number 6 to Cart
	And go to Checkout
	And fill user info
	And accepting Policy
	And accepting Terms and Conditions
	And confirming Order
	And press Continue
	And open My account
	And open Order History
	Then single order is present on Order History
