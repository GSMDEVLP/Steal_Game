using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private GameObject _endPanel;
    [SerializeField] private GameObject _playerPrefab; // Префаб игрока
    [SerializeField] private GenerationStuff[] _stuffPrefab;
    [SerializeField] private Text _textPoint;
    [SerializeField] private StealScript _pointCount;

    private void Start()
    {
        _pointCount = new StealScript();
        _slider = GetComponent<Slider>();
    }

    void Update()
    {
        _slider.value -= 0.05f;
        GameObject stuffObject = GameObject.FindWithTag("Stuff");
        AddPoints();
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

    private void AddPoints()
    {
        _textPoint.text = "Points: " + _pointCount._point.ToString();
    }
    /*private void CheckColorOfModif()
    {
        foreach(var count in _stuffPrefab)
        {
            if(count.GetColor() == Color.red)
            {
                Debug.Log("Иди нахуй! Красный цвет");
            }
            if (count.GetColor() == Color.green)
            {
                Debug.Log("Иди нахуй! Зеленый цвет");
            }
            if (count.GetColor() == Color.blue)
            {
                Debug.Log("Иди нахуй! Синий цвет");
            }
        }
    }*/
}
