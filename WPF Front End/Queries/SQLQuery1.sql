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

insert into Movies(CategoryName, MovieName)
values('Fantasy','Harry Potter and the Order of the Phoenix')

insert into Movies(CategoryName, MovieName)
values('Fantasy','Harry Potter and the Half-Blood Prince')

insert into Movies(CategoryName, MovieName)
values('Fantasy','Harry Potter and the Deathly Hallows: Part 1')

insert into Movies(CategoryName, MovieName)
values('Fantasy','Harry Potter and the Deathly Hallows: Part 2')

insert into Movies(CategoryName, MovieName)
values('Sci-fi/Adventure','Interstellar')

insert into Movies(CategoryName, MovieName)
values('Sci-fi/Drama','The Martian')

select *
from Users

select *
from Movies

Update Movies
SET VideoPath = 'C:\Users\iFran\Desktop\General\Sparta-Work\WPF-Entity-Framework-CSharp-Project\WPF Front End\Trailers\Insterstellar-Trailer.mp4'
WHERE MovieId = 9

Update Movies
SET VideoPath = 'C:\Users\iFran\Desktop\General\Sparta-Work\WPF-Entity-Framework-CSharp-Project\WPF Front End\Trailers\The Martian Teaser Trailer [HD] 20th Century FOX.mp4'
where MovieId = 10

Update Movies
SET VideoPath = 'C:\Users\iFran\Desktop\General\Sparta-Work\WPF-Entity-Framework-CSharp-Project\WPF Front End\Trailers\Harry Potter and the Sorcerer''s Stone (2001) Official Trailer - Daniel Radcliffe Movie HD.mp4'
where MovieId = 1
Update Movies
SET VideoPath = 'C:\Users\iFran\Desktop\General\Sparta-Work\WPF-Entity-Framework-CSharp-Project\WPF Front End\Trailers\HARRY POTTER AND THE CHAMBER OF SECRETS Trailer (2002).mp4'
where MovieId = 2
Update Movies
SET VideoPath = 'C:\Users\iFran\Desktop\General\Sparta-Work\WPF-Entity-Framework-CSharp-Project\WPF Front End\Trailers\Harry Potter and the Prisoner of Azkaban Official Trailer #1 - (2004) HD.mp4'
where MovieId = 3
Update Movies
SET VideoPath = 'C:\Users\iFran\Desktop\General\Sparta-Work\WPF-Entity-Framework-CSharp-Project\WPF Front End\Trailers\Harry Potter and the Goblet of Fire (2005) Official Trailer - Daniel Radcliffe Movie HD.mp4'
where MovieId = 4
Update Movies
SET VideoPath = 'C:\Users\iFran\Desktop\General\Sparta-Work\WPF-Entity-Framework-CSharp-Project\WPF Front End\Trailers\Harry Potter and the Order of the Phoenix (2007) Official Trailer - Daniel Radcliffe Movie HD.mp4'
where MovieId = 5
Update Movies
SET VideoPath = 'C:\Users\iFran\Desktop\General\Sparta-Work\WPF-Entity-Framework-CSharp-Project\WPF Front End\Trailers\Harry Potter and the Half-Blood Prince Official Trailer.mp4'
where MovieId = 6
Update Movies
SET VideoPath = 'C:\Users\iFran\Desktop\General\Sparta-Work\WPF-Entity-Framework-CSharp-Project\WPF Front End\Trailers\Harry Potter and the Deathly Hallows Part 1 Official Trailer #1 - (2010) HD.mp4'
where MovieId = 7
Update Movies
SET VideoPath = 'C:\Users\iFran\Desktop\General\Sparta-Work\WPF-Entity-Framework-CSharp-Project\WPF Front End\Trailers\videoplayback.mp4'
where MovieId = 8

DELETE FROM Users
WHERE UserId = 6;

Update Movies
SET VideoPath = 'C:\Users\iFran\Desktop\General\Sparta-Work\WPF-Entity-Framework-CSharp-Project\WPF Front End\Trailers\Me Before You Official Trailer #1 (2016) - Emilia Clarke, Sam Claflin Movie HD.mp4'
where MovieId = 19
