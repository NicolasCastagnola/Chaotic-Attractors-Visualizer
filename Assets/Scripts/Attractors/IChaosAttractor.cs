using UnityEngine;
public interface IChaosAttractor
{
    public void Initialize(ChaosAttractorGenerator owner);
    public Vector3 UpdatedPositionBasedOnFormula();
    public void Terminate();
}