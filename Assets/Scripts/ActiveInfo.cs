using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveInfo : MonoBehaviour
{
    [SerializeField] private GameObject _infoPanel;
    public void InfoButton()
    {
        _infoPanel.SetActive(true);
    }

    public void ReturnButton()
    {
        _infoPanel.SetActive(false);
    }
}
