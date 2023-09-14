using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private GameObject _endPanel;
    [SerializeField] private GameObject _playerPrefab; // Префаб игрока

    private void Start()
    {
        _slider = GetComponent<Slider>();
    }

    void Update()
    {
        _slider.value -= 0.05f;
        GameObject stuffObject = GameObject.FindWithTag("Stuff");
        if (_slider.value == 0)
        {
            _endPanel.SetActive(true);
        }
        if (stuffObject == null)
        {
            _slider.value += 20f;
            Instantiate(_playerPrefab, new Vector3(1.65100002f, 0.300000012f, -1.30999994f), Quaternion.identity);
        }
    }
}
