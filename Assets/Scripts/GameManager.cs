using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class GameManager : BaseMonoSingleton<GameManager>
{
    private readonly List<ChaosAttractorGenerator> _activeGenerators = new List<ChaosAttractorGenerator>();
    
    private Material currentMaterial;
    private bool activeTrailLimit;
    private ChaosAttractorType _selectedValue = ChaosAttractorType.None;

    [SerializeField, Header("MAX ATTRACTOR ALLOWED IN SCENE"), Range(20, 500)] private int MaxGeneratorsAllowed;
    [SerializeField,Space(30)] private TMP_Dropdown attractorDropdown;
    [SerializeField] private Material[] possiblesMaterials;
    [SerializeField] private ChaosAttractorGenerator generatorPrefab;

    public Transform Pivot;
    public Transform Camera;
    protected override void Awake()
    {
        base.Awake();

        PopulateDropdownValues();
        
        attractorDropdown.onValueChanged.AddListener(OnDropdownValueChanged);
        
        currentMaterial = possiblesMaterials[Random.Range(0, possiblesMaterials.Length)];
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
    public void RandomizeMaterial()
    {
        currentMaterial = possiblesMaterials[Random.Range(0, possiblesMaterials.Length)];

        foreach (var generator in _activeGenerators)
        {
            generator.SetTrailMaterial(currentMaterial);
        }
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
        newGenerator.SetTrailMaterial(currentMaterial);
        
        _activeGenerators.Add(newGenerator);
    }
    public void RemoveAllGenerators()
    {
        foreach (var activeGenerator in _activeGenerators)
        {
            if (activeGenerator == null)
            {
                _activeGenerators.RemoveAt(_activeGenerators.IndexOf(activeGenerator));
            }
            
            activeGenerator.Terminate();
        }
        
        _activeGenerators.Clear();
    }
}