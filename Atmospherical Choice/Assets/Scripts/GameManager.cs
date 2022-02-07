using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The Game Manager, controlling the flow of the game
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Skybox rotation speed
    /// </summary>
    [Tooltip("Skybox rotation speed")]
    [SerializeField] private float _skyboxRotationSpeed = 1;

    /// <summary>
    /// Reference to the skybox camera
    /// </summary>
    [Tooltip("Reference to the skybox camera")]
    [SerializeField] private Camera _skyboxCamera;

    /// <summary>
    /// Kingdoms "Actual Points"
    /// </summary>
    [Tooltip("Kingdoms \"Actual Points\"")]
    public List<Transform> KingdomsTransforms;

    /// <summary>
    /// Is the user exiting the application
    /// </summary>
    private bool _isExiting = false;

    /// <summary>
    /// Is the app playing (after intro)
    /// </summary>
    public static bool s_IsPlaying = false;

    /// <summary>
    /// Index used to track the cursor location on the list
    /// </summary>
    public static int s_Index = 3;

    /// <summary>
    /// Unity Start
    /// </summary>
    private void Start()
    {
        Cursor.visible = false;
    }

    /// <summary>
    /// Unity Update
    /// </summary>
    private void Update()
    {
        // Rotating Unity's skybox too frequently logs an annoying warning
        //RenderSettings.skybox.SetFloat("_Rotation", Time.time * _skyboxRotationSpeed);

        // I'm rotating an other camera only rendering the skybox instead
        _skyboxCamera.transform.localRotation = Quaternion.Euler(0, Time.time * _skyboxRotationSpeed, 0);

        if (Input.GetKeyDown("escape") && !_isExiting && s_IsPlaying)
        {
            _isExiting = true;
            GameObject.Find("CURTAIN").GetComponent<Animator>().SetBool("quit", true);
            StartCoroutine(QuitAfterSecondsCoroutine(3));
        }
    }

    /// <summary>
    /// Exits the application after X seconds
    /// </summary>
    /// <param name="t">The time in seconds</param>
    /// <returns></returns>
    private IEnumerator QuitAfterSecondsCoroutine(float t)
    {
        yield return new WaitForSecondsRealtime(t);

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
