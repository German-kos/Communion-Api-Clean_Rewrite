# Domain Models

## Topic

```csharp
class Topic
{
    Topic Create();
    Topic Delete();
    Topic Update();
}
```

```json
{
    "id": "{Topic ID}",
    "categoryId": "{Parent Category ID}",
    "name": "Topic Name",
    "posts": [
        {"post 1 obj..."},
        {"post 2 obj..."},
        {"post 3 obj..."},
    ],
    "creationDateTime": "{DateTime of Creation}",
    "updateDateTime": "{DateTime of Last Update}",
}
```
