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

    private float maxScale = 2f;

    private MeshRenderer _meshRenderer;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
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
            _meshRenderer.material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            float randomScale = Random.Range(0.5f, maxScale);
            transform.localScale = new Vector3(randomScale, randomScale, randomScale);
            SaveGame();
        }
    }
    private void LoadGame()
    {
        string loadData = PlayerPrefs.GetString("FigureLocation");

        if(loadData != null && loadData.Length > 0)
        {
            SaveData saveData = JsonUtility.FromJson<SaveData>(loadData);

            if(saveData != null)
            {
                Vector3 newPosition = new Vector3();
                newPosition.x = saveData.positionX;
                newPosition.y = saveData.positionY;
                newPosition.z = saveData.positionZ;

                float newScale;
                newScale = saveData.scale;
                gameObject.transform.position = newPosition;
                gameObject.transform.localScale = new Vector3(newScale, newScale, newScale);

                float newColorR;
                float newColorG;
                float newColorB;
                newColorR = saveData.colorR;
                newColorG = saveData.colorG;
                newColorB = saveData.colorB;
                _meshRenderer.material.color = new Color(newColorR, newColorG, newColorB);
            }
        }
    }

    private void SaveGame()
    {
        SaveData saveData = new SaveData();
        saveData.positionX = gameObject.transform.position.x;
        saveData.positionY = gameObject.transform.position.y;
        saveData.positionZ = gameObject.transform.position.z;

        saveData.scale = gameObject.transform.localScale.x;

        saveData.colorR = GetComponent<MeshRenderer>().material.color.r;
        saveData.colorG = GetComponent<MeshRenderer>().material.color.g;
        saveData.colorB = GetComponent<MeshRenderer>().material.color.b;
        string json = JsonUtility.ToJson(saveData);
        PlayerPrefs.SetString("FigureLocation", json);
        Debug.Log(json);
    }
}
