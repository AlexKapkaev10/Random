using System.Collections.Generic;
using UnityEngine;

public class Saver : MonoBehaviour
{
    [Header("Position X")]
    [SerializeField] private float _minPositionX;
    [SerializeField] private float _maxPositionX;

    [Header("Position Y")]
    [SerializeField] private float _minPositionY;
    [SerializeField] private float _maxPositionY;

    [Header("Position Z")]
    [SerializeField] private float _minPositionZ;
    [SerializeField] private float _maxPositionZ;

    private void Start()
    {
        LoadGame();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {            
            float randomPosX = Random.Range(_minPositionX, _maxPositionX);
            float randomPosY = Random.Range(_minPositionY, _maxPositionY);
            float randomPosZ = Random.Range(_minPositionZ, _maxPositionZ);
            transform.position = new Vector3(randomPosX, randomPosY, randomPosZ);
            SaveGame();
        }
    }
    private void LoadGame()
    {
        string loadPosition = PlayerPrefs.GetString("FigureLocation");

        if(loadPosition !=null && loadPosition.Length > 0)
        {
            SavePosition savePosition = JsonUtility.FromJson<SavePosition>(loadPosition);

            if(savePosition != null)
            {
                Vector3 newPosition = new Vector3();
                newPosition.x = savePosition.x;
                newPosition.y = savePosition.y;
                newPosition.z = savePosition.z;
                gameObject.transform.position = newPosition;
            }
        }
    }

    private void SaveGame()
    {
        SavePosition savePosition = new SavePosition();
        savePosition.x = gameObject.transform.position.x;
        savePosition.y = gameObject.transform.position.y;
        savePosition.z = gameObject.transform.position.z;
        string json = JsonUtility.ToJson(savePosition);
        PlayerPrefs.SetString("FigureLocation", json);
    }
}
