# EDIT CATEGORY REQUEST

## *ROUTE*

```http
Post /api/admin/categories/edit-category
```

>***NOTE:** A JWT is required for authorization, and admin rights to perform the action.*

## *EXPECTED FIELDS*

```json
// Note: The username will be extracted from the JWT,
// in order to track who was the user that requested the edit.

// Either the name or the banner can be left
// empty if there is no desire to change them, but not both.
{
    "CategoryId": "The category's ID", // Provide the id of the desired category
    "NewCategoryName": "The category's new name", // Provide a name to change the name of the category
    "NewBannerImage": "An image for the new banner", // Provide an image to update the banner of the category
}
```

</br>

> ***NOTE:** In the edit category, a new name and banner can be assigned in one call, anything related to topics will be preformed through other endpoints.*

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
