using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int _point = 1;
    public static bool EndGame = false;
    [Header("SpawnNPC and Stuff")]
    public SpawnerNPS SpawnNPC;
    private SpawnerStuff[] _npc;
    private AddMaterialsAndModifScript _addModif;
    

    void Start()
    {
        Instance = this;
        SpawnNPC.SpawnNPCPlayers();      
    }

    private void Update()
    {
        _npc = FindObjectsOfType<SpawnerStuff>();
        DestroyOnClick();
        RestartLevelAndAddTime();
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
                    _addModif = hit.collider.GetComponent<AddMaterialsAndModifScript>();
                    CheckModif(_addModif.modif);
                    Destroy(hit.collider.gameObject);
                }                    
            }
        }
    }

    private void RestartLevelAndAddTime()
    {
        GameObject stuffObject = GameObject.FindWithTag("Stuff");        
        if (stuffObject == null)
        {
            MenuUI._slider.value += 20f;
            RestartLevel();
        }
        else
        {
            AddMaterialsAndModifScript[] redStuff = FindObjectsOfType<AddMaterialsAndModifScript>();
            bool allElementsHaveUnstealModif = redStuff.All(item => item.modif == AddMaterialsAndModifScript.StuffModif.Unsteal);
            if (allElementsHaveUnstealModif)
            {
                foreach (var item in redStuff)
                    Destroy(item.gameObject);
                RestartLevel();
            }
        }
    }

    private void CheckModif(AddMaterialsAndModifScript.StuffModif modif)
    {
        if (modif == AddMaterialsAndModifScript.StuffModif.StealTime)
            MenuUI._slider.value += 20f;
        else if (modif == AddMaterialsAndModifScript.StuffModif.Unsteal)
            EndGame = true;
        else if(modif == AddMaterialsAndModifScript.StuffModif.Steal)
            ScoreScript.ScoreHit(_point);
    }

    private void RestartLevel()
    {
        foreach (var obj in _npc)
        {
            Destroy(obj.gameObject);
        }
        SpawnNPC.SpawnNPCPlayers();
    }
}
