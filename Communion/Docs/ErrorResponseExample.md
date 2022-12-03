# Example For a More Proper Error Response

## Internal Error Example

**How the contents of the error looks like**

```
var problemDetails = new ProblemDetails
    {
        Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
        Title = "An error has occured while processing your request.",
        Status = (int)HttpStatusCode.InternalServerError,
    };
```

> As seen in [ErrorHandlingFilterAttribute](https://vscode.dev/github/German-kos/Communion-Api-Clean_Rewrite/Communion/Communion.Api/Filters/ErrorHandlingFilterAttribute.cs#L13), line 13.

###
