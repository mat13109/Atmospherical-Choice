using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingdomNameUI : MonoBehaviour
{
    [SerializeField] int myNumber;
    [SerializeField] Animator myAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CameraControl.index == myNumber)
        {
            myAnim.SetBool("isselected", true);
        } else
        {
            myAnim.SetBool("isselected", false);
        }
    }
}
