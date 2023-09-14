using System.Collections.Generic;
using UnityEngine;

public class SpawnerNPS : MonoBehaviour
{
    [SerializeField] private Transform _spawnArea; // ������ �� ����������, � ������� ����� ���������� ������
    [SerializeField] private GameObject _playerPrefab; // ������ ������

    private List<Vector3> _spawnPoints = new List<Vector3>(); // ������ ����� ������

    private void Start()
    {
        // ���������� �������� ������� ���������� ������ � ��������� �� ������� � ������
        foreach (Transform child in _spawnArea)
        {
            _spawnPoints.Add(child.position);
        }

        SpawnPlayers();
    }

    private void SpawnPlayers()
    {
        // ����� �� ������ ����������� ����� ������� �� ��������� ��������
        // ��������, �������� ���� ��� ������ ������������� ���������� �������
        int numberOfPlayersToSpawn = 3; // �������� �� ������ ���������� �������
        for (int i = 0; i < numberOfPlayersToSpawn; i++)
        {
            int randomIndex = Random.Range(0, _spawnPoints.Count); // �������� ��������� ����� ������
            Vector3 spawnPoint = _spawnPoints[randomIndex];
            Instantiate(_playerPrefab, spawnPoint, Quaternion.identity);
            _spawnPoints.RemoveAt(randomIndex); // ������� �������������� ����� ������ �� ������
        }
    }
}
