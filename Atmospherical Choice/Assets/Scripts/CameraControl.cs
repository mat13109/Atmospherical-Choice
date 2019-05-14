using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraControl : MonoBehaviour
{
    public static int index = 3;

    GameManager GM;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("right") && GameManager.hasstarted)
        {
            if (index == GM.kingdoms.Count - 1)
            {
                index = 0;
            } else
            {
                ++index;
            }
        }
        if (Input.GetKeyDown("left") && GameManager.hasstarted)
        {
            if (index == 0)
            {
                index = GM.kingdoms.Count - 1;
            }
            else
            {
                --index;
            }
        }

        //this.transform.rotation = GM.kingdoms[index].transform.rotation;

        this.transform.DOLocalRotate(GM.kingdoms[index].eulerAngles, 1);
    }

    public void DeactivateTheAnimation (){
        GetComponent<Animator>().enabled = false;
        GameManager.hasstarted = true;
    }
}
