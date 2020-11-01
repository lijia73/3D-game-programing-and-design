using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskFactory : MonoBehaviour
{
    public GameObject diskPrefab;

    private List<GameObject> used = new List<GameObject>();   //正在使用
    private List<GameObject> free = new List<GameObject>();     //使用过已被释放的，可以重复使用

    int nameIndex;

    private void Awake()
    {
        diskPrefab = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/disk"), Vector3.zero, Quaternion.identity);
        diskPrefab.name = "prefab";
        diskPrefab.AddComponent<DiskData>();
        diskPrefab.SetActive(false);
        nameIndex = 0;
    }

    public GameObject GetDisk(int round)
    {
        GameObject newDisk = null;
        if (free.Count > 0)
        {
            newDisk = free[0].gameObject;
            free.Remove(free[0]);
        }
        else
        {
            newDisk = GameObject.Instantiate<GameObject>(diskPrefab, Vector3.zero, Quaternion.identity);
            newDisk.name = nameIndex.ToString();
            nameIndex++;
        }
        used.Add(newDisk);
        return newDisk;
    }

    public void FreeDisk(GameObject usedDisk)
    {
        if (usedDisk != null)
        {
            usedDisk.SetActive(false);
            used.Remove(usedDisk);
            free.Add(usedDisk);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
