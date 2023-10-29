using UnityEngine;
internal class BoualiAttractorBehaviour : BaseAttractorBehaviour
{
    private const float a = 0.3f;
    private const float s = 1.0f;
    
    public override void Initialize(ChaosAttractorGenerator owner)
    {
        base.Initialize(owner);
        
            
        _owner.SetPivot(new Vector3(0.85f,4.76f,1.09f));
        _position = new Vector3(Random.Range(0f, 1f), Random.Range(0f, 0.1f), Random.Range(0f, 0.1f));
    }
    public override Vector3 UpdatedPositionBasedOnFormula()
    {
        float x_dot = _position.x * (4 - _position.y) + a * _position.z;
        float y_dot = - _position.y * (1 - Mathf.Pow(_position.x, 2));
        float z_dot = - _position.x * (1.5f - s * _position.z) - 0.05f * _position.z;
                                                                            
        _position.x += x_dot * 0.006f;
        _position.y += y_dot * 0.006f;
        _position.z += z_dot * 0.006f;
        
        return _position;
    }
}