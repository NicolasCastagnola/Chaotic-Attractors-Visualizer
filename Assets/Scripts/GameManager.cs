using System.Collections.Generic;
using UnityEngine;

public class GameManager : BaseMonoSingleton<GameManager>
{
    private List<ChaosAttractorGenerator> _activeGenerators = new List<ChaosAttractorGenerator>();
    
    private bool activeTrailLimit;
    private const int MaxGeneratorsAllowed = 10;
    
    [SerializeField] private ChaosAttractorGenerator generatorPrefab;

    [Range(0.001f, 0.03f)] public float GlobalDeltaTime = 0.01f;

    protected override void Awake()
    {
        base.Awake();
        
        SpawnGenerator();
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
        
        //TODO
        newGenerator.Initialize(ChaosAttractorType.Lorenz);
        
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