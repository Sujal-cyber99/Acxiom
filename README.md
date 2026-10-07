# AcxiomCRM

A simple Customer Relationship Management System built with ASP.NET Core MVC, Entity Framework Core, and SQLite.

## Vercel Deployment Instructions

Although Vercel is traditionally a serverless platform for frontend frameworks, you can deploy containerized applications using the provided Dockerfile.vercel if you are using a container platform (like Railway, Render, Fly.io, or Vercel's custom container runtimes).

### Prerequisites
- A GitHub repository with this code.
- A platform that supports Docker deployments (e.g., Railway, Render).

### Steps
1. Push this code to your GitHub repository.
2. Connect your repository to your hosting platform.
3. If the platform asks for the Dockerfile path, specify Dockerfile.vercel.
4. Ensure the platform sets a PORT environment variable. The application is configured to automatically bind to http://0.0.0.0:$PORT.
5. The SQLite database will automatically apply migrations on startup.

*Note for Serverless Vercel: Standard ASP.NET Core MVC apps cannot be deployed as serverless functions on Vercel without heavy architectural changes. If you strictly need to deploy to vercel.com, you would typically need a custom build step or a wrapper, but Vercel no longer natively supports Docker files for its core deployment mechanism. We recommend Railway or Render for containerized ASP.NET applications.*
