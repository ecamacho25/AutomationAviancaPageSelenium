JAYA QA TECH TEST

##############
Prerequisites
##############

- Visual Studio (any recent version)
- Chrome browser version 88.0.4324.182

##############################
Steps to clone the repository
##############################

To install the project you need to follow these steps:

1. Open Visual Studio and select the option "Clone a repository"
2. In the field repository location you must add the following url: https://github.com/ecamacho25/JayaQATechTest.git
3. Click Clone
4. You can see in the project the file packages.config, then right click over it and select the option "migrate packages.config to  PackageReference""
5. A modal will appear, then Click Ok.
6. Build the solution and check no errors should be appear.


##############################
Run test cases
##############################

1. Go to folder TestCases and open the class: Jaya_TestCases.cs
2. Right click inside the class and select the option "Run Test(s)"
3. Go to Test Explorer tab. There you can see the test cases: BookingFlight_FlightIsBookedSuccessfully and SearchFlightAndOrderByDepartTime_FlightsAreOrdered without execution yet.
4. Click in the icon "Run" (green play icon) to execute each test case.
5. Notice the test cases now are running.

##############################
Best practices
##############################
I implemented the Page Object Model. This design pattern help to reduces code duplication and improves test maintenance. 
You can see in the structure of the project that It is split in the following 3 folders:
1. helpers: It contain the class helper.cs that will help the automation to create generic methods that can be call for other classes. Those methods help the driver to execute some actions that are generics over the browser.
2. Pages: This folder contains the definition of each page in the app. Each class page here should contain its elements (locators) and the actions that can be doing over each element. In this case the pages are inheriting all actions that are defined in the helper.cs.
3. Testcases: This folder contains the class where the test cases are defined. The class Jaya_TestCases.cs call all pages that will use in the execution and the actions that their contain. Here I defined the section "Private methods" where I include some workflows that are call by each test case to be more modular the test cases (It allows different step combinations).

"# JayaQATechTest" 
"# JayaTestCases" 
