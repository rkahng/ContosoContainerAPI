using ContosoContainerAPI;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<ColdStorageContainer> containers = ColdStorageContainer.GenerateContainerList(12, 3, null);

app.MapGet("/", () => {
    for (int i = 0; i < 5; i++)
    {
        var orderedContainers = ContainerManager.OrderIntoLayers(containers);
    }

    return "Cough";
});

app.Run();
