using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointPlayer : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Player _playerPrefab;

    private void Start()
    {
        Player _ = Instantiate(_playerPrefab, _spawnPoint.position, _spawnPoint.rotation);
    }
}
