# MultiShop Project - Microservices Architecture Overview
## Project Description

MultiShop is a highly scalable and flexible e-commerce platform built using a microservices architecture. The project consists of independent services, each responsible for a specific business function.

**Technologies Used**

**.NET 6:**  The primary programming language for all microservices
**Docker:** Containerization tool
**SQL Server:** Database used for OrderDb and IdentityDb
**MongoDB:** NoSQL database used for the Catalog microservice
**Dapper:** ORM used in the Discount microservice
**Onion Architecture:** Architecture used in the Order microservice
**CQRS:** Command Query Responsibility Segregation pattern used in the Order microservice
**Mediator:** Mediator pattern used in the Order microservice
**JWT:** JSON Web Tokens used for user authentication
**IdentityServer:** Identity and access management system

## Microservices

**Catalog:** Manages the product catalog and stores data in MongoDB.
**Order:** Manages orders. Developed using Onion architecture, CQRS, and Mediator patterns.
**Discount:** Manages discounts. Uses Dapper ORM for data access.
**IdentityServer:** Provides user management, authentication, and authorization services.

## Databases and Docker

**OrderDb:** A SQL Server database used by the Order microservice. It is containerized using Docker and accessible on port 1440.
**IdentityDb:** A SQL Server database used by IdentityServer. It is containerized using Docker and accessible on port 1433.
**Docker:** Used to containerize all services and databases. The project also includes a Portainer container for managing containers.
## Authorization

User authorization is handled using JWT tokens.
**Admin** users have access to all services, while **Visitor** users can only access the Catalog microservice.
