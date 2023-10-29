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
    // DequanLi 
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
            // ChaosAttractorType.DequanLi => new DequanLiAttractorBehaviour(), TODO: fix infinite 
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


/* COPY PASTE THIS CODE AFTER CREATE THE NEW ATTRACTOR CLASS AND MAKE IT INHERIT FROM BaseAttractorBehaviour.cs

//1) Replace variables a,b,c..
//2) Replace x_dot, y_dot and z_dot to the attractor formula
//3) Replace the delta to the attractor delta constant.

private const float a = 0f;
private const float b = 0f;
private const float c = 0f;
private const float delta = 0;
    
public override void Initialize(ChaosAttractorGenerator owner)
{
    base.Initialize(owner);
        
     //Replace to random values or constant starting point
    _position = new Vector3(0,0,0);
}
public override Vector3 UpdatedPositionBasedOnFormula()
{
    float x_dot = 0;
    float y_dot = 0;
    float z_dot = 0;
                                                                            
    _position.x += x_dot * delta;
    _position.y += y_dot * delta;
    _position.z += z_dot * delta;
        
    return _position;
}
*/