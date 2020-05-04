using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] figures;

    public List<GameObject> SaverFigures;

    [Header("Position X")]
    [SerializeField] private float _minPositionX;
    [SerializeField] private float _maxPositionX;

    [Header("Position Y")]
    [SerializeField] private float _minPositionY;
    [SerializeField] private float _maxPositionY;

    [Header("Position Z")]
    [SerializeField] private float _minPositionZ;
    [SerializeField] private float _maxPositionZ;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int currentFigureNumber = Random.Range(0, figures.Length);
            float randomPosX = Random.Range(_minPositionX, _maxPositionX);
            float randomPosY = Random.Range(_minPositionY, _maxPositionY);
            float randomPosZ = Random.Range(_minPositionZ, _maxPositionZ);
            
            GameObject thisFigure = Instantiate(figures[currentFigureNumber], new Vector3(randomPosX, randomPosY, randomPosZ), Quaternion.identity);
            SaverFigures.Add(thisFigure);
            
        }
    }
}
