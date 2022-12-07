# Domain Models

## Topic

```csharp
class Topic
{
    Topic Create();
    Topic RemovePost();
    Topic Rename();
}
```

```json
{
    "id": "{Topic ID}",
    "categoryId": "{Parent Category ID}",
    "name": "Topic Name",
    "posts": [
        "{Post 1 ID}",
        "{Post 2 ID}",
        "{Post 3 ID}",
    ],
    "creationDateTime": "{DateTime of Creation}",
    "updateDateTime": "{DateTime of Last Update}",
}
```
