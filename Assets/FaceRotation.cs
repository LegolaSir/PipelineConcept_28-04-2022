using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaceRotation : MonoBehaviour
{
    [Header("Polygon Object to be Created")]
    [SerializeField] private GameObject polygon;

    [Header("Slider Input")]
    [SerializeField] private Slider slider;

    
    public void RotatePolygon()
    {
        polygon.transform.rotation = Quaternion.Euler(0f, slider.value, 0f);
    }
}
