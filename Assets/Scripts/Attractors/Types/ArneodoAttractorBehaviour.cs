using UnityEngine;
internal class ArneodoAttractorBehaviour : BaseAttractorBehaviour
{
    private const float a = -5.5f;
    private const float b = 3.5f;
    private const float c = -1.0f;
    
    public override void Initialize(ChaosAttractorGenerator owner)
    {
        base.Initialize(owner);
        
        _position = new Vector3(Random.Range(-0.1f, 0.1f), 0f, 0f);
    }
    public override Vector3 UpdatedPositionBasedOnFormula()
    {
        float x_dot = _position.y;
        float y_dot = _position.z;
        float z_dot = -a * _position.x - b * _position.y - _position.z + c * Mathf.Pow(_position.x, 3);
                                                                            
        _position.x += x_dot * 0.009f;
        _position.y += y_dot * 0.009f;
        _position.z += z_dot * 0.009f;
        
        return _position;
    }
}