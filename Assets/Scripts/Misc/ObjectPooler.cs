using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FUGAS.Examples.Player
{
    [System.Serializable]
    public class ObjectPoolItem
    {
        public GameObject objectToPool;
        public int amountToPool;
        public bool shouldExpand;
    }

    public class ObjectPooler : MonoBehaviour
    {
        public List<ObjectPoolItem> itemsToPool;
        public List<GameObject> pooledObjects;

        // Use this for initialization
        void OnEnable()
        {
            pooledObjects = new List<GameObject>();
            foreach (ObjectPoolItem item in itemsToPool)
            {
                for (int i = 0; i < item.amountToPool; i++)
                {
                    var scale = item.objectToPool.transform.localScale;
                    GameObject obj = (GameObject)Instantiate(item.objectToPool);
                    obj.transform.parent = this.transform;
                    obj.SetActive(false);
                    pooledObjects.Add(obj);
                }
            }
        }

        public (int free, int max) GetAvailableCount(string tag)
        {
            return (pooledObjects.Count(x => !x.activeInHierarchy && x.CompareTag(tag)),
             pooledObjects.Count(x => x.CompareTag(tag)));
        }

        public GameObject GetPooledObject(string tag)
        {
            for (int i = 0; i < pooledObjects.Count; i++)
            {
                if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].CompareTag(tag))
                {
                    return pooledObjects[i];
                }
            }
            foreach (ObjectPoolItem item in itemsToPool)
            {
                if (item.objectToPool.CompareTag(tag))
                {
                    if (item.shouldExpand)
                    {
                        GameObject obj = (GameObject)Instantiate(item.objectToPool);
                        obj.SetActive(false);
                        pooledObjects.Add(obj);
                        return obj;
                    }
                }
            }
            return null;
        }
    }
}