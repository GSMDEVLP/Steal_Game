using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMaterialsAndModifScript : MonoBehaviour
{
    private int _countModif = 3;
    /*private Renderer rendererObj;
    private Color color;*/
    public StuffModif modif;
    void Start()
    {
        //rendererObj = GetComponent<Renderer>();
        SetColor();
    }

    public enum StuffModif
    {
        Steal,
        Unsteal,
        StealTime
    }

    private void SetColor()
    {
        int randomModif = Random.Range(0, _countModif);
        switch (randomModif)
        {
            case 0:
                //color = Color.blue;
                modif = StuffModif.Steal;
                break;
            case 1:
                //color = Color.red;
                modif = StuffModif.Unsteal;
                break;
            case 2:
                //color = Color.green;
                modif = StuffModif.StealTime;
                break;
        }
        //rendererObj.material.color = color;
    }

    public StuffModif GetModif()
    {
        return modif;
    }
}
