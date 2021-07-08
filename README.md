# Currency Converter Task

Using C# and any Azure resource types you think appropriate, build an API that allows end-users to convert an amount from one currency to another.

Using any appropriate front-end framework, expose the API functionality to users.

Users should be able to select a source currency, enter an amount and select a destination currency. The app should then convert the amount to the destination currency and display the converted amount.

The software should be delivered as a link to a GitHub repo we can review.

## Time frame

Please spend one or two evenings on this exercise.

## Notes

If you have any time remaining and want some bonus points, they'll be awarded for:

* A solution that is running on Azure (you can obtain 150 free credits to be used within 30 days)
* Unit tests
* Use of interfaces and types for models
* Good code organisation
* Good state management

## Before Running

For the external currency exchange api [open exchange rates](https://openexchangerates.org) an Api needs to be generated. Please add the following to the project secrets or include as an environment variable into the project.

``` json
 "OpenExchangeRates": {
    "ApiKey": "Token ******{Your Api Key}******",
    "BaseUrl": "https://openexchangerates.org/api"
  }
```

## ToDos

* [x] Build Api
* [x] Unit tests for Api
* [ ] Deploy Api to Azure
* [x] Build Frontend
* [ ] Deploy Frontend to Azure
