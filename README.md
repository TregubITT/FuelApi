# FuelApi
Taking into consideration the fact that this is the test task, some functions like error handlers,
validations, etc. are out of scope.
The Key Points that were not realized are the following:
1. API or DataBase availability monitoring;
2. Approach to solving the unexpected cases like server restart, etc. Probably, we need to 
wrapp all crud operations in transaction in order to ensure the data consistency.
