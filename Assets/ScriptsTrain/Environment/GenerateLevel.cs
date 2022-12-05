using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject[] section;
    public int zPos = 125;
    public bool creatingSection = false;
    public int secNum;

    public GameObject sky;

    public List<GameObject> InstancedObjects = new List<GameObject>();

    void Update()
    {
        if (creatingSection == false)
        {
            creatingSection = true;
            StartCoroutine(GenerateSection());
        }
    }

    IEnumerator GenerateSection()
    {
        secNum = Random.Range(0, 1);
        var newInstance = Instantiate(section[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
        InstancedObjects.Add(newInstance);

        if (InstancedObjects.Count > 2)
        {
            Destroy(InstancedObjects[0]);
            InstancedObjects.RemoveAt(0);
        }

        sky.transform.position = new Vector3(0, 0, zPos);

        zPos += 125;
        yield return new WaitForSeconds(25);
        creatingSection = false;
    }
}
