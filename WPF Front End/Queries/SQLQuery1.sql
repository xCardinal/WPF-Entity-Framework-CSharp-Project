Insert into Users (UserName, Password, ContactName, Status, Type)
values('spYagami', 'HelloWorld', 'Sergio', '1', 'admin')

select *
from Users

UPDATE Users
SET ContactName = 'Jason Derulo'
WHERE UserID = 12;
