# PremiumCalculator

This solution is created as part of the Coding challenge for TAL.
Solution has 3 components:
1. PremiumCalculator.Service
	* The service layer that takes the name and age and returns the decimal premium amount.
2. PremiumCalculator.Tests
	* Unit Tests to provide test coverage for the service. 
3. PremiumCalculator
	* MVC application to take input from the user and to display output.
	* Autofac is used for dependency injection.

Areas of imporvement:
1.	Rules engine could be implemented at the service layer. That will facilitate the cleaner and more managable code by abstarcting the business rules in one place.
2.	Given the time would love to increase the unit test coverage.
3.	Angular could be used on the front end for better user experience.
4. 	An APM like Application Insight could be integrated for telemetry and logging.
