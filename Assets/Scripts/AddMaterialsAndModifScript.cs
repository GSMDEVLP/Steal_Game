using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMaterialsAndModifScript : MonoBehaviour
{
    private int _countModif = 3;
    public StuffModif modif;
    private Outline outlineComponent;
    void Start()
    {
        outlineComponent = GetComponent<Outline>();
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
                outlineComponent.OutlineColor = Color.green;
                modif = StuffModif.Steal;
                break;
            case 1:
                outlineComponent.OutlineColor = Color.red;
                modif = StuffModif.Unsteal;
                break;
            case 2:
                outlineComponent.OutlineColor = Color.blue;
                modif = StuffModif.StealTime;
                break;
        }
    }

    public StuffModif GetModif()
    {
        return modif;
    }
}
