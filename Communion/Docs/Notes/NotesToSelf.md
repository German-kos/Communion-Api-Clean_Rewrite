# These are notes to myself, nothing important here

- make the email the sign in credential instead of the username
- change the Username to be DisplayName
- change layer location of the password service
- write an explanation about CQRS and MediatR, the differences, and why I chose MediatR
- write and explain about ErrorOr(?)
- write and explain about FluentValidation and the application validation pipeline
- look into SignalR
- if there's spare time left after finishing the project, look into making an instant messaging micro-service

> Important expected bug/error: when I'll implement the ProfilePicture entity, it will no longer be a string, so in the `AuthenticationMappingConfig` I'll have to change how the result is mapped to the response.
> Also need to make entities for Comments(Comment) and Posts(Post) and change the fields in the user entity.
> Not user specific => Also need to make a Category and Topic(Rename from SubCategory) entities.
</br>
> When making endpoints to list the aggregates, look for if there's an option to list the aggregates (like a list of Posts) without their inner list of aggregates/entities
>> For example: when we need a list of **Posts** we don't necessarily need the list of comments, but when we want to see what's inside we do.
>>> if we'll try and get all the comments for all the posts within a single topic, it might take too long because when there are a lot of posts and comments, that's 2 layers to sift through.
</br>
> Create separate records for the banner and topics in the category response
</br>
> Create Posts
> Need aggregate md, and repository for posts and comments