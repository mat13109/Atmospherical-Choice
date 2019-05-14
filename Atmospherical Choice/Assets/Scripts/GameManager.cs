using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Transform> kingdoms;
    [SerializeField] float galaxyRotatingSpeed;

    bool hasquitted = false;

    public static bool hasstarted = false;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * galaxyRotatingSpeed);

        if (Input.GetKeyDown("escape") && !hasquitted && hasstarted)
        {
            hasquitted = true;
            GameObject.Find("CURTAIN").GetComponent<Animator>().SetBool("quit", true);
            StartCoroutine("QuitAfterSeconds", 3);
        }
        
    }

    IEnumerator QuitAfterSeconds(float a)
    {
        yield return new WaitForSecondsRealtime(a);
        Application.Quit();
    }



    
}
//Dave Gandy keyboard
//Roundicons arrow