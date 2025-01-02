using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Quan ly chung pool chua cac gamobject can tai su dung
public class ObjectPooling : MonoBehaviour
{
    protected static ObjectPooling instance;
    public static ObjectPooling Instance => instance;

    Dictionary<GameObject, List<GameObject>> listObj = new Dictionary<GameObject, List<GameObject>>();

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public GameObject GetObject(GameObject defaultPrefab)
    {
        if (listObj.ContainsKey(defaultPrefab))
        {
            foreach(GameObject obj in listObj[defaultPrefab])
            {
                if (obj.activeSelf)
                {
                    continue;
                }
                return obj;
            }
            GameObject g = Instantiate(defaultPrefab, this.transform.position, Quaternion.identity);
            listObj[defaultPrefab].Add(g);
            g.SetActive(false);
            return g;
        }

        List<GameObject> list = new List<GameObject>();
        GameObject g2 = Instantiate(defaultPrefab, this.transform.position, Quaternion.identity);
        list.Add(g2);
        listObj.Add(defaultPrefab, list);
        g2.SetActive(false);
        return g2;
    }
}
