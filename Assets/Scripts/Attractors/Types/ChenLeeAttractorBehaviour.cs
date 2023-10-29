using UnityEngine;
internal class ChenLeeAttractorBehaviour : BaseAttractorBehaviour
{
    private const float a = 5f;
    private const float b = -10f;
    private const float c = -0.38f;
    
    public override void Initialize(ChaosAttractorGenerator owner)
    {
        base.Initialize(owner);
        
        _owner.SetPivot(new Vector3(0,0,13));
        _position = new Vector3(Random.Range(0f, 1f), 0, Random.Range(3, 4.5f));
    }
    public override Vector3 UpdatedPositionBasedOnFormula()
    {
        float x_dot = a * _position.x - _position.y * _position.z;
        float y_dot = b * _position.y + _position.x * _position.z;
        float z_dot = c * _position.z + _position.x * _position.y / 3;
        
        _position.x += x_dot * 0.004f;
        _position.y += y_dot * 0.004f;
        _position.z += z_dot * 0.004f;
        
        return _position;
    }
}