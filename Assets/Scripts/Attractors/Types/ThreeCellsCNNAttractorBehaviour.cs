using UnityEngine;
internal class ThreeCellsCNNAttractorBehaviour : BaseAttractorBehaviour
{
    private const float p1 = 1.24f;
    private const float p2 = 1.1f;
    private const float r = 4.4f;
    private const float s = 3.21f;
    public override void Initialize(ChaosAttractorGenerator owner)
    {
        base.Initialize(owner);
        
        // _position = new Vector3(0.1f, 0.1f, 0.1f);
        _position = new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f));
    }
    public override Vector3 UpdatedPositionBasedOnFormula()
    {
        float h1 = 0.5f * (Mathf.Abs(_position.x + 1) - Mathf.Abs(_position.x - 1));
        float h2 = 0.5f * (Mathf.Abs(_position.y + 1) - Mathf.Abs(_position.y - 1));
        float h3 = 0.5f * (Mathf.Abs(_position.z + 1) - Mathf.Abs(_position.z - 1));

        float x_dot = -_position.x + p1 * h1 - s * h2 - s * h3;
        float y_dot = - _position.y - s * h1 + p2 * h2 - r * h3;
        float z_dot = - _position.z - s * h1 + r * h2 + h3;
                                                                            
        _position.x += x_dot * 0.007f;
        _position.y += y_dot * 0.007f;
        _position.z += z_dot * 0.007f;
        
        return _position;
    }
}