namespace ContosoContainerAPI
{
    public static class ContainerManager
    {
        public static List<ColdStorageContainer> OrderIntoLayers(List<ColdStorageContainer> containers)
        {
            var result = new List<ColdStorageContainer>();

            var remaining = containers;
            while (remaining.Any())
            {
                result.AddRange(remaining.Where(r => !remaining.Any(p =>
                {
                    var parentId = GetParentIdOfContainer(containers, r);
                    return (parentId != null) && parentId.Equals(p);
                })));
                remaining = remaining.Except(result).ToList();
            }

            return result;
        }

        private static Guid? GetParentIdOfContainer(List<ColdStorageContainer> containers, ColdStorageContainer CompareContainer)
        {
            var parentId = containers.Find((container) => container.Equals(CompareContainer))?.ParentId;

            return parentId;
        }
    }
}
