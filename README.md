Salesforce.NET
==============

Recurly REST Api 2.0 wrapper.

For first you have to define .config settings:

```CSharp
<appSettings>        
    <!-- Elmah -->
    ...
    <!-- Recurly -->
    <add key="RecurlyApiKey" value="0a7adbad2644484b9314a85493da57b0" />
	<add key="RecurlyApiEndpoint" value="https://api.recurly.com/v2/" />
</appSettings>
```

Exapmles
--------

```CSharp
var reculyGateway = new RecurlyGateway();

reculyGateway.GetManager<SubscriptionManager>();

var existingAccount = new RecurlyAccount
{
	Code = account.Code
};

var newSubscription = new RecurlySubscription
{
    Account  = existingAccount,     // account info
    PlanCode = planCode,            // plan code
    Currency = RecurlyCurrency.USD, // subscription currency
    Quantity = units                // number of units
};

SubscriptionManager.Create(newSubscription);
```