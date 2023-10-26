using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    private bool OptionsCollapsed = true;
    private bool _cartesian = true;

    [SerializeField] private Slider deltaSpeed;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject cartesianObject;

    public void Awake() => deltaSpeed.onValueChanged.AddListener(x => GameManager.Instance.GlobalDeltaTime = x);
    public void ToggleCartesian()
    {
        _cartesian = !_cartesian;
        
        cartesianObject.SetActive(_cartesian);
    }
    public void ToggleCollapse()
    {
        OptionsCollapsed = !OptionsCollapsed;
        
        _animator.Play(OptionsCollapsed ? "Show" : "Hide");
    }
}
