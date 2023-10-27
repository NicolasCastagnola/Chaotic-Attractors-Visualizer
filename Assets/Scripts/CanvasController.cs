using UnityEngine;

public class CanvasController : MonoBehaviour
{
    private bool OptionsCollapsed = true;
    
    [SerializeField] private Animator _animator;
    public void ToggleCollapse()
    {
        OptionsCollapsed = !OptionsCollapsed;
        
        _animator.Play(OptionsCollapsed ? "Show" : "Hide");
    }
}