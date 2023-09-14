using System.Collections.Generic;
using UnityEngine;

public class SpawnerNPS : MonoBehaviour
{
    [SerializeField] private Transform _spawnArea; // Ссылка на территорию, в которой будут спавниться игроки
    [SerializeField] private GameObject _playerPrefab; // Префаб игрока

    private List<Vector3> _spawnPoints = new List<Vector3>(); // Список точек спавна

    private void Start()
    {
        // Перебираем дочерние объекты территории спавна и добавляем их позиции в список
        foreach (Transform child in _spawnArea)
        {
            _spawnPoints.Add(child.position);
        }

        SpawnPlayers();
    }

    private void SpawnPlayers()
    {
        // Здесь вы можете реализовать спавн игроков на случайных позициях
        // Например, создайте цикл для спавна определенного количества игроков
        int numberOfPlayersToSpawn = 3; // Измените на нужное количество игроков
        for (int i = 0; i < numberOfPlayersToSpawn; i++)
        {
            int randomIndex = Random.Range(0, _spawnPoints.Count); // Выбираем случайную точку спавна
            Vector3 spawnPoint = _spawnPoints[randomIndex];
            Instantiate(_playerPrefab, spawnPoint, Quaternion.identity);
            _spawnPoints.RemoveAt(randomIndex); // Удаляем использованную точку спавна из списка
        }
    }
}
