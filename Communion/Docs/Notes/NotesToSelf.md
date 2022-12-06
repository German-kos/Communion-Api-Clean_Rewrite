# These are notes to myself, nothing important here

- make the email the sign in credential instead of the username
- change the Username to be DisplayName
- change layer location of the password service
- write an explanation about CQRS and MediatR, the differences, and why I chose MediatR
- write about ErrorOr(?)
- look into SignalR
- if there's spare time left after finishing the project, look into making an instant messaging micro-service

> Important expected bug/error: when I'll implement the ProfilePicture entity, it will no longer be a string, so in the `AuthenticationMappingConfig` I'll have to change how the result is mapped to the response.
> Also need to make entities for Comments(Comment) and Posts(Post) and change the fields in the user entity.
> Not user specific => Also need to make a Category and Topic(Rename from SubCategory) entities.
