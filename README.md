# **Engineering 91 : WPF-Entity Framework C# Project**

**Deadline – Tuesday 24th August 9:30 am**

### Project Goal
User friendly, Mobile Database, app where the user can keep track of favourited movies and their trailers.

### Definition of Done
·	All code (Test and Mainline) Checked in.
·	All Unit Tests Passing.
·	Functional Tests Passing.
·	All Acceptance Tests Identified, Written and Passing.

---

### Sprint 1

**Sprint Goals:** 

1. Create the classes and set up the database.
2. Write down User Stories and place them in the Project Backlog.

**Kanban Board** at the start:

![image-20210822174319673](C:\Users\iFran\AppData\Roaming\Typora\typora-user-images\image-20210822174319673.png)

**Sprint Review:** 

- All of the classes were implemented.
- Database was created.
- 1st Part of the 1st Epic -The Login/Register Window - was implemented.

**Sprint Retrospective:** Spent too long trying to understand the inner works of the Entity framework as opposed to simply creating the classes and letting EF do its thing.

**Kanban Board** at the end:

![image-20210822174428896](C:\Users\iFran\AppData\Roaming\Typora\typora-user-images\image-20210822174428896.png)


### Sprint 2

**Sprint Goal:** Complete the first epic. 

**Kanban Board** at the start:

![image-20210822174537038](C:\Users\iFran\AppData\Roaming\Typora\typora-user-images\image-20210822174537038.png)

**Sprint Review:** 

- The first user stories, that made up the 1st Epic, were processed and added to the Sprint Backlog.
- User System fully implemented and tested.
- 2nd Part of the 1st Epic - Business Layer - completed.
- 1st Epic Fully Completed.

**Sprint Retrospective:** The way how the accounts were set up offers no real protection to the user. This, however, is outside of the scope of the project.

**Kanban Board** at the end:

![image-20210822174610137](C:\Users\iFran\AppData\Roaming\Typora\typora-user-images\image-20210822174610137.png)

### Sprint 3

**Sprint Goal:** Start the 1st Epic - Implement the ability to browse the database.

**Kanban Board** at the start:

![image-20210822174638320](C:\Users\iFran\AppData\Roaming\Typora\typora-user-images\image-20210822174638320.png)

**Sprint Review:** 

- NEW Main Window created to host the multiple lists of movies.
- 1st Part of the 2nd Epic completed. - The user can now browse movie names.

**Sprint Retrospective:** I might have to improve my `FavouriteMovies` class to allow the favouriting of movies.

**Kanban Board** at the end:

![image-20210822174919674](C:\Users\iFran\AppData\Roaming\Typora\typora-user-images\image-20210822174919674.png)

### Sprint 4

**Sprint Goal:** Finish the 2nd Epic - Let the user add the movies to its favourites list.

**Kanban Board** at the start:

![](C:\Users\iFran\AppData\Roaming\Typora\typora-user-images\image-20210822174754884.png)

**Sprint Review:** 

- 2nd Part of the 2nd Epic completed. - The user can now add movies to its favourites.
- 2nd Epic Fully Completed.
- NEW user story created.

Fixed a bug where an user favouring a movie would unfavourite the same movie in another user's account.

**Sprint Retrospective:** Focus on the implementation of the Trailer System.

**Kanban Board** at the end:

![image-20210822175057231](C:\Users\iFran\AppData\Roaming\Typora\typora-user-images\image-20210822175057231.png)


### Sprint 5

**Sprint Goal:** Implement the Trailer System.

**Kanban Board** at the start:

![image-20210822175121309](C:\Users\iFran\AppData\Roaming\Typora\typora-user-images\image-20210822175121309.png)

**Sprint Review:** 

- The base `Movie` class was changed in order for the movies to allow trailers.
- The trailer paths were loaded into a new Property in `Movies`.
- Movie trailers now play, provided the video exists locally and the path is properly formatted.

**Sprint Retrospective:** I have learnt that there are APIs that can be used to download data as required instead of having to populate my database manually. This is something I will be looking into.

**Kanban Board** at the end:

![image-20210822175139042](C:\Users\iFran\AppData\Roaming\Typora\typora-user-images\image-20210822175139042.png)



#### Class Diagram

![image-20210822175229697](C:\Users\iFran\AppData\Roaming\Typora\typora-user-images\image-20210822175229697.png)

#### Overall Project Retrospective

I disliked the fact that I could not get the API to work and had to, therefore, populate the database manually instead of automatically. Given more time I would, definitely, work on implementing this feature as well as another one that would allow me to pull videos from the web instead of having to store them locally.

Nevertheless, I have learnt how to build an application, however simple, with the Windows Presentation Foundation (WPF)[^fn1] sub-system. Furthermore, I have also learnt how to write XAML, use useful extensions and how to work withing an agile environment.



[^fn1]: Free and open-source graphical subsystem originally developed by  Microsoft for rendering user interfaces in Windows-based applications. 

