# CovidTracker

## This is a sample project to test out a few different technologies, display Clean Architecture and Mediator pattern

- **Feature 1**: Aspire
- **Feature 2**: FastEndpoints
- **Feature 3**: Deploy to Azure using GitHub actions.

Deploying a .NET Apire project using Azure Developer CLI and GitHub Actions
https://learn.microsoft.com/en-us/dotnet/aspire/deployment/azure/aca-deployment-github-actions?tabs=windows&pivots=github-actions

In addition to the above tutorial a few additional steps I learned required
You must specify in the pipeline to use .NET 9

```yaml
name: Setup .NET Core SDK
uses: actions/setup-dotnet@v4.2.0
with:
  dotnet-version: "9.0.x"
```
