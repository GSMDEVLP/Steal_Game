using System.Collections.Generic;
using UnityEngine;

public class SpawnerNPS : MonoBehaviour
{
    [SerializeField] private Transform _spawnArea; // Ссылка на территорию, в которой будут спавниться игроки
    [SerializeField] private GameObject[] _playerPrefab; // Префаб игрока

    private List<Vector3> _spawnPoints = new List<Vector3>(); // Список точек спавна
    private void PlayerPosition()
    {
        // Перебираем дочерние объекты территории спавна и добавляем их позиции в список
        foreach (Transform child in _spawnArea)
        {
            _spawnPoints.Add(child.position);
        }        
    }

    public void SpawnNPCPlayers()
    {
        PlayerPosition();        
        
        for (int i = 0; i < _playerPrefab.Length; i++)
        {
            int randomIndex = Random.Range(0, _spawnPoints.Count); // Выбираем случайную точку спавна
            Vector3 spawnPoint = _spawnPoints[randomIndex];
            Instantiate(_playerPrefab[i], spawnPoint, Quaternion.identity);
            _spawnPoints.RemoveAt(randomIndex); // Удаляем использованную точку спавна из списка
        }
    }

}
