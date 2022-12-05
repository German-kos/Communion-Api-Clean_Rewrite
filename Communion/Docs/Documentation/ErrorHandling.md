# **HOW ERRORS ARE HANDLED**

## *EXPECTED ERRORS*

The domain layer defines the kind of exceptions and errors that are expected to come up in the application, and that might be needed in more than project layer.

***List of expected errors:***

- [Authentication](https://github.com/German-kos/Communion-Api-Clean_Rewrite/blob/00e9624dc34e09cf7f4813a7872ea1636af7a4a1/Communion/Communion.Domain/Common/Errors/Errors.Authentication.cs#L7-L12) type errors.
  - [InvalidCredentials.]()
- [User]() type errors.
  - [DuplicateUsername.]()
  - [DuplicateEmail.]()
  - [BadPassword.]() 


## *UNEXPECTED ERRORS*

> *No info yet*

## *ERRORS OVERVIEW*

- [Authentication Type Errors]().
- [User Type Errors]().

### *AUTHENTICATION TYPE ERRORS*

- #### InvalidCredentials

> *[reference.](https://github.com/German-kos/Communion-Api-Clean_Rewrite/blob/c8f8a0f3e1cb0df6aa4defd5064171562c1c5119/Communion/Communion.Domain/Common/Errors/Errors.Authentication.cs#L9-L12)*

A general error to return, when information may be sensitive and might risk an attack.


##### Use case exampe

```DOTNET
    // Validate that the user exists.
    if (_userRepository.GetByUsername(username) is not User user)
        return Errors.Authentication.InvalidCredentials;

    // Validate that passwords match
    if (!_passwordService.PasswordsMatch(password, user))
        return Errors.Authentication.InvalidCredentials;
```

> *Code snippet from [AuthenticationQueryService](https://github.com/German-kos/Communion-Api-Clean_Rewrite/blob/c8f8a0f3e1cb0df6aa4defd5064171562c1c5119/Communion/Communion.Application/Services/Authentication/Queries/AuthenticationQueryService.cs#L28-L34).*


### *USER TYPE ERRORS*

- #### DuplicateUsername

> *[reference.]()*

A part of the sign up form errors, for when a username is already taken.


