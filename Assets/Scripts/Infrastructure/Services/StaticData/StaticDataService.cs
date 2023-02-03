using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Infrastructure.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string BaseResourcesPath = "StaticData/";
        private Dictionary<PrefabId, PrefabConfig> _prefabConfigs;

        public void Load()
        {
            LoadPrefabs();
        }

        public PrefabConfig ForPrefab(PrefabId prefabId) =>
            _prefabConfigs.TryGetValue(prefabId, out PrefabConfig config)
                ? config
                : null;

        private void LoadPrefabs()
        {
            _prefabConfigs = Resources
                .Load<UIPrefabStaticData>(BaseResourcesPath + "UI/UIPrefabStaticData")
                .Configs
                .ToDictionary(x => x.Type, x => x);
        }
    }
}