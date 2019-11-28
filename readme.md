## Setup
>>Clone / Download solution
>>DB Connection string is configured at <root>\Api\Api\appsettings.json.
>>API deployment config is configured at <root>\Api\Api\Properties\launchsettings.json
>>Please update web settings at: <root>\Web\app\environments\environments.ts (base url) is needed.

## Run app
>>Navigate to the <root>\Api\Api
>>run command: dotnet run. This will deploy the DB (above connnection string) and run the API (listening at above url)
>>Navigate to <root>\Web
>>Run npm install
>>Run ng serve

## Run web unit tests
>>Run: ng test (for web)
>>Run: dotnet test (for API)