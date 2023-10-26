using UnityEngine;
public abstract class BaseAttractorBehaviour : IChaosAttractor
{
    protected ChaosAttractorGenerator _owner;
    protected Vector3 _position;
    
    public abstract void Initialize(ChaosAttractorGenerator owner);
    public abstract Vector3 UpdatedPositionBasedOnFormula();
    public abstract void Terminate();
}