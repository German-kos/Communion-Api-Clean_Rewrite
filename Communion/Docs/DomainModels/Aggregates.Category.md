# Domain Models

## Category

```csharp
class Category
{
    Category Create();
    Category Delete();
    Category Update();
}
```

```json
{
    "id": "{Category ID}",
    "name": "{Category Name}",
    "banner": "{banner url}",
    "topics":[
        {"topic 1 obj..."},
        {"topic 2 obj..."},
        {"topic 3 obj..."},
    ],
    "creationDateTime": "{DateTime of Creation}",
    "updateDateTime": "{DateTime of Last Update}"
}
```
