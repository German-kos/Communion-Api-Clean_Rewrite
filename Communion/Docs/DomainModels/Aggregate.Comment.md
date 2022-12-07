# Domain Models

## Comment

```csharp
class Comment
{
    Comment Create();
    Comment Delete();
    Comment Update();
    Comment AddLike();
    Comment SubtractLike();
}
```

```json
{
    "id": "{Comment ID}",
    "postId": "{Parent Post ID}",
    "author": "Author's User ID",
    "content": "{Comment Content}",
    "likeCount": "{Amount of Likes}",
    "creationDateTime": "{DateTime of Creation}",
    "updateDateTime": "{DateTime of Last Update}",
    "isModified": "{Was Updated Bool}",
}
```
