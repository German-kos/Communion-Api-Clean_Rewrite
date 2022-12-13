# RENAME TOPIC REQUEST

## *ROUTE*

```http
Post /api/admin/categories/rename-topic
```

>***NOTE:** A JWT is required for authorization, and admin rights to perform this action.*

## *EXPECTED FIELDS*

```json
// Note: The username will be extracted from the JWT,
// in order to track who was the user that requested the edit.
{
    "CategoryId": "The category's ID", // Provide the ID of the category to rename a topic in it
    "TopicId": "The ID of the topic to rename", // Provide the ID of the topic to rename
    "TopicName": "The name of the new topic" // Provide the new name for the topic
}
```

## *AVAILABLE CATEGORY METHODS*

```cs
class Category
{
    Category Rename(); // Rename the category
    Category UpdateBanner(); // Update the category's banner
    Category CreateTopic(); // Create and add a topic to the category
    Category RenameTopic(); // Rename an existing topic in the category
    Category RemoveTopic(); // Remove an existing topic from the category
}
```
