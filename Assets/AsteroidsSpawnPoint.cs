using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AsteroidsSpawnPoint : MonoBehaviour
{
    [SerializeField] private List<Asteroid> _asteroids;
    [SerializeField] private BoxCollider2D _boxCollider;
    [SerializeField] private float _spawnInterval = 2f;

    private bool _isSpawning;
    private Coroutine _spawnCoroutine;
    private List<Asteroid> _spawnAsteroids = new();

    public void StartSpawning()
    {
        if (_isSpawning) return;

        _isSpawning = true;
        _spawnCoroutine = StartCoroutine(SpawnRoutine());
    }

    public void StopSpawning()
    {
        if (!_isSpawning) return;

        _isSpawning = false;
        if (_spawnCoroutine != null)
        {
            StopCoroutine(_spawnCoroutine);
            _spawnCoroutine = null;
        }

        ClearInstance();
    }

    private void ClearInstance()
    {
        _spawnAsteroids.ForEach((item) =>
        {
            if (item != null)
                Destroy(item.gameObject);
        });
        _spawnAsteroids.Clear();
    }

    private IEnumerator SpawnRoutine()
    {
        while (_isSpawning)
        {
            SpawnAsteroid();
            yield return new WaitForSeconds(_spawnInterval);
        }
    }

    private void SpawnAsteroid()
    {
        if (_asteroids.Count == 0) return;

        Asteroid asteroidPrefab = _asteroids[Random.Range(0, _asteroids.Count)];

        Vector2 spawnPosition = GetRandomPointInCollider();

        var instance = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
        _spawnAsteroids.Add(instance);
    }

    private Vector2 GetRandomPointInCollider()
    {
        Bounds bounds = _boxCollider.bounds;
        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomY = Random.Range(bounds.min.y, bounds.max.y);

        return new Vector2(randomX, randomY);
    }
}