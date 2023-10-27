using UnityEngine;
internal class ThomasAttractorBehaviour : BaseAttractorBehaviour
{
    private const float b = 0.19f;
    public override void Initialize(ChaosAttractorGenerator owner)
    {
        base.Initialize(owner);
        
        _position = new Vector3(0.1f, 0f, 0f);
    }
    public override Vector3 UpdatedPositionBasedOnFormula()
    {
        float x_dot = - b * _position.x + Mathf.Sin(_position.y);
        float y_dot = - b * _position.y + Mathf.Sin(_position.z);
        float z_dot = - b * _position.z + Mathf.Sin(_position.x);
                                                                            
        _position.x += x_dot * 0.05f;
        _position.y += y_dot * 0.05f;
        _position.z += z_dot * 0.05f;
        
        return _position;
    }
}