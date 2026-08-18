# Member Claims Platform

A .NET Web API used to demonstrate an enterprise DevSecOps golden path to production.

## Application

The Member Claims API provides REST endpoints for managing member claims.

### Current Endpoints

- `GET /` - Application information
- `GET /health` - Application health check
- `GET /api/claims` - Retrieve all claims
- `GET /api/claims/{claimId}` - Retrieve a claim by ID
- `POST /api/claims` - Submit a new claim

## Technology Stack

- .NET 9
- ASP.NET Core Web API
- Git
- GitHub

## DevSecOps Roadmap

This project will progressively implement:

- GitHub Actions CI/CD
- Reusable pipeline workflows
- SonarQube quality gates
- SAST and SCA security scanning
- Secrets scanning
- SBOM generation
- Docker
- JFrog Artifactory
- Terraform
- Azure
- Kubernetes / AKS
- Helm
- Azure Monitor and Application Insights

## Golden Path

Developer → Pull Request → Build → Test → Quality → Security → Package → Deploy → Monitor