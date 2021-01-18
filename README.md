

# ![](https://github.com/HokaHelal/Madrasa/blob/main/docs/Logo.PNG)Madrasa

[LIVE DEMO](https://madrasa1.herokuapp.com/)

Madrasa is a open source remote learning platform for schools, universities or any learning institutions need digital learning system for remote online learning.

The application is a ASP Core (.Net 5.0) web application using entityframework code with angular (10.2.1).

## Getting Started
- Create empty database and update connectionstring in appsettings.json in Madrasa.API
```sh
"ConnectionStrings": {
    "DefaultConnectionString": "YOUR_CONNECTIONSTRING"
  },
```
- Run application (F5) the Login screen should be shown
![](https://github.com/HokaHelal/Madrasa/blob/main/docs/Login.PNG)
- You can login with either (Pope) or (Guy) student account.
- The main page will shown (currently forums module) as default page
  ![](https://github.com/HokaHelal/Madrasa/blob/main/docs/Forum.PNG)

## Architecture Features
1. Layers separation (Model, Repository, API) each layer is encapsulated and has their responsibility  
2. Apply generic repository pattern in case of adding extra models
3. Dependency injection for repository 
4. Using git flow process (develop, main branches) while committing to source control
5. Clean code (clear variables, methods,...)
6. Checking and updating migrations every startup (run)  

## Third Parties

**Angular** (NPM)

1. [AdminLTE V3.1.0-rc](https://adminlte.io/themes/v3/index3.html) : for layout theme and template 
2. [Quill](https://quilljs.com/) : rich text editor and also [Quill-Emoji](https://www.npmjs.com/package/quill-emoji) integration.
3. [Fontawesome](https://fontawesome.com/) : for icon libraries
4. [Bootstrap](https://getbootstrap.com/) : for responsive style 

**ASP Core** (Nuget)

1. [NLog](https://nlog-project.org/) : Flexible & free open-source logging for .NET

## Screenshots

![](https://github.com/HokaHelal/Madrasa/blob/main/docs/Forum.PNG)

![](https://github.com/HokaHelal/Madrasa/blob/main/docs/EmptySection.PNG)

![](https://github.com/HokaHelal/Madrasa/blob/main/docs/Section.PNG)

![](https://github.com/HokaHelal/Madrasa/blob/main/docs/NewTopic.PNG)

![](https://github.com/HokaHelal/Madrasa/blob/main/docs/Topic.PNG)

![](https://github.com/HokaHelal/Madrasa/blob/main/docs/Post.PNG)

![](https://github.com/HokaHelal/Madrasa/blob/main/docs/Likes.PNG)

## Future Roadmap

The following modules intended to shape the main 

- [x] **Forums** : aims to collaboration area between students to ask questions and share knowledge
- [ ] **Class-room** : for online video streams for courses and lectures with whiteboard and share screen facilities
- [ ] **Calendar** : to organize all live courses appointments
- [ ] **Members** : to view students profile of same class
- [ ] **Public Chat** : group chat for all students in same class
- [ ] **Dashboard** : to view and monitor upcoming courses and latest threads 
- [ ] **Admin Panel** : add, edit users, roles, workflow and data