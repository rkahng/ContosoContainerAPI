namespace ContosoContainerAPI
{
    public class ColdStorageContainer
    {
        public Guid Id { get; set; }

        public Guid? ParentId { get; set; }

        public ColdStorageContainer(Guid id, Guid? parentId)
        {
            Id = id;
            ParentId = parentId;
        }

        public static List<ColdStorageContainer> GenerateContainerList(int size, int depth, Guid? parentGuid)
        {
            List<ColdStorageContainer> containerList = new List<ColdStorageContainer>();
            foreach (int i in Enumerable.Range(0, size))
            {
                var id = Guid.NewGuid();
                containerList.Add(new ColdStorageContainer(Guid.NewGuid(), parentGuid));
                if (depth > 0)
                {
                    var children = ColdStorageContainer.GenerateContainerList(size / 2, depth - 1, id);
                    containerList.AddRange(children);
                }
            }

            return containerList;
        }
    }
}
