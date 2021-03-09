using System;
using System.Collections.Generic;
using System.Linq;
using FUGAS.Examples.Constants;
using FUGAS.Examples.Misc.Extensions;
using UnityEngine;

namespace FUGAS.Examples.Generator.Unity
{
    public class LevelBinder : MonoBehaviour
    {
        public float scale = 1;
        private GameObject _target;
        private Dictionary<PrefabType, List<GameObject>> _prefabCache = new Dictionary<PrefabType, List<GameObject>>();

        public LevelBinder Target(GameObject target, bool destroyPrevious = false)
        {
            if (destroyPrevious && _target)
                GameObject.Destroy(_target);
            _target = target;
            return this;
        }

        public void ApplyMap(PrefabType[,] map)
        {
            var (h, w) = map.Size();
            for (int i = 0; i < h; i++)
                for (int j = 0; j < w; j++)
                    TryGenerateAt(i, j, map, h, w);
        }

        private void TryGenerateAt(int i, int j, PrefabType[,] map, int h, int w)
        {
            // 1: map prefab type to resource
            var prefabType = map[i, j];
            GameObject prefab = default;

            switch (prefabType)
            {
                case PrefabType.Default:
                    break;
                case PrefabType.Wall:
                    // how to override default prefab source for this mapping
                    prefab = GetResources(PrefabType.Wall).FirstOrDefault();
                    break;
                default:
                    prefab = GetResources(prefabType).FirstOrDefault();
                    break;
            }

            if (!prefab)
                return; // there is no applicable prefab 

            // 2: instantiate prefab 
            var (posX, posY) = Project(i, j, h, w);
            var pos = new Vector3(posX, prefab.transform.position.y, posY);
            var target = Instantiate(prefab, pos, Quaternion.identity, _target.transform);

        }

        private (float posX, float posY) Project(int i, int j, int h, int w)
        {
            return ((i - h / 2f) * scale, (j - w / 2f) * scale);
        }

        private List<GameObject> GetResources(PrefabType prefabType)
        {
            if (_prefabCache.ContainsKey(prefabType))
                return _prefabCache[prefabType];
            return _prefabCache[prefabType] =
                Resources.LoadAll<GameObject>($"Prefabs/{prefabType}").ToList();
        }
    }
}