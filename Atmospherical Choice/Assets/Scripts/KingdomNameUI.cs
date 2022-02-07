using UnityEngine;

/// <summary>
/// Controls the animations on the Kingdom Names UI
/// </summary>
public class KingdomNameUI : MonoBehaviour
{
    /// <summary>
    /// Local index to compare against GameManagers's index
    /// </summary>
    [Tooltip("Local index to compare against GameManagers's index")]
    [SerializeField] private int _index;

    /// <summary>
    /// Animator reference
    /// </summary>
    private Animator _animator;

    /// <summary>
    /// Unity Start
    /// </summary>
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Unity Update
    /// </summary>
    private void Update()
    {
        if (GameManager.s_Index == _index)
        {
            _animator.SetBool("isSelected", true);
        } 
        else
        {
            _animator.SetBool("isSelected", false);
        }
    }
}
