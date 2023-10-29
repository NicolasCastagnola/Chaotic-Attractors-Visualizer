using UnityEngine;
public class AizawaAttractorBehaviour : BaseAttractorBehaviour
{
    private const float a = 0.95f;
    private const float b = 0.7f;
    private const float c = 0.6f;
    private const float d = 3.5f;
    private const float e = 0.25f;
    private const float f = 0.1f;
    
    public override void Initialize(ChaosAttractorGenerator owner)
    {
        base.Initialize(owner);
        
        _owner.SetPivot(new Vector3(0,0,0.5f));
        _position = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));
    }
    public override Vector3 UpdatedPositionBasedOnFormula()
    {
        float x_dot = (_position.z - b) * _position.x - d * _position.y;
        float y_dot = d * _position.x + (_position.z - b) * _position.y;
        float z_dot = c + a * _position.z - Mathf.Pow(_position.z, 3) / 3 - (Mathf.Pow(_position.x, 2) + Mathf.Pow(_position.y, 2)) * (1 + e * _position.z) + (f * _position.z * (Mathf.Pow(_position.x, 3)));
                                                                            
        _position.x += x_dot * 0.01f;
        _position.y += y_dot * 0.01f;
        _position.z += z_dot * 0.01f;
        
        
        return _position;
    }
}