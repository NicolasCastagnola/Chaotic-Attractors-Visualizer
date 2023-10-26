using System;
using UnityEngine;

public enum ChaosAttractorType
{
    None,
    Lorenz,
    Aizawa,
    Halvorsen,
    NewtonLeipnik,
    NoseHoover,
    ChenLee,
    _3CellsCNN,
    Bouali,
    Finance,
    Thomas
}

public class ChaosAttractorGenerator : MonoBehaviour
{
    private BaseAttractorBehaviour _currentSelectedAttractor;
    public TrailRenderer attachedTrailRender;
    public void Initialize(ChaosAttractorType type)
    {
        _currentSelectedAttractor = CreateBasedOnType(type);
        _currentSelectedAttractor.Initialize(this);

       attachedTrailRender = GetComponent<TrailRenderer>();
       attachedTrailRender.emitting = true;
       attachedTrailRender.Clear();
    }
    private void Update() => transform.position = _currentSelectedAttractor.UpdatedPositionBasedOnFormula();
    public void Terminate() => Destroy(gameObject, 0.5f);
    private BaseAttractorBehaviour CreateBasedOnType(ChaosAttractorType type)
    {
        return type switch
        {
            ChaosAttractorType.None => new LorenzAttractorBehaviour(),
            ChaosAttractorType.Lorenz => new LorenzAttractorBehaviour(),
            ChaosAttractorType.Aizawa => new AizawaAttractorBehaviour(),
            ChaosAttractorType.Halvorsen => new HalvorsenAttractorBehaviour(),
            ChaosAttractorType.NewtonLeipnik => new NewtonLeipnikAttractorBehaviour(),
            ChaosAttractorType.NoseHoover => new NoseHooverAttractorBehaviour(),
            ChaosAttractorType.ChenLee => new ChenLeeAttractorBehaviour(),
            ChaosAttractorType._3CellsCNN => new _3CellsCNNAttractorBehaviour(),
            ChaosAttractorType.Bouali => new BoualiAttractorBehaviour(),
            ChaosAttractorType.Finance => new FinanceAttractorBehaviour(),
            ChaosAttractorType.Thomas => new ThomasAttractorBehaviour(),
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }
}