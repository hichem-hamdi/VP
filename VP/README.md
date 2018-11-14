The application is developped under the .Net Core 2.1 Framework.

The solution is delivered with a Swagger interface to test the API.

You need to launch the project and select the api controller to test, enter the params and execute the action.

Data is hard coded in the namespace "Infrastructure.Data" you can use this data to test the True return.
 Email="email1@test.fr", Password="email1"
 Email="email2@test.fr", Password="email2"
 Email="email3@test.fr", Password="email3"
 Email="email4@test.fr", Password="email4"


 For AWS Authentication to test the false value, you need to change the hard coded value in the calss AWSAuthenticationRepository namespace "Infrastructure.Data" 
 in a way that the method GetSecretAccessKeyyAccessKeyId will return a different value than the value setted in the controller.


 The Techno stack used is :
 ASP.NET CORE 2.1
 Swagger for the API UI test
 CQS (Command–query separation) pattern
 SOLID patterns
 