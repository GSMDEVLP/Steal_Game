using System.Collections.Generic;
using UnityEngine;

public class SpawnerStuff : MonoBehaviour
{
    [SerializeField] private List<GameObject> _objects;
    [SerializeField] private List<GameObject> _posSpawns;
    private List<Vector3> _spawnPoints = new List<Vector3>(); // Список точек спавна

    private List<GameObject> _selectedObj = new List<GameObject>();
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
        foreach (Vector3 pos in _spawnPoints)
        {
            int randomObj = Random.Range(0, _objects.Count); // Выбираем случайный объект
            GameObject obj = _objects[randomObj];
            _selectedObj.Add(obj);
            Instantiate(obj, pos, Quaternion.identity);
            _objects.RemoveAt(randomObj); // Удаляем использованную точку спавна из списка
        }
    }
}
