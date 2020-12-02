# Quiz-Application

---

## Project Overview

---

### Project Goal

The project should allow teachers and students to interact with it in different ways. Both users will be able to create and login to accounts on the application. The teachers will be able to create questions which they can then assign to their students as quiz sets. The students will be able to solve these quiz sets and submit their results back to the respective teacher for review and marking. The application can be beneficial for remote and in-class testing.



### Definition of Done

The application will be defined as done when the minimum viable product, as laid out in the project board, has been achieved. At such a point, features of the application will come under review and any additions and alterations can be planned for future sprints.



### Class Diagrams



---



## Sprint Documentation

---



### Sprint 1 - Tuesday 1st December 2020

---

By the end of this sprint I aimed to have a three tier application structured with a business layer, a model layer and a basic GUI. At this point I wanted to have the foundations laid down without implementing any CRUD functionality between the business and GUI layers.

![](https://raw.githubusercontent.com/Leonard-Atorough/QuizApplication/Dev/Kanban%20pictures/SprintOne%20start.PNG)



#### Sprint Goals

- [x] Complete user story 0.1
- [x] Complete user story 0.2
- [x] Complete user story 0.3
- [x] Complete sprint documentation
- [x] Complete sprint retrospective
- [x] Update README
- [x] Push changes to remote repo

#### Sprint Review

The database was completed and displayed as expected. The structure of the database had a backing ERD. Basic crud methods were created to populate the business layer. Some issues were encountered when attempting to add background images to the GUI layer and page issues took some time to resolve.

#### Sprint Retrospective

A key aim to improve productivity is the overall clarity of user stories. As visible in the two images attached to the sprint, certain acceptance criteria were edited at the end of the sprint. In the future, changes to acceptance criteria will be made before the commencement of that sprint.

![](https://raw.githubusercontent.com/Leonard-Atorough/QuizApplication/Dev/Kanban%20pictures/SprintOne%20end.PNG)

---



### Sprint 2 - Wednesday 2nd December

---

By the end of the second sprint the goal was to have implemented the login and signup functionality for teachers comprehensively so that teachers could create accounts (but not duplicates), and login to their accounts if they existed on the database. Additionally, a further goal was to give the teacher the ability to view a list of their students.

![](https://raw.githubusercontent.com/Leonard-Atorough/QuizApplication/Dev/Kanban%20pictures/SprintTwo%20start.PNG)

#### Sprint Goals

- [x] Complete user story 0.4
- [x] Complete user story 1.1
- [x] Complete user story  1.2
- [x] Complete user story 2.1
- [x] Complete user story 2.2
- [x] Used methods tested
- [x] Complete sprint documentation
- [x] Complete sprint retrospective
- [x] Update README
- [x] Push changes to remote repo

#### Sprint Review

The goals of the sprint were met as expected with the only blocker being the implementation of instance based pages once the teacher had logged in. However, after much research the function allowing the teacher to view a list of his own students was successfully implemented. Additionally, improving the GUI was an unplanned by beneficial activity which helped improve the quality of the product at sprint end.

#### Sprint Retrospective

A major takeaway from this sprint would be the current lack of rudimentary unit testing to back up the implemented functionality. Although manual testing has proven sufficient so far it has been clear that unit testing would have alleviated (or at the very least added clarity) to some issues faced in the later stages of the sprint. In the future basic unit tests will be implemented to ensure that issues in the product are not being generated at the business layer.

![](https://raw.githubusercontent.com/Leonard-Atorough/QuizApplication/Dev/Kanban%20pictures/SprintTwo%20end.PNG)