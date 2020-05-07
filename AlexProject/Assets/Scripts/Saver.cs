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

    public List<Figure> figuresList;
    public List<float> positionListX;
    public List<float> positionListY;
    public List<float> positionListZ;
    
    public List<float> scaleList;
    
    public List<float> colorListR;
    public List<float> colorListG;
    public List<float> colorListB;
    
    public List<int> typeCodeList;

    private Figure _figureScript;
    
    public GameObject[] figurePrefabs;
    private int _currentFigureNumber;
    

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
        if (Input.GetMouseButtonDown(0))
        {
            float randomPosX = Random.Range(_minPositionX, _maxPositionX);
            float randomPosY = Random.Range(_minPositionY, _maxPositionY);
            float randomPosZ = Random.Range(_minPositionZ, _maxPositionZ);
            float randomScale = Random.Range(0.5f, maxScale);

            _currentFigureNumber = Random.Range(0, figurePrefabs.Length);
                 
            
            thisFigure = Instantiate(figurePrefabs[_currentFigureNumber]);
            
            
            thisFigure.transform.position = new Vector3(randomPosX, randomPosY, randomPosZ);
            _meshRenderer = thisFigure.GetComponent<MeshRenderer>();
            _figureScript = thisFigure.GetComponent<Figure>();
            

            _meshRenderer.material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            thisFigure.transform.localScale = new Vector3(randomScale, randomScale, randomScale);

            _figureScript.positionX = randomPosX;
            _figureScript.positionY = randomPosY;
            _figureScript.positionZ = randomPosZ;

            _figureScript.scale = randomScale;

            _figureScript.colorR = _meshRenderer.material.color.r;
            _figureScript.colorG = _meshRenderer.material.color.g;
            _figureScript.colorB = _meshRenderer.material.color.b;
            
            

            figuresList.Add(_figureScript);
            positionListX.Add(_figureScript.positionX);
            positionListY.Add(_figureScript.positionY);
            positionListZ.Add(_figureScript.positionZ);
            
            scaleList.Add(_figureScript.scale);
            
            colorListR.Add(_figureScript.colorR);
            colorListG.Add(_figureScript.colorG);
            colorListB.Add(_figureScript.colorB);

            int _typeCode = _figureScript.myType.GetHashCode();
            typeCodeList.Add(_typeCode);
            
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
                figuresList = saveData.figureScripts;
                typeCodeList = saveData.typeCodeList;
                
                for (int i = 0; i < figuresList.Count; i++)
                {
                    int thisTypeCode = typeCodeList[i];
                    thisFigure = Instantiate(figurePrefabs[thisTypeCode]);
                    _figureScript = thisFigure.GetComponent<Figure>();
                    figuresList[i] = _figureScript;
                    positionListX = saveData.positionListX;
                    positionListY = saveData.positionListY;
                    positionListZ = saveData.positionListZ;

                    scaleList = saveData.scaleList;

                    colorListR = saveData.colorListR;
                    colorListG = saveData.colorListG;
                    colorListB = saveData.colorListB;

                    
                    
                    Vector3 newPosition = new Vector3();
                    newPosition.x = positionListX[i];
                    newPosition.y = positionListY[i];
                    newPosition.z = positionListZ[i];

                    float newScale;
                    newScale = saveData.scaleList[i];
                    
                    thisFigure.transform.position = newPosition;
                    thisFigure.transform.localScale = new Vector3(newScale, newScale, newScale);

                    float newColorR;
                    float newColorG;
                    float newColorB;
                    newColorR = saveData.colorListR[i];
                    newColorG = saveData.colorListG[i];
                    newColorB = saveData.colorListB[i];
                    _meshRenderer = thisFigure.GetComponent<MeshRenderer>();
                    _meshRenderer.material.color = new Color(newColorR, newColorG, newColorB);
                }
            }
        }
    }

    private void SaveGame()
    {
        SaveData saveData = new SaveData();
        saveData.positionListX = positionListX;
        saveData.positionListY = positionListY;
        saveData.positionListZ = positionListZ;

        saveData.scaleList = scaleList;

        saveData.colorListR = colorListR;
        saveData.colorListG = colorListG;
        saveData.colorListB = colorListB;

        saveData.figureScripts = figuresList;
        saveData.typeCodeList = typeCodeList;

        string json = JsonUtility.ToJson(saveData);
        PlayerPrefs.SetString("FigureLocation", json);
    }
}
