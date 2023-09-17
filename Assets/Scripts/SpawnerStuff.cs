using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerStuff : MonoBehaviour
{
    [SerializeField] private List<GameObject> _objects;
    [SerializeField] private List<GameObject> _posSpawns;
    private List<Vector3> _spawnPoints = new List<Vector3>(); // Список точек спавна


    private void Start()
    {
        StuffPosition();
        SpawnStuff();
    }
    void StuffPosition()
    {
        foreach (GameObject child in _posSpawns)
        {
            _spawnPoints.Add(child.transform.position);
        }
    }

    public void SpawnStuff()
    {
        //StuffPosition();
        foreach (GameObject obj in _objects)
        {
            int randomIndex = Random.Range(0, _spawnPoints.Count); // Выбираем случайную точку спавна
            Vector3 spawnPoint = _spawnPoints[randomIndex];
            Instantiate(obj, spawnPoint, Quaternion.identity);
            _spawnPoints.RemoveAt(randomIndex); // Удаляем использованную точку спавна из списка
        }
    }


}
