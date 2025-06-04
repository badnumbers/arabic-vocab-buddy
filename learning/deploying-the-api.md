# Install the Azure CLI
```
curl -sL https://aka.ms/InstallAzureCLIDeb | sudo bash
```
After installation, you can verify it with:

```
az --version
```

# Publish the API
From within the directory `ArabicVocabBuddy.Server`:

```
rm -rf publish
dotnet publish ArabicVocabBuddy.Server.csproj -c Release -o ./publish
```

# Zip the published files
```
cd publish
zip -r ../publish.zip .
cd ..
```

# Deploy the published files
```
az webapp deploy --resource-group rg-arabic-vocab-buddy --name app-arabic-vocab-buddy --src-path ./publish.zip
```
