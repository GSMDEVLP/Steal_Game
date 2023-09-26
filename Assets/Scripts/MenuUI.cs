using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public static Slider _slider;
    [SerializeField] private GameObject _endPanel;
    [SerializeField] private Text _timeText;

    private void Start()
    {
        _slider = GetComponent<Slider>();
    }


    void Update()
    {
        MenuGame();
    }

    private void MenuGame()
    {
        _slider.value -= Time.deltaTime;
        _timeText.text = "Оставшееся время: " + Mathf.Round(_slider.value).ToString();
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
