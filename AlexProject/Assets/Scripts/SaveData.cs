using System.Collections.Generic;

[System.Serializable]
public class SaveData
{
    public float positionX;
    public float positionY;
    public float positionZ;

    public float scale;

    public float colorR;
    public float colorG;
    public float colorB;

    public string type;

    public enum Type
    {
        cube,
        sphere,
        cylinder
    }

    public Type myType;

    public int count;
}
