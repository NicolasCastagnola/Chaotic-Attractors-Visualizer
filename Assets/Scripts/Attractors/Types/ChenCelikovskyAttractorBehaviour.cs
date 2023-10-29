using UnityEngine;
internal class ChenCelikovskyAttractorBehaviour : BaseAttractorBehaviour
{
    private const float a = 36f;
    private const float b = 3f;
    private const float c = 20f;
    
    public override void Initialize(ChaosAttractorGenerator owner)
    {
        base.Initialize(owner);
        
        _owner.SetPivot(new Vector3(0,0,20f));
        _position = new Vector3(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
    }
    public override Vector3 UpdatedPositionBasedOnFormula()
    {
        float x_dot = a * (_position.y - _position.x);
        float y_dot = - _position.x * _position.z + c * _position.y;
        float z_dot = _position.x * _position.y - b * _position.z;
                                                                            
        _position.x += x_dot * 0.002f;
        _position.y += y_dot * 0.002f;
        _position.z += z_dot * 0.002f;
        
        return _position;
    }
}