# Domain Models

## Post

```csharp
class Post
{
    Post Create();
    Post Delete();
    Post Update();
    Post AddView();
    Post AddLike();
    Post SubtractLike();
}
```

```json
{
    "id": "{Post ID}",
    "topicId": "{Parent Topic ID}",
    "title": "{Post Title}",
    "author": {"author obj"},
    "content": "{Post Content}",
    "viewCount": "{Amount of Views}",
    "commentCount": "{Amount of Comments}",
    "likeCount": "{Amount of Likes}",
    "comments":[
        {"comment 1 obj..."},
        {"comment 2 obj..."},
        {"comment 3 obj..."},
    ]
}
```
