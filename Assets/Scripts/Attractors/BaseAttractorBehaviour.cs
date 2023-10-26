using UnityEngine;
public abstract class BaseAttractorBehaviour : IChaosAttractor
{
    protected ChaosAttractorGenerator _owner;
    protected Vector3 _position;

    public virtual void Initialize(ChaosAttractorGenerator owner) => _owner = owner;
    public abstract Vector3 UpdatedPositionBasedOnFormula();
    public virtual void Terminate() => _owner.Terminate();
}