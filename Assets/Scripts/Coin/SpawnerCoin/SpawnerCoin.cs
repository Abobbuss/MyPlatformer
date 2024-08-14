using UnityEngine;

public class SpawnerCoin : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;

    private void Start()
    {
        SpawnCoin();
    }

    private void SpawnCoin()
    {
        float halfSpawnerPositionX = transform.localScale.x / 2;
        float randomX = Random.Range(transform.position.x - halfSpawnerPositionX, transform.position.x + halfSpawnerPositionX);
        float spawnY = transform.position.y;

        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0f);
        Instantiate(_coinPrefab, spawnPosition, Quaternion.identity);
    }
}
