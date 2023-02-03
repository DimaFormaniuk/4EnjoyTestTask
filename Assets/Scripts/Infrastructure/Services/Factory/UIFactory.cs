using System.Collections.Generic;
using Infrastructure.Services.StaticData;
using UnityEngine;

namespace Infrastructure.Services.Factory
{
    public class FactoryService : IFactoryService
    {
        private List<IRegistered> _listRegistered = new List<IRegistered>();

        private readonly IStaticDataService _staticData;

        private Transform _uiRoot;

        private List<GameObject> _gameObjectsInRoot = new List<GameObject>();

        public FactoryService(IStaticDataService staticData)
        {
            _staticData = staticData;
        }

        public void Registered(IRegistered registered)
        {
            _listRegistered.Add(registered);
        }
        
        public GameObject CreateUIRoot()
        {
            GameObject root = CreatePrefab(PrefabId.UIRoot);
            root.GetComponent<Canvas>().worldCamera = Camera.main;
            _uiRoot = root.transform;

            return root;
        }

        public GameObject CreateMenu()
        {
            return CreatePrefabInRoot(PrefabId.Menu);
        }

        public GameObject CreateDailyBonus()
        {
            return CreatePrefabInRoot(PrefabId.DailyBonus);
        }

        public void ClearRoot()
        {
            foreach (GameObject gameObject in _gameObjectsInRoot)
                Object.Destroy(gameObject);

            _gameObjectsInRoot.Clear();
        }

        private GameObject CreatePrefabInRoot(PrefabId prefabId)
        {
            var prefab = CreatePrefab(prefabId);
            _gameObjectsInRoot.Add(prefab);

            return prefab;
        }

        private GameObject CreatePrefab(PrefabId prefabId)
        {
            var config = _staticData.ForPrefab(prefabId);
            var prefab = Object.Instantiate(config.Prefab, _uiRoot);

            RegisterWatchers(prefab);

            return prefab;
        }

        private void RegisterWatchers(GameObject gameObject)
        {
            _listRegistered.ForEach(x => x.Register(gameObject));
        }

        public void Cleanup()
        {
            _listRegistered.ForEach(x => x.Cleanup());
        }
    }
}