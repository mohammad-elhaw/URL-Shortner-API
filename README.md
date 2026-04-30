# URL Shortener API

A scalable and production-style URL Shortener system inspired by services like Bitly.  
Built with a strong focus on **Clean Architecture**, **Modular Monolith design**, and **Event-Driven principles** to simulate real-world backend systems.

---

## Overview

This project allows users to:

- Convert long URLs into short, shareable links
- Redirect users to original URLs efficiently
- Track and analyze URL usage (clicks, user agents, IPs)
- Retrieve analytics per shortened URL

The main goal of this project is not just functionality, but **applying real-world software architecture principles in a practical system**.

---

## Architecture

The system is designed using:

### Modular Monolith Architecture
Each feature is isolated as an independent module while still deployed as a single application.

### Clean Architecture
Clear separation of concerns:

- **Domain Layer** → Business rules & core entities
- **Application Layer** → Use cases & business workflows
- **Infrastructure Layer** → Database, external services
- **API Layer** → Controllers & endpoints

### Event-Driven Design
Analytics are handled asynchronously using events to avoid blocking the main request flow.

---

## Modules

### URL Shortener Module
- Create short URLs
- Generate unique short codes
- Store URL mappings

### Redirection Module
- Resolve short URLs
- Handle HTTP redirects
- Increment usage tracking

### Analytics Module
- Track visits (IP, User-Agent, timestamp)
- Store click events
- Provide usage statistics APIs

---

## Features

- Fast URL shortening
- High-performance redirection
- Click tracking system
- Analytics per URL
- Event-driven logging
- Scalable modular design

---

## Tech Stack

- .NET 10 / ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Docker
- MediatR (CQRS pattern)
- CAP + RabbitMQ (event-driven communication)
- Clean Architecture principles

---

## How It Works

1. User submits a long URL
2. System generates a unique short code
3. Mapping is stored in database
4. When user accesses short URL:
   - System resolves original URL
   - Redirect happens instantly
   - Event is published for analytics
5. Analytics module stores visit data asynchronously

