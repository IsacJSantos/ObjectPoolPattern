using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class PoolItem
{
    public GameObject prefab;
    public int amount;
    public bool Expandable;
}
public class Pool : MonoBehaviour
{
    public static Pool singleton;
    public List<PoolItem> items;
    public List<GameObject> pooledItems;

    private void Awake()
    {
        singleton = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        pooledItems = new List<GameObject>();
        foreach (PoolItem item in items)
        {
            AddToPool(item.prefab, item.amount);
        }
    }

    public GameObject Get(string tag)
    {
        for (int i = 0; i < pooledItems.Count; i++)
        {
            if (!pooledItems[i].activeInHierarchy && pooledItems[i].tag == tag)
                return pooledItems[i];

        }

        PoolItem item = items.FirstOrDefault(i =>
        {
            if (i.prefab.tag == tag && i.Expandable) 
            {
                AddToPool(i.prefab, 1);
                return i.prefab;
            }
            return false;
        });

        return null;
    }

    void AddToPool(GameObject prefab, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pooledItems.Add(obj);
        }
    }
}
