using UnityEngine;

public class GenerationStuff : MonoBehaviour
{
    private int _countModif = 3;
    private Renderer rendererObj;
    Color color;
    void Start()
    {
        rendererObj = GetComponent<Renderer>();
        SetColor();
    }

    private void SetColor()
    {
        int randomModif = Random.Range(0, _countModif);
        switch (randomModif)
        {
            case 0:
                color = Color.blue;
                break;
            case 1:
                color = Color.red;
                break;
            case 2:
                color = Color.green;
                break;
        }

        rendererObj.material.color = color;
    }

    public Color GetColor()
    {
        return color;
    }
}
