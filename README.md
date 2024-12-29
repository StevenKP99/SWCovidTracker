# CovidTracker

`[Demo](https://webfrontend.jollycliff-60b2df19.centralus.azurecontainerapps.io/)`

## This is a sample project to test out a few different technologies, display Clean Architecture and Mediator pattern

The main focus was on trying new technologies I have yet to utilize, with adherence to clean architecture.

- **Feature 1**: Aspire
- **Feature 2**: FastEndpoints
- **Feature 3**: Telerik For Blazor
- **Feature 4**: Deploy to Azure using GitHub actions.

Deploying a .NET Apire project using Azure Developer CLI and GitHub Actions
https://learn.microsoft.com/en-us/dotnet/aspire/deployment/azure/aca-deployment-github-actions?tabs=windows&pivots=github-actions

In addition to the above tutorial a few additional steps I learned required
You must specify in the pipeline to use .NET 9 as the ubuntu latest container is still on .NET 7 or 8

```yaml
- name: Setup .NET Core SDK
  uses: actions/setup-dotnet@v4.2.0
  with:
    dotnet-version: "9.0.x"
```

If you wish to run this locallaly you will need to supply Telerik credentials. Locally this is done through a prompt when required.

```xml
<configuration>
  <packageSources>
    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" />
	<add key="MyTelerikFeed" value="https://nuget.telerik.com/v3/index.json" />
  </packageSources>
  <packageSourceCredentials>
    <MyTelerikFeed>
      <add key="Username" value="api-key" />
      <add key="ClearTextPassword" value="%MY_API_KEY%" />
    </MyTelerikFeed>
  </packageSourceCredentials>
</configuration>
```

When deploying the pipeline utilizes Action Secrets.

```yaml
- name: Set environment variables
run: |
    echo "MY_API_KEY=${{ secrets.MY_API_KEY }}" >> $GITHUB_ENV
```
