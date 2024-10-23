Feature: ExistingUserTests

@login
Scenario: CheckoutAsExistingUser
	Given open home page
	And open My account
	And open Order History
	And note number of orders on Order History
	When open category 'Laptops & Notebooks'
	And filter in stock items
	And add product number 6 to Cart
	And go to Checkout
	And use existing address option
	And accepting Terms and Conditions
	And confirming Order
	And press Continue
	And open My account
	And open Order History
	Then new order appeared on Order History

