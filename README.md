# Microservices Project

This project demonstrates a microservices architecture built with modern C# (.NET 8/7/6), featuring gRPC for high-performance inter-service communication. It includes three distinct services: OrderService, ProductService, and UserService, each containerized with Docker and ready for orchestration.

## Overview

This project showcases a clean implementation of microservices principles, emphasizing:

*   **Decoupled Services:** Each service (Order, Product, User) is self-contained, managing its own data and logic.
*   **gRPC for Communication:** High-performance, contract-first RPC framework for communication between services.
*   **Modern .NET:** Utilizes the latest .NET features, including minimal APIs for concise service setup.
*   **Containerization:** Dockerfiles are provided for each service, enabling easy deployment and scaling.
*   **Orchestration-Ready:** Includes a `docker-compose.yml` for local development and example Kubernetes manifests for cluster deployment.

### Services

1.  **OrderService**: Manages customer orders, potentially interacting with ProductService and UserService.
2.  **ProductService**: Handles product catalog information, pricing, and inventory.
3.  **UserService**: Manages user accounts, profiles, and authentication-related data.

### Technology Stack

*   **.NET (8/7/6 or your specific version)**: Core framework for building the services.
*   **gRPC**: For defining service contracts and enabling communication.
*   **Docker**: For containerizing the applications.
*   **Docker Compose**: For orchestrating multi-container applications locally.
*   **Kubernetes (Optional)**: Example manifests provided for deployment to a Kubernetes cluster.

## Project Structure

The solution is organized as follows:
MicroservicesProject/
├── src/
│ ├── OrderService/
│ │ ├── Protos/ # .proto definitions for OrderService
│ │ ├── Services/ # gRPC service implementations
│ │ ├── Program.cs # Service setup and gRPC endpoint mapping
│ │ └── OrderService.csproj
│ ├── ProductService/
│ │ ├── Protos/
│ │ ├── Services/
│ │ ├── Program.cs
│ │ └── ProductService.csproj
│ ├── UserService/
│ │ ├── Protos/
│ │ ├── Services/
│ │ ├── Program.cs
│ │ └── UserService.csproj
├── k8s/ # Example Kubernetes deployment files (optional)
├── docker-compose.yml
└── MicroservicesProject.sln
└── README.md

## Proto Definitions (.proto files)

The gRPC service contracts (messages and service methods) are defined in `.proto` files located within the `Protos` directory of each service project (e.g., `src/OrderService/Protos/order.proto`). These files are the source of truth for the API of each microservice.

## Requirements

*   **.NET SDK (8.0, 7.0, or 6.0 recommended)**: Download from [here](https://dotnet.microsoft.com/download).
*   **Docker Desktop**: For building and running Docker containers. Download from [here](https://www.docker.com/products/docker-desktop).
*   **(Optional) Kubernetes CLI (`kubectl`)**: If deploying to Kubernetes.
*   **(Optional) `grpcurl`**: A command-line tool for interacting with gRPC services. Installation guide [here](https://github.com/fullstorydev/grpcurl#installation).

## Getting Started

### 1. Clone the Repository

```sh
git clone https://github.com/aaabbbuuu/MicroservicesProject.git
cd MicroservicesProject
```
### 2. Build the Services

#### Option A: Using Docker Compose (Recommended for multi-service setup)

```sh
docker-compose build
```

#### Option B: Using .NET CLI (For Individual services or without Docker)

```sh
docker build
```

### Running the Services

#### Option A: Using Docker Compose
This will start all three services.

```sh
docker-compose up
```

The services will be accessible via their gRPC endpoints on the following default ports (check docker-compose.yml or individual launchSettings.json if ports differ):
- OrderService: `http://localhost:5001`
- ProductService: `http://localhost:5002`
- UserService: `http://localhost:5003`
(Note: These are gRPC ports, not HTTP ports for web browsers. You'll need a gRPC client to interact with them.)

#### Option B: Using .NET CLI (Run each service in a separate terminal)

Navigate to each service directory (e.g., src/OrderService/) and run:
```sh
dotnet run
```
Repeat for ProductService and UserService.

### Verifying the Setup

Once the services are running, you can use grpcurl to send requests. Ensure you use the correct package, service, and method names as defined in your .proto files.
Example for OrderService (assuming package order and service Order):

```sh
# List available services on a port
grpcurl -plaintext localhost:5001 list

# List methods for a specific service (e.g., order.Order)
grpcurl -plaintext localhost:5001 list order.Order

# Describe a specific method
grpcurl -plaintext localhost:5001 describe order.Order.GetOrder

# Call the GetOrder method
grpcurl -plaintext -d '{"id": "some-order-id"}' localhost:5001 order.Order/GetOrder
```
Replace order.Order/GetOrder and {"id": "some-order-id"} with the actual service, method, and request payload from your .proto definitions. Repeat for ProductService (e.g., product.Product/GetProduct on port 5002) and UserService (e.g., user.User/GetUser on port 5003).

### Kubernetes Deployment

Sample Kubernetes deployment and service manifest files are provided in the k8s/ directory. These are examples and may require adjustments for your specific cluster and needs (e.g., image names if you push to a custom registry).
To deploy to a Kubernetes cluster:
Ensure your Docker images are pushed to a registry accessible by your Kubernetes cluster (e.g., Docker Hub, ACR, GCR). You might need to tag them appropriately (e.g., yourregistry/orderservice:latest) and update the image names in the YAML files.
Apply the manifests:

```sh
kubectl apply -f k8s/order-service-deployment.yaml
kubectl apply -f k8s/order-service-service.yaml
# Repeat for product and user services
```

## Contributing

Contributions Welcome! If you have suggestions for improvements, feel free to open an issue or submit a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
