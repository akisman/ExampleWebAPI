# WebAPI Example

Example WebAPI using the Entity Framework

## Notes

* Database is being created using Code First migration
* Works with JSON and XML
* Uses Convention-based and attribute routing
* Seed database using ```Update-Database```
* Uses Repository Pattern & Unit of Work(Dependency Injection via Ninject)
* Some Unit of Work layer Unit Tests (Using Moq)

## API 

The following endpoints are defined(See below for creating new Pet):

* List of pets by owner ```GET: api/PetOwners/ownerId```

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

### More Examples

GET /api/Pets/Age/5
```
[
  {
    "Id": 2,
    "Name": "Havok",
    "DateOfBirth": "2014-06-25T00:00:00",
    "PetOwnerId": 2,
    "PetWalkerId": 1
  }
]
```

GET /api/PetOwners/2
```
[
  {
    "Id": 2,
    "Name": "Havok",
    "DateOfBirth": "2014-06-25T00:00:00",
    "PetOwnerId": 2,
    "PetWalkerId": 1
  }
]
```

GET /api/PetWalkers/1/2
```
[
  {
    "IsApproved": true
  }
]
```