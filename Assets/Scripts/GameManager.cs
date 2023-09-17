using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int _point = 1;

    [Header("SpawnNPC and Stuff")]
    public SpawnerNPS SpawnNPC;
    private SpawnerStuff[] _npc;


    void Start()
    {
        Instance = this;
        SpawnNPC.SpawnNPCPlayers();      
    }

    private void Update()
    {
        _npc = FindObjectsOfType<SpawnerStuff>();
        DestroyOnClick();
        AddTime();
    }

    private void DestroyOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Stuff"))
                {
                    ScoreScript.ScoreHit(_point);
                    Destroy(hit.collider.gameObject);
                }
                else
                {
                    Debug.Log("SASAT");
                }
            }
        }
    }

    private void AddTime()
    {
        GameObject stuffObject = GameObject.FindWithTag("Stuff");        
        if (stuffObject == null)
        {
            MenuUI._slider.value += 20f;
            foreach (var obj in _npc)
            {
                Destroy(obj.gameObject);
            }
            SpawnNPC.SpawnNPCPlayers();
        }
    }
}
