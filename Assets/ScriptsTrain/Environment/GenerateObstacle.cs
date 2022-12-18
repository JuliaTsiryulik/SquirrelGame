using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObstacle : MonoBehaviour
{
    public GameObject[] section;
    public int zPosStart = 10;

    public int zPosDifference = 20;
    public int zPosEnd;

    public bool creatingSection = false;
    public int secNum;
    public float timeWaiting;

    public Camera mainCam;

    public List<GameObject> InstancedObjects = new List<GameObject>();

    void Start()
    {
        zPosEnd = zPosDifference;
        timeWaiting = zPosDifference;
        StartCoroutine(GenerateSection());
    }


    IEnumerator GenerateSection()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            secNum = Random.Range(0, 16);

            var posZ = mainCam.transform.position.z;

            var last = InstancedObjects.Count == 0
                ? null
                : InstancedObjects[InstancedObjects.Count - 1];

            if (last == null || last.transform.position.z + 10 < posZ)
            {
                var newInstance = Instantiate(section[secNum], new Vector3(0, 0, posZ + 10), Quaternion.identity);
                InstancedObjects.Add(newInstance);

                if (InstancedObjects.Count > 16)
                {
                    Destroy(InstancedObjects[0]);
                    InstancedObjects.RemoveAt(0);
                }
            }
        }

    }

}
