using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    [SerializeField] GameObject animatedStuffWhenSelected;
    [SerializeField] int myNumber;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CameraControl.index == myNumber)
        {
            animatedStuffWhenSelected.SetActive(true);
        } else
        {
            animatedStuffWhenSelected.SetActive(false);
        }
    }
}
