using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectableControll : MonoBehaviour
{
    public static int starCount;
    public GameObject starCountDisplay;
    public GameObject starEndDisplay;

    void Start()
    {
        CollectableControll.starCount = 0;
    }
    void Update()
    {
        starCountDisplay.GetComponent<TextMeshProUGUI>().text = "" + starCount;
        starEndDisplay.GetComponent<TextMeshProUGUI>().text = "" + starCount;
    }
}
