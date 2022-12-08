# Domain Models

## Topic

```csharp
class Topic
{
    Topic Create();
    Topic Rename();
}
```

```json
{
    "id": "{Topic ID}",
    "categoryId": "{Parent Category ID}",
    "name": "Topic Name",
    "creationDateTime": "{DateTime of Creation}",
    "updateDateTime": "{DateTime of Last Update}",
    "isModified": "{Was Updated Bool}",
    "whoModified": "{Username of Who Modified}",
}
```
