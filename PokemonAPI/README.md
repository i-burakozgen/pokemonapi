Overview

This project is a web API that provides CRUD (Create, Read, Update, Delete) operations for managing Pokémon data. The backend is built with C# using ASP.NET Core, and the database is powered by PostgreSQL. The API manages various relationships such as one-to-many and many-to-many between entities like Pokémon, Owners, Categories, and Reviews also basic mapping to not return null values added.

Features

CRUD Operations: Manage Pokémon, Owners, Categories, and Reviews.
Database: PostgreSQL is used for storing data with complex relationships.

Entity Relationships:
One-to-Many: For example, one owner can have many Pokémon.
Many-to-Many: For example, Pokémon can belong to multiple categories.
