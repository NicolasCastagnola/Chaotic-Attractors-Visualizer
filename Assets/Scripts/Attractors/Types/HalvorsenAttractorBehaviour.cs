using UnityEngine;
internal class HalvorsenAttractorBehaviour : BaseAttractorBehaviour
{
    private const float a = 1.4f;
    public override void Initialize(ChaosAttractorGenerator owner)
    {
        _position = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));

        base.Initialize(owner);
    }
    public override Vector3 UpdatedPositionBasedOnFormula()
    {
        float x_dot = -a * _position.x - 4.0f * _position.y - 4.0f * _position.z - Mathf.Pow(_position.y, 2);
        float y_dot = -a * _position.y - 4.0f * _position.z - 4.0f * _position.x - Mathf.Pow(_position.z, 2);
        float z_dot = -a * _position.z - 4.0f * _position.x - 4.0f * _position.y - Mathf.Pow(_position.x, 2);

        _position.x += x_dot * 0.005f;
        _position.y += y_dot * 0.005f;
        _position.z += z_dot * 0.005f;

        return _position;
    }
    public override void Terminate() => _owner.Terminate();
}