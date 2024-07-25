1 Scope
The scope of the task is to examine the candidate's logical and technical ability in solving a typical
real-life software problem in a one hour time-boxed environment.
The candidate will be tested on:
● Solution Completeness
● Efficiency
● Project structure and architecture used
● SOLID Principles and Design patterns used
● Level of coupling
● Best practices
2 Test
2.1 Prerequisites
In order to complete this test, the developer must have the following tools set up and in place:
1. .Net Core SDK 8.0
2. IDE (like VS 2022, Rider or VS Code)
2.2 Problem Definition
The scope of the task is to build a simple calculator application using .NET 8. The API should provide
basic arithmetic operations like addition, subtraction, and multiplication. Additionally, it should include
unit tests and integration tests(nice to have) to ensure reliability and functionality.
Your solution should have:
● API Layer (One Controller with the endpoints specified below)
● Business Layer (Services)
● Swagger (default implementation) to show your API endpoints
● Candidate can use any Nuget package for this implementation
CONFIDENTIAL
2.3 Endpoint Details
2.3.1 Request
This application is expected to expose an HTTP GET REST endpoint with accepts the following three
required properties as the input query string
1. OperationType [ENUM] (like Add, Subtract and Multiply)
2. FirstOperand [decimal]
3. SecondOperand [decimal]
2.3.2 Response
Responses must adhere to the RFC 9110-defined HTTP response codes and use the JSON structure for
the content type, as indicated below.
{
"success": true,
"data": {
"result": 10
}
}
2.4 . Acceptance Criteria
● The API should perform basic arithmetic operations accurately.
● Input validation should prevent invalid inputs and handle errors gracefully.
● Unit tests and integration tests should pass successfully
