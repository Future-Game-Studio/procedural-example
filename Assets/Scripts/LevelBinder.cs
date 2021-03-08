using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Examples.Constants;
using Examples.Extensions;
using UnityEngine;

namespace Examples.Scripts
{
    public class LevelBinder : MonoBehaviour
    {
        public float scale = 1;
        private GameObject _target;
        private Dictionary<PrefabType, List<GameObject>> _prefabCache = new Dictionary<PrefabType, List<GameObject>>();
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }


        public LevelBinder Target(GameObject target)
        {
            if (_target)
                GameObject.Destroy(_target);
            _target = target;
            return this;
        }

        public void ApplyMap(PrefabType[,] map)
        {
            var (h, w) = map.Size();
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    TryGenerateAt(i, j, map, h, w);
                }
            }
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
            var posX = (i - h / 2) * scale;
            var posY = (j - w / 2) * scale;
            var pos = new Vector3(posX, prefab.transform.position.y, posY);
            var target = Instantiate(prefab, pos, Quaternion.identity, _target.transform);

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