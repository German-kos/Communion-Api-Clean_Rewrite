# Domain Models

## Category

```csharp
class Category
{
    Category Create();
    Category Rename();
    Category UpdateBanner();
    Category CreateTopic();
    Category RenameTopic();
    Category RemoveTopic();
}
```

```json
{
    "id": "{Category ID}",
    "name": "{Category Name}",
    "banner": {"banner obj"},
    "topics":[
        {"topic 1 obj..."},
        {"topic 2 obj..."},
        {"topic 3 obj..."},
    ],
    "creationDateTime": "{DateTime of Creation}",
    "updateDateTime": "{DateTime of Last Update}",
    "isModified": "{Was Updated Bool}",
    "whoModified": "{Username of Who Modified}",
}
```
