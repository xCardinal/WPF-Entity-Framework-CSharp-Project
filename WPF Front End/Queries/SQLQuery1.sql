Insert into Users (UserName, Password, ContactName, Status, Type)
values('xCardinal', '12345', 'Sergio', '1', 'admin')

insert into Movies(CategoryName, MovieName)
values('Fantasy','Harry Potter and the Philosopher"s Stone')

insert into Movies(CategoryName, MovieName)
values('Fantasy','Harry Potter and the Chamber of Secrets')

insert into Movies(CategoryName, MovieName)
values('Fantasy','Harry Potter and the Prisoner of Azkaban')

insert into Movies(CategoryName, MovieName)
values('Fantasy','Harry Potter and the Goblet of Fire')

select *
from Users u
join MovieFavourites mf on u.UserId = mf.UserId

select *
from Users

select *
from Movies




