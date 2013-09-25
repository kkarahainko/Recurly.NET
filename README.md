Recurly.NET
==============

Recurly REST Api 2.0 wrapper.

For first you have to define .config settings:

```CSharp
<appSettings>        
    <!-- Elmah -->
    ...
    <!-- Recurly -->
    <add key="RecurlyApiKey" value="{YOUR_API_KEY_HERE}" />
	<add key="RecurlyApiEndpoint" value="https://api.recurly.com/v2/" />
</appSettings>
```

Exapmles
--------

```CSharp
var recurlyGateway = new RecurlyGateway();

var manager = recurlyGateway.GetManager<SubscriptionManager>();

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

manager.Create(newSubscription);
```