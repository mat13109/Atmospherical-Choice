using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePicture : MonoBehaviour
{
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
            GetComponent<Animator>().SetBool("isselected", true);
        } else
        {
            GetComponent<Animator>().SetBool("isselected", false);
        }
        
    }
}
