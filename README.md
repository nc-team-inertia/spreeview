# Spreeview 🎬

![Animation1](https://github.com/user-attachments/assets/e0eadda5-d6de-4cb0-a522-ffbcde51c2fe)

Spreeview is a social networking app designed for users to review and comment on trending and popular TV series. The application features a modern Blazor and Tailwind CSS front end and an ASP.NET Core Web API back end that integrates with the TMDb (The Movie Database) API. It also utilizes ASP.NET Core Identity for secure authentication.

## Table of Contents
- [Introduction](#introduction)
- [Features](#features)
- [Technologies](#technologies)
- [Installation](#installation)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

## Introduction
Spreeview aims to create an engaging community for TV series enthusiasts. Users can share their thoughts on various shows, engage in discussions, and stay updated on trending content. With a sleek and responsive interface, Spreeview offers an immersive experience for all users.

## Features
- User Registration and Login
- Cookie Authentication with ASP.NET Core Identity
- Review and Comment on TV Series
- Fetch Trending and Popular TV Series from TMDb API
- Responsive User Interface with Blazor and Tailwind CSS
- Secure API Endpoints

## Technologies
- **Backend**: ASP.NET Core Web API
- **Frontend**: Blazor, Tailwind CSS
- **Authentication**: ASP.NET Core Identity
- **External API**: TMDb API
- **Database**: SQL Server
- **Hosting**: Azure (Optional)

## Installation
### Prerequisites
- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [TMDb API Key](https://www.themoviedb.org/documentation/api)
- [Node.js / NPM](https://nodejs.org/en)

### Backend
1. Clone the repository:
    ```bash
    git clone https://github.com/yourusername/spreeview.git
    cd spreeview/Backend
    ```

2. Update the `appsettings.json` file with your SQL Server connection string and TMDb API key.

3. Run the following command to restore dependencies and build the project:
    ```bash
    dotnet restore
    dotnet build
    ```

4. Apply database migrations:
    ```bash
    dotnet ef database update
    ```

5. Start the backend server:
    ```bash
    dotnet run
    ```

### Frontend

1. Navigate to the frontend server project directory:
    ```bash
    cd ./SpreeviewFrontend/SpreeviewFrontend
    ```

2. Install Node.js dependencies:
   ```bash
   npm install
   ```

3. Build Node.js dependencies:
   ```bash
   npm run build
   ```

4. Navigate back to the frontend project directory:
    ```bash
    cd ../
    ```

5. Restore dependencies and build the project:
    ```bash
    dotnet restore
    dotnet build
    ```

6. Start the Blazor server:
    ```bash
    dotnet run
    ```

## Usage
1. Open your browser and navigate to `http://localhost:5000` for the backend and `http://localhost:5001` for the frontend.
2. Register a new account or log in with existing credentials.
3. Explore trending and popular TV series, post reviews, and engage in discussions.

## Contributing
Contributions may be opened in the future but for now, please raise an issue and we'll look into it.

## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contributors 🔗
https://github.com/thecodingrunner
https://github.com/cghlee
https://github.com/Syntrice
https://github.com/Metajjj
https://github.com/nick-midmore

