ADD YOUR IMPLEMENTATIONS HERE
## Layer architecture

 -Application
  -Services
 -Domain
  -Interfaces
  -Models
 -Infrastructure
  -Data
  -Migrations
 -WebAPI
  -Controllers
  -Registrations (added DI conteiner to make Program.cs lighter and controle components separately)
  

## Services

### 1. **BookService**
Service to receive books that meet the given terms from the letter.

#### Methods

- **GetBook()**
 - **Description**: Get book with the highest published circulation value.
 - **Return**: Book: "Even coolest story".

 - **GetBooks()**
  - **Description**: Get books with the title "Red" and published after the release of the album "Carolus Rex" by Sabaton.
  - **Return**: Book: "The Red Army".

### 2. **AuthorService**
Service to receive books that meet the given terms.

#### Methods
- **GetAuthor()**
 - **Description**: Author, who wrote the book with the longest title ( if there are several such authors, the author must be returned with the smallest Id).
 - **Return**: Author: Ivan Karpov, id =2.

#### Methods
- **GetAuthor()**
 - **Description**: Authors, who have written an equal number of books published after 2015.
 - **Return**: Authors: Ivan Karpov, id =2; Pavel Doe, id=3; Frank Sidorov, id =6.




