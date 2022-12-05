using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObstacle : MonoBehaviour
{
    public GameObject[] section;
    public int zPos;
    public bool creatingSection = false;
    public int secNum;

    //public GameObject sky;

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
        yield return new WaitForSeconds(2);
        secNum = Random.Range(0, 16);
        zPos = Random.Range(1, 125);
        var newInstance = Instantiate(section[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
        InstancedObjects.Add(newInstance);

        if (InstancedObjects.Count > 16)
        {
            Destroy(InstancedObjects[0]);
            InstancedObjects.RemoveAt(0);
        }

        //sky.transform.position = new Vector3(0, 0, zPos);

        //zPos += 20;
        //yield return new WaitForSeconds(45);
        creatingSection = false;
    }
}
