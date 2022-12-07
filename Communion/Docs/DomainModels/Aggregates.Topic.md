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
    "name": "Topic Name",
    "categoryId": "{Parent Category ID}",
    "posts": [
        {"post 1 obj..."},
        {"post 2 obj..."},
        {"post 3 obj..."},
    ]
}
```
