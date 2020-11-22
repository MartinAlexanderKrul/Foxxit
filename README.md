
# ASP.NET Core

  

## Topics to experience

- Extension Methods

- Async - Await

- lock/deadlock

- Task<T>

- DTO model

- Environments

- Test

- Development

- Production

- Mocking

- Authentication

- Authorization

- Google/Facebook/Twitter

- JWT Token


# Week Zero project - Forum

Let’s create an easy forum!

## General

Utilize all ASP.Net functionality to build your forum. Data will be stored in a database and handled by Entity Framework.

For user-management use Identity Framework and Implement real authentication. https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-5.0&tabs=visual-studio

## Models

**User** will have register date, username, display name, and URL for the profile picture

**Topic** will have name created date and will be linked to user who creates this topic

**Post** Post will represent one post on some Topic. It will be linked to the user. It will have content and DateTime of creation.

  

Use the entity framework to create a database.

  

## Views

  

Utilize Layout to show the main page Html, which will be included on every page. Utilize Partial views for repeating elements.

  

In all vies display names of the users and topic should be clickable

  

### - `/Login`

  

User can enter his username and login

### - `/Register`

User can create his account

Username needs to be unique

### - `/Index`

Main dashboard of the forum.

If the user is not logged in, there is nothing to show. After the user logs in topics will appear!

  

You can get inspired by the look of old PhpBB https://upload.wikimedia.org/wikipedia/commons/1/11/PhpBB_forum.png

  

This will be the summary of all Topics, If you wanna, use pagination here.

  

The topic row will display the name of the topic, the number of posts, views, and the user who wrote the last post.

### - `/Topic/{id}`

This will list all user replies in the current topic by Id.

You can take inspiration again from the PhpBB forum ( even its look like a !@#$ )

In the end, you will have a textbox that allows you to post a new post on the topic.

### - `/Userprofile/{id}`

Information page for the user by id. You will show all information about this user.

A number of posts, the last topic contains posts from this user.

### - `/Admin`

A simple form to edit your display name and change the profile picture.

## API

### - `topics/`

return simple JSON with all posts

### - `/topics/{id}`

return simple JSON with post selected by id

### - `users/`

return simple JSON with all users

### - `/users/{id}`

return simple JSON object for user by id
