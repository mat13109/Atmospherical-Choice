using UnityEngine;
using DG.Tweening;

/// <summary>
/// Controls the camera systems
/// </summary>
public class CameraControl : MonoBehaviour
{
    /// <summary>
    /// GameManager reference
    /// </summary>
    private GameManager _gameManager;

    /// <summary>
    /// Unity Start
    /// </summary>
    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    /// <summary>
    /// Unity Update
    /// </summary>
    private void Update()
    {
        if (!GameManager.s_IsPlaying)
        {
            return;
        }

        if (Input.GetKeyDown("right"))
        {
            if (GameManager.s_Index == _gameManager.KingdomsTransforms.Count - 1)
            {
                // Loop ?
                //GameManager.s_Index = 0;
            } 
            else
            {
                ++GameManager.s_Index;
            }
        }
        if (Input.GetKeyDown("left"))
        {
            if (GameManager.s_Index == 0)
            {
                // Loop ?
                //GameManager.s_Index = _gameManager.KingdomsTransforms.Count - 1;
            }
            else
            {
                --GameManager.s_Index;
            }
        }

        transform.DOLocalRotate(_gameManager.KingdomsTransforms[GameManager.s_Index].eulerAngles, 1);
    }

    /// <summary>
    /// Called via the animator, at the end of the "go in" animation
    /// </summary>
    public void DeactivateTheAnimation ()
    {
        GetComponent<Animator>().enabled = false;
        GameManager.s_IsPlaying = true;
    }
}
