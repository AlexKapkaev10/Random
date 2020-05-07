using System;
using System.Collections.Generic;

[System.Serializable]
public class SaveData
{
    public List<Figure> figureScripts;
    public List<float> positionListX; 
    public List<float> positionListY;  
    public List<float> positionListZ;

    public List<float> scaleList;

    public List<float> colorListR;
    public List<float> colorListG;
    public List<float> colorListB;

    public List<int> typeCodeList;
    

    public string type;
}
