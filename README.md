# CachedRepository

A sample demonstrating the CachedRepository pattern

## Running the Sample

This application uses seed data created by EF Migrations. If you just open it in Visual Studio and run it, it _should_ prompt you to run migrations and then work. You'll need to have a database locally for it to communicate with. The default connection string is in `appsettings.json` and is looking for Server=(localdb)\\mssqllocaldb. Modify your appsettings.json file to reference your database server before running the sample.

If Visual Studio and/or the in-browser middleware don't work, use these command line options:

```
    dotnet ef database update
    dotnet run
```

If that fails, another option is to simply delete the Migrations folder and then start with this:

```
    dotnet ef migrations add Initial
    dotnet ef database update
    dotnet run
```

Once the app is working, your initial view of the home page should look something like this:

![Screenshot](https://user-images.githubusercontent.com/782127/44606227-582e8700-a7ba-11e8-8a2a-ed17a6919fa2.png)

Refresh the page and you should see the data continue to load, but the Load time should be 0 ms or close to zero. The cache is configured to reset every 5 seconds so if you continue refreshing you should periodically see a non-zero load time.

## References

- [Introducing the CachedRepository](https://ardalis.com/introducing-the-cachedrepository-pattern)
- [Building a CachedRepository via the Strategy Pattern](https://ardalis.com/building-a-cachedrepository-via-strategy-pattern)
- [StackOverflow Example](https://stackoverflow.com/a/40598382/13729)
