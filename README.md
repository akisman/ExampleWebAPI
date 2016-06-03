# WebAPI Example

## API 

The following endpoints are defined:

List of pets by owner
GET: api/PetOwners/ownerId/Pets

Is PetWalker approved by PetOwner
GET: api/PetWalkers/walkerId/ownerId

Get Pet by id
GET: api/Pets/petId

Create new pet
POST: api/Pets

Update an existing pet
PUT: api/Pets/petId

Get pets that are under X years old
GET: api/Pets/Age/X