﻿using System.Collections.Generic;
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

    public List<Figure> figuresList;

    private Figure figureScript;

    public GameObject figurePrefab;

    public int countFigure;

    public GameObject thisFigure;

    private void Start()
    {
        LoadGame();
    }

    private void Update()
    {
        InputSpawner();
    }

    private void InputSpawner()
    {
        if (Input.GetMouseButtonDown(0) && countFigure < 1)
        {
            float randomPosX = Random.Range(_minPositionX, _maxPositionX);
            float randomPosY = Random.Range(_minPositionY, _maxPositionY);
            float randomPosZ = Random.Range(_minPositionZ, _maxPositionZ);
            float randomScale = Random.Range(0.5f, maxScale);

            //int currentFigureNumber = Random.Range(0, figurePrefabs.Length);
            thisFigure = Instantiate(figurePrefab);
            thisFigure.transform.position = new Vector3(randomPosX, randomPosY, randomPosZ);
            _meshRenderer = thisFigure.GetComponent<MeshRenderer>();
            figureScript = thisFigure.GetComponent<Figure>();

            _meshRenderer.material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            thisFigure.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
            figureScript.positionX = randomPosX;
            figureScript.positionY = randomPosY;
            figureScript.positionZ = randomPosZ;

            figureScript.scale = randomScale;

            figureScript.colorR = thisFigure.GetComponent<MeshRenderer>().material.color.r;
            figureScript.colorG = thisFigure.GetComponent<MeshRenderer>().material.color.g;
            figureScript.colorB = thisFigure.GetComponent<MeshRenderer>().material.color.b;

            figuresList.Add(figureScript);
            countFigure++;
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
                thisFigure = Instantiate(figurePrefab);
                Vector3 newPosition = new Vector3();
                newPosition.x = saveData.positionX;
                newPosition.y = saveData.positionY;
                newPosition.z = saveData.positionZ;

                float newScale;
                newScale = saveData.scale;
                thisFigure.transform.position = newPosition;
                thisFigure.transform.localScale = new Vector3(newScale, newScale, newScale);

                float newColorR;
                float newColorG;
                float newColorB;
                newColorR = saveData.colorR;
                newColorG = saveData.colorG;
                newColorB = saveData.colorB;
                _meshRenderer = thisFigure.GetComponent<MeshRenderer>();
                _meshRenderer.material.color = new Color(newColorR, newColorG, newColorB);
                //countFigure = saveData.count;

            }
        }
    }

    private void SaveGame()
    {
        SaveData saveData = new SaveData();

        saveData.positionX = figureScript.positionX;
        saveData.positionY = figureScript.positionY;
        saveData.positionZ = figureScript.positionZ;

        saveData.scale = figureScript.scale;

        saveData.colorR = figureScript.colorR;
        saveData.colorG = figureScript.colorG;
        saveData.colorB = figureScript.colorB;

        saveData.count = countFigure;

        string json = JsonUtility.ToJson(saveData);
        //JsonUtility.ToJson(gameObject);
        PlayerPrefs.SetString("FigureLocation", json);
        Debug.Log(json);
    }
}
