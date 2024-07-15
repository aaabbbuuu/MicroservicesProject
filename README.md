
# Microservices Project

This project demonstrates a microservices architecture using C# (.NET Core), Docker, Kubernetes, and gRPC for communication. It includes three services: OrderService, ProductService, and UserService.

## Overview

In this project, we have implemented a microservices architecture to demonstrate the principles of scalability, maintainability, and efficient communication between services using gRPC. Each service is self-contained and can be deployed independently, allowing for better isolation and fault tolerance.

### Services

1. **OrderService**: Manages order-related operations.
2. **ProductService**: Handles product-related data and operations.
3. **UserService**: Manages user-related information and operations.

### Communication

- **gRPC**: We use gRPC for communication between the services. gRPC provides high performance, language-agnostic RPC calls which are ideal for microservices.

## Requirements

To build and run this project, you will need the following:

- **.NET 5 SDK**: To develop and build the .NET Core applications.
- **Docker**: To containerize the applications.
- **Docker Compose**: To orchestrate the multi-container Docker applications.
- **Kubernetes**: (Optional) To deploy the services in a Kubernetes cluster.

## Getting Started

### Clone the Repository

```sh
git clone https://github.com/yourusername/MicroservicesProject.git
cd MicroservicesProject
```

### Building the Services

Each service has its own Dockerfile for containerization. To build the Docker images for the services, navigate to the root of your project and use Docker Compose:

```sh
docker-compose build
```

### Running the Services

After building the images, you can start the services using Docker Compose:

```sh
docker-compose up
```

This will start all three services and they will be accessible at the following ports:
- OrderService: `http://localhost:5001`
- ProductService: `http://localhost:5002`
- UserService: `http://localhost:5003`

### Verifying the Setup

To verify that the services are running correctly, you can use tools like `curl` or Postman to send requests to the services' gRPC endpoints. For example, using `grpcurl`:

```sh
grpcurl -plaintext -d '{"id": 1}' localhost:5001 Order.GetOrder
```

### Kubernetes Deployment

If you wish to deploy these services to a Kubernetes cluster, use the deployment files provided in the `k8s/` directory. 

Apply the deployment files using `kubectl`:

```sh
kubectl apply -f k8s/order-service-deployment.yaml
kubectl apply -f k8s/product-service-deployment.yaml
kubectl apply -f k8s/user-service-deployment.yaml
```

## Contributing

We welcome contributions! If you have suggestions for improvements, feel free to open an issue or submit a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
