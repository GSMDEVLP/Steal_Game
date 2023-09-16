using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> _objects;
    [SerializeField] private List<GameObject> _posSpawns;
    private int _countModif = 3;
    private MeshRenderer _rendererObj;
    public int _point = 0;


    private List<Vector3> _spawnPoints = new List<Vector3>(); // ������ ����� ������
    private Color[] _availableColors = { Color.blue, Color.red, Color.black };


    void Start()
    {        
        foreach (GameObject child in _posSpawns)
        {
            _spawnPoints.Add(child.transform.position);
        }
        SpawnStuff();
    }

    private void SpawnStuff()
    {
        foreach (GameObject obj in _objects)
        {
            int randomIndex = Random.Range(0, _spawnPoints.Count); // �������� ��������� ����� ������
            Vector3 spawnPoint = _spawnPoints[randomIndex];
            //int randomModif = Random.Range(0, _countModif);
/*            // ������� ����� ���������
            MeshRenderer rendererObj = obj.GetComponent<MeshRenderer>();
            Material materialCopy = new Material(rendererObj.sharedMaterial);

            Color color = Color.white; // ���� �� ���������

            switch (randomModif)
            {
                case 0:
                    color = Color.blue;
                    break;
                case 1:
                    color = Color.red;
                    break;
                case 2:
                    color = Color.black;
                    break;
                    // �������� �������������� ������, ���� ����������
            }

            // ������������� ���� � ����� ���������
            materialCopy.color = color;

            // ����������� ����� ��������� �������� �������
            obj.GetComponent<MeshRenderer>().material = materialCopy;*/

            // ������� ������� ������� � ���������� ����������
            Instantiate(obj, spawnPoint, Quaternion.identity);

            _spawnPoints.RemoveAt(randomIndex); // ������� �������������� ����� ������ �� ������
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0)) // ��������� ������� ����� ������ ���� (��� ����� ������ ���� ������)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Stuff"))
                {
                    // ������� ������ � ��������� �����
                    Destroy(hit.collider.gameObject);
                    _point++;
                }
                else
                {
                    Debug.Log("SASAT");
                }
            }
        }
    }
}
