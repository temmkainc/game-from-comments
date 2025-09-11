using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private float _startPos;
    private float _length;
    [SerializeField] private Transform _camera;
    [SerializeField] private float _parallaxEffect;

    private void Start()
    {
        _startPos = transform.position.x;
        _length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void LateUpdate()
    {
        float distance = _camera.position.x * _parallaxEffect;
        float movement = _camera.position.x * (1 - _parallaxEffect);
        transform.position = new Vector3(_startPos + distance, transform.position.y, transform.position.z);

        if (movement > _startPos + _length)
        {
            _startPos += _length;
        }
        else if
            (movement < _startPos - _length)
        {
            _startPos -= _length;
        }
    }
}
