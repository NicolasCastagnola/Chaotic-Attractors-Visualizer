using UnityEngine;
internal class DequanLiAttractorBehaviour : BaseAttractorBehaviour
{
    private const float a = 40f;
    private const float c = 1.833f;
    private const float d = 0.16f;
    private const float e = 0.65f;
    private const float k = 55f;
    private const float f = 20f;
        
    public override void Initialize(ChaosAttractorGenerator owner)
    {
        base.Initialize(owner);
            
        _position = new Vector3(Random.Range(0.1f, 0.349f), 0, Random.Range(0, 0.16f));
    }
    public override Vector3 UpdatedPositionBasedOnFormula()
    {
        float x_dot = a * (_position.y - _position.x) + d * _position.x * - _position.z;
        float y_dot = k * _position.x + f * _position.y - _position.x * _position.z;
        float z_dot = c * _position.z + _position.x * _position.y - e * Mathf.Pow(_position.x, 2);
                                                                                
        _position.x += x_dot * 0.001f;
        _position.y += y_dot * 0.001f;
        _position.z += z_dot * 0.001f;
            
        return _position;
    }
}