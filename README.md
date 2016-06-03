# WebAPI Example

## Notes

* Database is being created using Code First migration
* Works with JSON and XML
* Migration files aren't needed for new databases

## API 

The following endpoints are defined(See below for creating new Pet):

* List of pets by owner ```GET: api/PetOwners/ownerId/Pets```

* Is PetWalker approved by PetOwner ```GET: api/PetWalkers/walkerId/ownerId```

* Get Pet by id ```GET: api/Pets/petId```

* Create new pet ```POST: api/Pets```

* Update an existing pet ```PUT: api/Pets/petId```

* Get pets that are under X years old ```GET: api/Pets/Age/X```

### Pet JSON

Proper form for POSTing new pets. PetOwnerId is required.

```
{
  "Name": "Havok",
  "DateOfBirth": "2014-06-25",
  "PetOwnerId": 1,
  "PetWalkerId": 1
}
```