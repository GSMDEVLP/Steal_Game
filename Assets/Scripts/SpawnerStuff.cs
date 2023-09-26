using System.Collections.Generic;
using UnityEngine;

public class SpawnerStuff : MonoBehaviour
{
    [SerializeField] private List<GameObject> _objects;
    [SerializeField] private List<GameObject> _posSpawns;
    private List<GameObject> _spawnPoints = new List<GameObject>();

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
            _spawnPoints.Add(child);
        }
    }

    public void SpawnStuff()
    {
        foreach (GameObject pos in _spawnPoints)
        {
            int randomObj = Random.Range(0, _objects.Count);
            GameObject obj = _objects[randomObj];
            _selectedObj.Add(obj);
            Instantiate(obj, pos.transform.position, Quaternion.identity, pos.transform);
            _objects.RemoveAt(randomObj); 
        }
    }
}
