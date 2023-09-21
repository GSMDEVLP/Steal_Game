using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public static Slider _slider;
    [SerializeField] private GameObject _endPanel;
    [SerializeField] private GameObject _playerPrefab; // Префаб игрока    

    private void Start()
    {
        _slider = GetComponent<Slider>();
    }


    void Update()
    {
        _slider.value -= 0.05f;
        if (_slider.value == 0)
        {
            _endPanel.SetActive(true);
        }
        EndGame();
    }

    public void EndGame()
    {
        if (GameManager.EndGame)
            _endPanel.SetActive(true);
    }
}
