using UnityEngine;
internal class FinanceAttractorBehaviour : BaseAttractorBehaviour
{
    private const float a = 0.001f;
    private const float b = 0.2f;
    private const float c = 1.1f;
    
    public override void Initialize(ChaosAttractorGenerator owner)
    {
        base.Initialize(owner);
        
        _owner.SetPivot(new Vector3(0f,-4.35f,0f));
        _position = new Vector3(Random.Range(-0.1f, 0.1f), 0f, 0f);
    }
    public override Vector3 UpdatedPositionBasedOnFormula()
    {
        float x_dot = (1 / b - a) * _position.x + _position.z + _position.x * _position.y;
        float y_dot = - b * _position.y - Mathf.Pow(_position.x, 2);
        float z_dot = - _position.x - c * _position.z;
                                                                            
        _position.x += x_dot * 0.03f;
        _position.y += y_dot * 0.03f;
        _position.z += z_dot * 0.03f;
        
        return _position;
    }
}