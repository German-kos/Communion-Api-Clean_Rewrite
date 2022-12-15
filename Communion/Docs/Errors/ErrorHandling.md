# ⚠️ **HOW ERRORS ARE HANDLED** ⚠️

> 📢 ***Keep in mind that links may be broken or lead to wrong lines as the project is still being worked on. The documentations and notes will eventually be fixed.***

## *EXPECTED ERRORS*

The domain layer defines the kind of exceptions and errors that are expected to come up in the application, and that might be needed in more than project layer.

***List of expected errors:***

- [Authentication](https://github.com/German-kos/Communion-Api-Clean_Rewrite/blob/main/Communion/Docs/Documentation/ErrorHandling.md#authentication-type-errors) type errors.
  - [InvalidCredentials.](https://github.com/German-kos/Communion-Api-Clean_Rewrite/blob/main/Communion/Docs/Documentation/ErrorHandling.md#invalidcredentials)
- [User](https://github.com/German-kos/Communion-Api-Clean_Rewrite/blob/main/Communion/Docs/Documentation/ErrorHandling.md#user-type-errors) type errors.
  - [DuplicateUsername.](https://github.com/German-kos/Communion-Api-Clean_Rewrite/blob/main/Communion/Docs/Documentation/ErrorHandling.md#duplicateusername)
  - [DuplicateEmail.](https://github.com/German-kos/Communion-Api-Clean_Rewrite/blob/main/Communion/Docs/Documentation/ErrorHandling.md#duplicateemail)
  - [BadPassword.](https://github.com/German-kos/Communion-Api-Clean_Rewrite/blob/main/Communion/Docs/Documentation/ErrorHandling.md#badpassword)

## *UNEXPECTED ERRORS*

> *No info yet*

## *ERRORS OVERVIEW*

- [Authentication Type Errors](https://github.com/German-kos/Communion-Api-Clean_Rewrite/blob/main/Communion/Docs/Documentation/ErrorHandling.md#authentication-type-errors).
- [User Type Errors](https://github.com/German-kos/Communion-Api-Clean_Rewrite/blob/main/Communion/Docs/Documentation/ErrorHandling.md#user-type-errors).

### *AUTHENTICATION TYPE ERRORS*

- #### InvalidCredentials

> *[reference.](https://github.com/German-kos/Communion-Api-Clean_Rewrite/blob/c8f8a0f3e1cb0df6aa4defd5064171562c1c5119/Communion/Communion.Domain/Common/Errors/Errors.Authentication.cs#L9-L11)*

A general error to return, when information may be sensitive and might risk an attack.

##### Use case example

```csharp
    // Validate that the user exists.
    if (_userRepository.GetByUsername(username) is not User user)
        return Errors.Authentication.InvalidCredentials;

    // Validate that passwords match
    if (!_passwordService.PasswordsMatch(password, user))
        return Errors.Authentication.InvalidCredentials;
```

> *Code snippet from [AuthenticationQueryService](https://github.com/German-kos/Communion-Api-Clean_Rewrite/blob/c8f8a0f3e1cb0df6aa4defd5064171562c1c5119/Communion/Communion.Application/Services/Authentication/Queries/AuthenticationQueryService.cs#L28-L34).*

##### HTTP Response

```HTTP
HTTP/1.1 400 Bad Request
Connection: close
Content-Type: application/problem+json; charset=utf-8
Date: Mon, 05 Dec 2022 20:09:26 GMT
Server: Kestrel
Transfer-Encoding: chunked

{
  "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
  "title": "Invalid credentials.",
  "status": 400,
  "traceId": "00-fb35be8ec4d4e5b3b45b779aaf0343ac-67ad16744ad4cdea-00",
  "errorCodes": [
    "Auth.InvalidCred"
  ],
  "errorMessages": [
    "Invalid credentials."
  ]
}
```

### *USER TYPE ERRORS*

- #### DuplicateUsername

> *[reference.](https://github.com/German-kos/Communion-Api-Clean_Rewrite/blob/c8f8a0f3e1cb0df6aa4defd5064171562c1c5119/Communion/Communion.Domain/Common/Errors/Errors.User.cs#L9-L11)*

A part of the sign up form errors, returned when a username is already in use.

- #### DuplicateEmail

>*[reference.](https://github.com/German-kos/Communion-Api-Clean_Rewrite/blob/c8f8a0f3e1cb0df6aa4defd5064171562c1c5119/Communion/Communion.Domain/Common/Errors/Errors.User.cs#L13-L15)*

A part of the sign up form errors, returned when an email is already in use.

- #### BadPassword

> *[reference](null)*
> ***Not implemented yet.***
