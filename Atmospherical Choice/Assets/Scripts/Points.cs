using UnityEngine;

/// <summary>
/// Controls the OnHover effect
/// </summary>
public class Points : MonoBehaviour
{
    /// <summary>
    /// The particle system that animates the hover effect
    /// </summary>
    [Tooltip("The particle system that animates the hover effect")]
    [SerializeField] private GameObject _onHoverParticleSystem;

    /// <summary>
    /// Local index to compare against GameManagers's index
    /// </summary>
    [Tooltip("Local index to compare against GameManagers's index")]
    [SerializeField] private int _index;

    /// <summary>
    /// Unity Update
    /// </summary>
    private void Update()
    {
        if (GameManager.s_Index == _index)
        {
            _onHoverParticleSystem.SetActive(true);
        } 
        else
        {
            _onHoverParticleSystem.SetActive(false);
        }
    }
}
