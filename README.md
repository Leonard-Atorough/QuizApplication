# Quiz-Application

---

## Project Overview

---

### Project Goal

The project should allow teachers and students to interact with it in different ways. Both users will be able to create and login to accounts on the application. The teachers will be able to create questions which they can then assign to their students as quiz sets. The students will be able to solve these quiz sets and submit their results back to the respective teacher for review and marking. The application can be beneficial for remote and in-class testing.



### Definition of Done

The application will be defined as done when the minimum viable product, as laid out in the project board, has been achieved. At such a point, features of the application will come under review and any additions and alterations can be planned for future sprints.



### Class Diagrams

![](https://raw.githubusercontent.com/Leonard-Atorough/QuizApplication/Dev/Kanban%20pictures/Class%20Diagram.PNG)

---



## Sprint Documentation

---



### Sprint 1 - Tuesday 1st December 2020

---

By the end of this sprint I aimed to have a three tier application structured with a business layer, a model layer and a basic GUI. At this point I wanted to have the foundations laid down without implementing any CRUD functionality between the business and GUI layers.

![](https://raw.githubusercontent.com/Leonard-Atorough/QuizApplication/Dev/Kanban%20pictures/SprintOne%20start.PNG)



#### Sprint Goals

- [x] Complete user story 0.1 - Create and scaffold database
- [x] Complete user story 0.2  - Create business layer
- [x] Complete user story 0.3 - create basic GUI
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

- [x] Complete user story 0.4 - Added resources to App.Xaml
- [x] Complete user story 1.1 - Teacher login functionality
- [x] Complete user story  1.2 - Teacher signup functionality
- [x] Complete user story 2.1 - List of assigned students
- [x] Complete user story 2.2 - List of all students
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

---



### Sprint 3 - 03/12/2020

---

The aim of this spring was to finish implementing the functions of the teachers landing page where he/she could manage their students by adding and removing students from their personal class list. Additionally, the sprint also aimed to have a working question page with the ability to create and delete questions from a question bank.

![](https://raw.githubusercontent.com/Leonard-Atorough/QuizApplication/Dev/Kanban%20pictures/SprintThree%20start.PNG)

#### Sprint Goals

- [x] Complete user story 2.2.1 - Student list search bar
- [x] Complete user story 2.2.2 - Add student from general list to class list
- [x] Complete user story  2.2.3 - Remove student from class list
- [x] Complete user story 3.1 - See list of created questions
- [x] Complete user story 3.1.2 - Add questions from question list
- [x] Complete user story 3.1.3 - Remove questions from question list
- [x] Complete sprint documentation
- [x] Complete sprint retrospective
- [x] Update README
- [x] Push changes to remote repo

#### Sprint Review

The goals of the sprint were met. One blocker was in implementing the search bar feature which was cleared with the help of other developers in the team. All functionality implemented was tested manually as unit testing for critical methods has not been implemented yet which suggests unforeseen bugs could lie in the code.

#### Sprint Retrospective

As with the previous sprint, the lack of unit testing is concerning but manual testing has proven sufficient for catching fault or incomplete logic in the program. As previously mention, unit tests will be implemented to test the reaches of the program and explore edge cases, even those already covered.

![](https://raw.githubusercontent.com/Leonard-Atorough/QuizApplication/Dev/Kanban%20pictures/SprintThree%20end.PNG)

---



### SPRINT 4 - 04/12/2020 to 05/12/2020

---

The aim of the fourth sprint was the completion of the teacher functionality as well as developing the login events and functions for the student side of the application. The teacher side of the application would have the ability to create new quizzes, delete existing quizzes and update the questions within those quizzes at will. The students would be able to login or signup and see the quizzes their teachers have made.

![](https://raw.githubusercontent.com/Leonard-Atorough/QuizApplication/Dev/Kanban%20pictures/SprintFour%20start.PNG)



#### Sprint Goals

- [x] Complete user story 3.1.3 - Student list search bar
- [x] Complete user story 3.2 - Add student from general list to class list
- [x] Complete user story  3.2.1 - Remove student from class list
- [x] Complete user story 4.1 - See list of created questions
- [x] Complete user story 4.2 - Add questions from question list
- [x] Complete user story 6.1 - Remove questions from question list
- [x] Complete sprint documentation
- [x] Complete sprint retrospective
- [x] Update README

#### Sprint Review

The sprint was originally planned as a one day sprint but ended up covering two days due to multiple interruptions. The goals of the sprint were met and then exceed. The application, as currently planned, was completed by the end of the sprint with the remaining work being tests to ensure the robustness of application functionality.

#### Sprint Retrospective

The sprint was not planned as efficiently and many distractions and interruptions caused the sprint to extend over two days. However, a lot of tasks were accomplished and the application benefited from the extended sprint. More tasks than planned were completed and many bugs and crashes were fixed the the process. The main takeaway from this sprint was that many application functions needed expanded manual testing. Intentionally breaking the application in order to reveal errors proved useful as a means of testing.

---



### Sprint 5 - 06/12/2020

---

The fifth sprint aimed at achieving beyond the MVP and completing the application to a functioning and usable state. This sprint also focused on addressing encountered exception situations in order to make the application more robust and less prone to unceremonious crashes.

![](https://raw.githubusercontent.com/Leonard-Atorough/QuizApplication/Dev/Kanban%20pictures/SprintFive%20start.PNG)

- [x] Complete user story 7.1 - Improve GUI
- [x] Complete user story 7.2 - Add application robustness
- [x] Complete user story  7.2.1 - Delete functions will not cause crashes
- [x] Complete sprint documentation
- [x] Complete sprint retrospective
- [x] Update README

#### Sprint Review

This sprint was shorter than the other sprint. While the sprint goals were achieved, the planning was more lax than in previous sprints. This directly contributed to a vagueness of the user stories associated. The work completed was also more disjointed and lacked as much clarity as with previous sprints. Despite this, the product was manually tested and successfully worked, the GUI was improved overall and the smoothness of the menus was updated.

#### Sprint Retrospective

As a penultimate sprint, the sprint was useful in ensuring the application was in a state where it could be shown off. Being held on a Sunday, the sprint was cut short by other life events which are unavoidable. The sprint also felt less rigorous than previous sprints. Two key lessons learned would be more unit testing and better estimation of worked required to deliver successful product.

![](https://raw.githubusercontent.com/Leonard-Atorough/QuizApplication/Dev/Kanban%20pictures/SprintFive%20end.PNG)