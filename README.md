# MY LIBRARY

## Overview
**My Library** is a web application designed to serve as a digital library. It allows verified users to add and retrieve information about books within a digital library environment. The application consists of a backend built on the .NET Framework and a frontend developed with Angular. It offers a robust set of features, including user authentication, book management, and dynamic search capabilities.

---

## Table of Contents
- [Overview](#overview)
- [Technologies Used](#technologies-used)
  - [Backend](#backend)
  - [Frontend](#frontend)
- [Backend Functionality](#backend-functionality)
  - [Architecture](#architecture)
  - [Authentication](#authentication)
- [Frontend Functionality](#frontend-functionality)
  - [Components](#components)
  - [Services](#services)
- [Installation and Setup](#installation-and-setup)
- [Usage](#usage)
- [License](#license)
- [Contact](#contact)

---

## Technologies Used

### Backend
- **.NET Framework**: Core framework for developing the backend.
- **Swagger UI**: For testing and documenting backend API endpoints.
- **JWT Authentication**: Ensures secure access to the API endpoints.
- **MySQL Management Studio**: Used as the database for storing application data.

### Frontend
- **NodeJS**: Runtime environment for the frontend build tools.
- **Angular**: Framework for building the single-page application.
- **Express JS**: Used for serving the frontend and handling API proxy requests if needed.
- **Nodemon**: Utility for automatically restarting the server during development.
- **Bootstrap**: Provides responsive design and styling.

---

## Backend Functionality

### Architecture
The backend is organized into three main modules:

1. **Module Layer**  
   Responsible for setting up and populating the database. This layer defines all the model elements and the rules for data storage.

2. **Application Layer**  
   Contains all the services required for the application's business logic. Key services include:
   - **BookService**
   - **CategoryService**
   - **BookCategoryService**
   - **UserService**
   - **TokenService**

3. **Web Layer**  
   Provides the controllers and endpoints that allow external users to interact with the system.

**Data Models**  
The application manages three main entities:
- **Users**
- **Books**
- **Categories**

Each book must be associated with at least one category, though a book can belong to multiple categories. The application enforces strict rules for data entry, such as:
- Validating email addresses using regular expressions.
- Enforcing a minimum password length of 8 characters, which must include a special character, a number, and an uppercase letter.
- Preventing the insertion of duplicate books or categories.

### Authentication
The web layer requires users to log in before performing any data modifications or retrieval. The login process generates a JWT (JSON Web Token) valid for 30 minutes. This token must be included in the authorization header for all secured API requests.

---

## Frontend Functionality

The frontend is developed using Angular and provides a user-friendly interface with the following features:

### Components
1. **AppComponent**  
   Serves as the main layout component featuring a navigation bar, a footer, and a router outlet to navigate between pages.

2. **HomeComponent**  
   The main landing page that welcomes users and prompts them to log in to access the services.

3. **LoginComponent**  
   Presents a login form where users can enter their credentials. This component communicates with the backend via a dedicated service to validate the input. Upon successful login, the user's name is displayed on the Home page.

4. **RegisterComponent**  
   Accessible from the Login page for users who do not have an account. This component provides a registration form requiring details such as first name, last name, email, and password. It communicates with the backend to create a new user account and redirects to the login page upon successful registration.

5. **AppServiceComponent**  
   Lists the services available within the application, such as searching for a book and adding a new book.

6. **AddBookComponent**  
   Provides a form to add a new book to the system. On initialization, it fetches the list of available categories from the backend so users can select one or more categories when adding a book.

7. **SearchComponent**  
   Offers filtering options for book searches. Users can choose to search by author name, book title, or genre.

8. **SearchDetailsComponent**  
   Enables detailed book searches based on the selected filters. It dynamically retrieves and displays books matching the entered criteria, showing details such as title, author, and genres.

### Services
1. **UserService**  
   Manages login and logout functionalities. It sets the username upon successful login and removes the token upon logout.

2. **SearchCategoriesService**  
   Handles the retrieval of available book categories from the backend.

3. **SearchBookService**  
   Facilitates querying the backend to retrieve books that match the search criteria.

4. **AuthService**  
   Manages authentication tasks, including login and registration processes, by interacting with the respective backend endpoints.

5. **Interceptor**  
   Intercepts HTTP requests to append the JWT token in the authorization header, ensuring that subsequent API calls are authenticated.

---

## Installation and Setup

### Prerequisites
- [.NET Framework](https://dotnet.microsoft.com/) installed on your system.
- [NodeJS](https://nodejs.org/) and [npm](https://www.npmjs.com/) for frontend dependencies.
- [MySQL](https://www.mysql.com/) for the database.

### Backend Setup
1. Clone the repository.
   ```bash
   git clone <repository-url>
2. Open the solution in your preferred .NET IDE.

3. Restore the NuGet packages.

4. Configure the connection string for MySQL in the application settings.

5. Run the backend application using your IDE or via command line.

---

## Usage

### User Authentication
Users must log in to access the full functionality of the application. Upon logging in, a JWT token is generated and used to authorize further API calls.

### Adding a Book
Navigate to the "Add Book" section, fill in the required details (including selecting at least one category), and submit the form to add a new book to the digital library.

### Searching for Books
Use the search components to filter and retrieve books based on title, author, or category. The search interface updates dynamically as you type.

---

## License
This project is licensed under the MIT License.

---

## Contact
For any questions or further information, please contact:

- Email: al.antognozzicaraffa@studenti.unicam.it



