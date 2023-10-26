using UnityEngine;

public class LorenzAttractorBehaviour : BaseAttractorBehaviour
{
    private const float sigma = 10f;
    private const float rho = 28f;
    private const float beta = 8f;

    public override void Initialize(ChaosAttractorGenerator owner)
    {
        _owner = owner;
        _position = new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), Random.Range(-20f, 20f));
    }
    public override Vector3 UpdatedPositionBasedOnFormula()
    {
        float x_dot = sigma * (_position.y - _position.x);
        float y_dot = _position.x * (rho - _position.z) - _position.y;
        float z_dot = _position.x * _position.y - (beta/3) * _position.z;

        _position.x += x_dot * GameManager.Instance.GlobalDeltaTime;
        _position.y += y_dot * GameManager.Instance.GlobalDeltaTime;
        _position.z += z_dot * GameManager.Instance.GlobalDeltaTime;

        return _position;
    }
    public override void Terminate() => _owner.Terminate();
}