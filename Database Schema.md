```mysql
DROP TABLE StudentTeacher
DROP TABLE StudentQuiz
DROP TABLE StdentAnswers
DROP TABLE Quiz
DROP TABLE Questions
DROP TABLE Students
DROP TABLE Teachers

CREATE TABLE Students (
    StudentId int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    StudentName varchar(50),
    StudentPassword varchar(16),
    StudentEmail varchar (50)
);

CREATE TABLE Teachers (
    TeacherId int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    TeacherName varchar(50),
    TeacherPassword varchar(16),
    TeacherEmail varchar(50)
);

CREATE TABLE StudentTeacher (
    StudentId int FOREIGN KEY REFERENCES Students(StudentId),
    TeacherId int FOREIGN KEY REFERENCES Teachers(TeacherId),
    CONSTRAINT PK_StudentTeacher PRIMARY KEY (StudentId, TeacherId)
);

CREATE TABLE Quiz (
    QuizId int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    QuizName varchar(25)
)

CREATE TABLE Questions (
    QuestionId int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    QuizId int FOREIGN KEY REFERENCES Quiz(QuizId),
    TeacherId int FOREIGN KEY REFERENCES Teachers(TeacherId),
    Question varchar(150)
);

CREATE TABLE StudentQuiz (
    StudentId int FOREIGN KEY REFERENCES Students(StudentId),
    QuizId int FOREIGN KEY REFERENCES Students(StudentId),
    Score int,
    CONSTRAINT PK_StudentQuiz PRIMARY KEY (StudentId, QuizId)
);

CREATE TABLE StudentAnswers (
    StudentId int FOREIGN KEY REFERENCES Students(StudentId),
    QuestionId int FOREIGN KEY REFERENCES Students(StudentId),
    Answer varchar(200),
    CONSTRAINT PK_StudentAnswers PRIMARY KEY (StudentId, QuestionId)
);
```

