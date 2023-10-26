using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class GameManager : BaseMonoSingleton<GameManager>
{
    private List<ChaosAttractorGenerator> _activeGenerators = new List<ChaosAttractorGenerator>();

    [SerializeField] private TMP_Dropdown attractorDropdown;

    private ChaosAttractorType _selectedValue = ChaosAttractorType.None;
    
    private bool activeTrailLimit;
    private const int MaxGeneratorsAllowed = 10;
    
    [SerializeField] private ChaosAttractorGenerator generatorPrefab;

    protected override void Awake()
    {
        base.Awake();

        PopulateDropdownValues();
        
        attractorDropdown.onValueChanged.AddListener(OnDropdownValueChanged);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        
        attractorDropdown.onValueChanged.RemoveListener(OnDropdownValueChanged);
    }
    private void OnDropdownValueChanged(int index) => _selectedValue = (ChaosAttractorType)index;
    private void PopulateDropdownValues()
    {
        attractorDropdown.ClearOptions();

        string[] enumNames = System.Enum.GetNames(typeof(ChaosAttractorType));

        var dropdownOptions = enumNames.Select(enumName => new TMP_Dropdown.OptionData(enumName)).ToList();

        attractorDropdown.AddOptions(dropdownOptions);
    }
    public void ToggleTrailLimit()
    {
        activeTrailLimit = !activeTrailLimit;
        
        foreach (var activeGenerator in _activeGenerators)
        {
            if (activeTrailLimit)
            {
                activeGenerator.attachedTrailRender.autodestruct = true;
                activeGenerator.attachedTrailRender.time = 0.5f;
                
            }
            else
            {
                activeGenerator.attachedTrailRender.autodestruct = false;
                activeGenerator.attachedTrailRender.time = 40f;
            }
        }
        
        ClearAllTrails();
    }
    public void ClearAllTrails()
    {
        foreach (var activeGenerator in _activeGenerators)
        {
            activeGenerator.attachedTrailRender.Clear();
        }
    }
    public void SpawnGenerator()
    {
        if (MaxGeneratorsAllowed == _activeGenerators.Count) return;
        
        var newGenerator = Instantiate(generatorPrefab).GetComponent<ChaosAttractorGenerator>();
        
        newGenerator.Initialize(_selectedValue);
        
        _activeGenerators.Add(newGenerator);
    }
    public void RemoveAllGenerators()
    {
        foreach (var activeGenerator in _activeGenerators)
        {
            activeGenerator.Terminate();
        }
        
        _activeGenerators.Clear();
    }
}