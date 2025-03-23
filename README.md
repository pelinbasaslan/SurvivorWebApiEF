Here’s a **README** file for your **Survivor Web API** project, detailing the purpose, setup, and how to interact with the API. This can be helpful for anyone working on or using the API.

---

# Survivor Web API

This is a Web API built for managing **Survivor** competition data. It includes two main entities: **Competitors** and **Categories**, with CRUD operations for both entities. Competitors are linked to Categories in a one-to-many relationship.

## Features
- **Competitors**: Represents a participant in the competition.
- **Categories**: Represents categories in which competitors participate.
- **CRUD Operations**:
    - Create, Read, Update, and Delete operations for both **Competitors** and **Categories**.

## Endpoints

### CompetitorController

#### 1. GET `/api/competitors`
   - **Description**: Lists all competitors.
   - **Response**: Returns a list of all competitors.

#### 2. GET `/api/competitors/{id}`
   - **Description**: Fetches a specific competitor by their ID.
   - **Parameters**:
     - `id` (int): The ID of the competitor to fetch.
   - **Response**: Returns the details of the competitor with the specified ID.

#### 3. GET `/api/competitors/categories/{CategoryId}`
   - **Description**: Lists all competitors in a specific category.
   - **Parameters**:
     - `CategoryId` (int): The ID of the category for filtering competitors.
   - **Response**: Returns a list of competitors belonging to the specified category.

#### 4. POST `/api/competitors`
   - **Description**: Creates a new competitor.
   - **Request Body**:
     ```json
     {
       "name": "Competitor Name",
       "categoryId": 1
     }
     ```
   - **Response**: Returns the created competitor object.

#### 5. PUT `/api/competitors/{id}`
   - **Description**: Updates the information of a specific competitor.
   - **Parameters**:
     - `id` (int): The ID of the competitor to update.
   - **Request Body**:
     ```json
     {
       "name": "Updated Name",
       "categoryId": 2
     }
     ```
   - **Response**: Returns the updated competitor object.

#### 6. DELETE `/api/competitors/{id}`
   - **Description**: Deletes a specific competitor by their ID.
   - **Parameters**:
     - `id` (int): The ID of the competitor to delete.
   - **Response**: Returns a status indicating success or failure.

### CategoryController

#### 1. GET `/api/categories`
   - **Description**: Lists all categories.
   - **Response**: Returns a list of all categories.

#### 2. GET `/api/categories/{id}`
   - **Description**: Fetches a specific category by its ID.
   - **Parameters**:
     - `id` (int): The ID of the category to fetch.
   - **Response**: Returns the details of the category with the specified ID.

#### 3. POST `/api/categories`
   - **Description**: Creates a new category.
   - **Request Body**:
     ```json
     {
       "name": "Category Name"
     }
     ```
   - **Response**: Returns the created category object.

#### 4. PUT `/api/categories/{id}`
   - **Description**: Updates the information of a specific category.
   - **Parameters**:
     - `id` (int): The ID of the category to update.
   - **Request Body**:
     ```json
     {
       "name": "Updated Category Name"
     }
     ```
   - **Response**: Returns the updated category object.

#### 5. DELETE `/api/categories/{id}`
   - **Description**: Deletes a specific category by its ID.
   - **Parameters**:
     - `id` (int): The ID of the category to delete.
   - **Response**: Returns a status indicating success or failure.

## Database

### Tables

- **Competitors**: Represents participants in the Survivor competition.
  - `Id` (int, Primary Key)
  - `Name` (string)
  - `CategoryId` (int, Foreign Key to Category)

- **Categories**: Represents competition categories.
  - `Id` (int, Primary Key)
  - `Name` (string)

### Entity Relationships
- One **Category** can have many **Competitors**.
- Each **Competitor** belongs to one **Category**.

## Setup Instructions

### Prerequisites
- .NET 8 or above
- PostgreSQL (or your preferred database)
- Visual Studio or VSCode (optional)

### Steps

1. **Clone the repository**:
    ```bash
    git clone https://github.com/your-repository-url.git
    cd your-repository-folder
    ```

2. **Restore dependencies**:
    ```bash
    dotnet restore
    ```

3. **Configure the database**:
    - Update the connection string in the `appsettings.json` file.
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Host=localhost;Database=survivor_db;Username=your_username;Password=your_password"
    }
    ```

4. **Create and apply migrations**:
    ```bash
    dotnet ef migrations add InitialCreate
    dotnet ef database update
    ```

5. **Run the application**:
    ```bash
    dotnet run
    ```

6. **Test the API**:
    - Open Postman or any API testing tool and start testing the endpoints mentioned above.

## Technologies Used
- .NET 8 (C#)
- Entity Framework Core
- PostgreSQL
- ASP.NET Core Web API

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

This **README** provides a complete overview of the **Survivor Web API** project, detailing how to set up the API, interact with it, and understand the relationships between entities. You can modify it based on your personal setup or any additional features.