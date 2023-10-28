using UnityEngine;
internal class BurkeShawAttractorBehaviour : BaseAttractorBehaviour
{
    private const float s = 10f;
    private const float v = 4.272f;
    
    public override void Initialize(ChaosAttractorGenerator owner)
    {
        base.Initialize(owner);
        
        _position = new Vector3(Random.Range(0f, 1f), 0f, 0f);
    }
    public override Vector3 UpdatedPositionBasedOnFormula()
    {
        float x_dot = - s * (_position.x + _position.y);
        float y_dot = _position.y - s * _position.x * _position.z;
        float z_dot = s * _position.x * _position.y + v;
                                                                            
        _position.x += x_dot * 0.005f;
        _position.y += y_dot * 0.005f;
        _position.z += z_dot * 0.005f;
        
        return _position;
    }
}