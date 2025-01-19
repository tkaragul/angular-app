
# E-Commerce System

This project is an e-commerce application consisting of a front-end Angular (or React) client-side application and a .NET Core backend API. It allows users to browse products, add them to a shopping cart, and proceed to the checkout page. The system provides filtering, pagination, and cart functionalities. 

## Technologies Used

- **Backend**: .NET Core API
- **Frontend**: Angular (preferably) or React
- **UI Framework**: Bootstrap
- **Caching**: In-memory cache
- **ORM**: Entity Framework (optional SQLite database support)
- **Exception Handling**: Implemented for both client and server-side operations

## Features

### 1. Product Listing Page
- Displays a list of products with their names, prices, and categories.
- Filters products by price and category.
- Pagination with 10 to 30 products per page.
- Ability to add products to the shopping cart.
- A sidebar displaying the current items in the cart (product name and quantity), with the ability to update quantities.

### 2. Product Detail Page
- Displays detailed information about a selected product (name, price, category, description, and image).
- Option to add the product to the shopping cart.

### 3. Cart Page
- Displays the list of products in the cart.
- Option to update the product quantities.
- Option to remove products from the cart.
- A component on the right showing:
  - Total amount
  - Quantity of products
  - VAT calculation (20%)
  - Final total amount

## Project Setup

### Backend Setup (ASP.NET Core API)

1. Clone the backend repository.
2. Install the required dependencies:
   ```bash
   dotnet restore
   ```
3. Build and run the API:
   ```bash
   dotnet build
   dotnet run
   ```

### Frontend Setup (Angular / React)

1. Clone the frontend repository.
2. Install the required dependencies:
   ```bash
   npm install
   ```
3. Serve the application:
   ```bash
   ng serve // for Angular
   npm start // for React
   ```

## Database

- The project does not require a database by default. Data can be mocked for development.
- Optionally, SQLite can be used for persistence, and Entity Framework can be utilized as the ORM.

## Error Handling

Both the frontend and backend include exception handling to ensure the application can gracefully handle errors and provide useful error messages to the user.

## In-Memory Caching

The backend uses in-memory caching for performance optimization, particularly for product listing data.

## Links

- **Products**: `/products`
- **Product Details**: `/product/{id}`
- **Cart**: `/cart`

## Future Improvements

- Implement authentication and authorization for users.
- Integrate with a payment gateway.
- Enhance UI/UX design.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
