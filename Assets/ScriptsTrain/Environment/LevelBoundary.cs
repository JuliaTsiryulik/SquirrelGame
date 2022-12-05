using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundary : MonoBehaviour
{
    public static float leftSide = -2.15f;
    public static float rightSide = 2.15f;
    //public static float upSide = 0.4f;
    public float internalLeft;
    public float internalRight;
    //public float internalup;

    void Update()
    {
        internalLeft = leftSide;
        internalRight = rightSide;
        //internalup = upSide;
    }
}
