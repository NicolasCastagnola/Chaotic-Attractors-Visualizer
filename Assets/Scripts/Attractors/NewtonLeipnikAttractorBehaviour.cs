using UnityEngine;
internal class NewtonLeipnikAttractorBehaviour : BaseAttractorBehaviour
{
    private const float a = 0.4f;
    private const float b = 0.175f;

    public override void Initialize(ChaosAttractorGenerator owner)
    {
        base.Initialize(owner);
        
        _position = new Vector3(Random.Range(-0.6f, -0.6f), 0, Random.Range(-0.4f, -0.4f));
    }

    public override Vector3 UpdatedPositionBasedOnFormula()
    {
        float x_dot =  - a * _position.x - _position.y + 10 * _position.y * _position.z;
        float y_dot = - _position.x - 0.4f * _position.y + 5 * _position.x * _position.z;
        float z_dot = b * _position.z - 5 * _position.x * _position.y;
    
        _position.x += x_dot * 0.02f;
        _position.y += y_dot * 0.02f;
        _position.z += z_dot * 0.02f;
    
        return _position;
    }
}