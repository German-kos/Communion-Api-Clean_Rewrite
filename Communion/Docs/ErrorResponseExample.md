# Example For a More Proper Error Response

## Internal Error Example

**How the content of the error looks like:**

```c#
var problemDetails = new ProblemDetails
    {
        Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
        Title = "An error has occurred while processing your request.",
        Status = (int)HttpStatusCode.InternalServerError,
    };
```

> As seen in [ErrorHandlingFilterAttribute](https://github.com/German-kos/Communion-Api-Clean_Rewrite/blob/5b707a0faebb76d2fd8b57abdeffed5c5be4a688/Communion/Communion.Api/Filters/ErrorHandlingFilterAttribute.cs#L13-L18).

</br>

**The result would looks like this:**

![Sign up error example](./Images/Errors/SignUpErrorExample.png)

</br>

> _File might be update or deleted in the future._
