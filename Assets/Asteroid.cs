using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Vector2 _direction = new(-1f, -1f);
    private float _speed = 1f;

    private float _lifeTime = 5f;

    private void Update()
    {
        transform.position += (Vector3)_direction.normalized * (_speed * Time.deltaTime);
        _lifeTime -= Time.deltaTime;
        if (_lifeTime <= 0)
            Destroy(gameObject);
    }
}