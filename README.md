# SynapseCommerce

A fully decoupled microservices e-commerce platform built as a personal engineering project to explore distributed systems architecture, polyglot backend development, and modern infrastructure tooling.
This project is deliberately more complex than a storefront warrants for the express purpose of deepening my own knowledge. The goal is to build real architectural experience across services, messaging, and infrastructure rather than ship a product.

## Architecture Overview

SynapseCommerce is a monorepo housing independently deployable services that will communicate asynchronously via RabbitMQ. Each service owns its own PostgreSQL database, enforcing true data isolation and keeping the system loosely coupled at both the code and data layers.

| Service | Language / Framework | Responsibility |
|:---:|:---:|:---:|
| products-api | ASP.NET Core / C# | Product catalog management |
| customers-api | ASP.NET Core / C# | Customer accounts and profiles |
| orders-api | ASP.NET Core / C# | Order creation and lifecycle |
| inventory-api | ASP.NET Core / C# | Stock tracking and availability |
| payments-api | ASP.NET Core / C# | Payment processing |
| analytics-service | Go | Real-time metrics and event aggregation |
| frontend | React | Customer-facing storefront and analytics dashboard |

## Tech Stack

**Backend**: ASP.NET Core (.NET / C#), Go <br>
**Frontend**: React <br>
**Messaging**: RabbitMQ <br>
**Databases**: PostgreSQL (all services), Redis (analytics/high-read caching layer) <br>
**ORM**: Entity Framework Core <br>
**Containerization**: Docker, Docker Compose <br>
**Testing**: xUnit per service with dedicated test projects <br>
**Target Deployment**: AWS (local first) <br>

## Architectural Decisions

**.NET / C# for core APIs**<br>
Builds on my existing production experience while deepening API design and EF Core skills in a greenfield context with clean boundaries.

**Go for the analytics service**<br>
Go's concurrency model and lightweight goroutines are a natural fit for a real-time, read-heavy workload. Also a deliberate learning goal — building comfort in a second backend language.

**RabbitMQ for async messaging**<br>
Decouples services at the communication layer. Order placement, inventory updates, and payment events flow through a message bus rather than direct service calls, keeping each service independently deployable.

**PostgreSQL per service**<br>
Each service owns its schema and database entirely. No shared databases, no cross-service joins which enforces the bounded context pattern and makes services independently scalable.

**Redis for analytics**<br>
Planned as a caching layer for frequently read data to keep the analytics dashboard responsive under load without hammering PostgreSQL on every read.

**Monorepo structure**<br>
Reduces coordination friction for solo development. Service boundaries are enforced at the code level through a .slnx solution file linking all C# services, with independent test projects per service.

### Current Status

Active development — early stages


- [x] Monorepo scaffolded with .slnx solution file linking all C# services
- [x] All .NET API service projects created with linked xUnit test projects
- [ ] EF Core DbContexts -  in progress for products-api
- [ ] Core domain models and repository layer per service
- [ ] RabbitMQ event contracts and message consumers
- [ ] Docker and Docker Compose orchestration
- [ ] React frontend
- [ ] Analytics service (Go + Redis)
- [ ] AWS deployment

