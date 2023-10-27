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
    ThreeCellsCNN,
    Bouali,
    Finance,
    Thomas,
    Arneodo,
    BurkeShaw,
    ChenCelikovsky,
    DequanLi 
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
            ChaosAttractorType.ThreeCellsCNN => new ThreeCellsCNNAttractorBehaviour(),
            ChaosAttractorType.Bouali => new BoualiAttractorBehaviour(),
            ChaosAttractorType.Finance => new FinanceAttractorBehaviour(),
            ChaosAttractorType.Thomas => new ThomasAttractorBehaviour(),
            ChaosAttractorType.Arneodo => new ArneodoAttractorBehaviour(),
            ChaosAttractorType.BurkeShaw => new BurkeShawAttractorBehaviour(),
            ChaosAttractorType.ChenCelikovsky => new ChenCelikovskyAttractorBehaviour(),
            ChaosAttractorType.DequanLi => new DequanLiAttractorBehaviour(),
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }
    public void SetPivot(Vector3 vector3)
    {
        if (GameManager.Instance.Pivot.position == vector3) return;
        
        GameManager.Instance.Pivot.position = vector3;
        GameManager.Instance.Camera.transform.position = vector3;
    }
    public void SetTrailMaterial(Material currentMaterial) => attachedTrailRender.material = currentMaterial;
}

// private const float a = 36f;
// private const float b = 3f;
// private const float c = 20f;
//     
// public override void Initialize(ChaosAttractorGenerator owner)
// {
//     base.Initialize(owner);
//         
//     _position = new Vector3(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
// }
// public override Vector3 UpdatedPositionBasedOnFormula()
// {
//     float x_dot = ;
//     float y_dot = ;
//     float z_dot = ;
//                                                                             
//     _position.x += x_dot * 0.002f;
//     _position.y += y_dot * 0.002f;
//     _position.z += z_dot * 0.002f;
//         
//     return _position;
// }