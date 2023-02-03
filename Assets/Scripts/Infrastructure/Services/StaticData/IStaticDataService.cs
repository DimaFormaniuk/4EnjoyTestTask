namespace Infrastructure.Services.StaticData
{
    public interface IStaticDataService : IService
    {
        void Load();
        PrefabConfig ForPrefab(PrefabId prefabId);
    }
}