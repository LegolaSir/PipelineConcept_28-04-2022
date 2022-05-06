using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaceRotation : MonoBehaviour
{
    [Header("Polygon Object to be Created")]
    [SerializeField] private GameObject polygon;

    [Header("Slider Element Entry")]
    [SerializeField] private Slider slider;

    [Header("Toggle Elements Entry")]
    [SerializeField] private Toggle[] checkboxes = new Toggle[3];

    [SerializeField] private float[] sliderValues = new float[3];
    [SerializeField] private Vector3 rotatedPos;

    public void RotatePolygon()
    {     
        if(checkboxes[0].isOn)
        {
            sliderValues[0] = slider.value;
            //polygon.transform.rotation = Quaternion.Euler(slider.value, 0f, 0f);
        }
        
        if(checkboxes[1].isOn)
        {
            sliderValues[1] = slider.value;
            //polygon.transform.rotation = Quaternion.Euler(0f, slider.value, 0f);
        }
        
        if(checkboxes[2].isOn)
        {
            sliderValues[2] = slider.value;
            //polygon.transform.rotation = Quaternion.Euler(0f, 0f, slider.value);
        }

        rotatedPos = new Vector3(sliderValues[0], sliderValues[1], sliderValues[2]);

        polygon.transform.rotation = Quaternion.Euler(rotatedPos);
    }  
}
