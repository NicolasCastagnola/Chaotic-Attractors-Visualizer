using UnityEngine;
internal class NoseHooverAttractorBehaviour : BaseAttractorBehaviour
{
    private const float a = 1.5f;
     	
    public override void Initialize(ChaosAttractorGenerator owner)
    {
        base.Initialize(owner);
        
        _position = new Vector3(1, 0, 0);
    }
    public override Vector3 UpdatedPositionBasedOnFormula()
    {
        float x_dot = _position.y;
        float y_dot = - _position.x + _position.y * _position.z;
        float z_dot = a - Mathf.Pow(_position.y, 2);
    
        _position.x += x_dot * 0.009f;
        _position.y += y_dot * 0.009f;
        _position.z += z_dot * 0.009f;
    
        return _position;
    }
}