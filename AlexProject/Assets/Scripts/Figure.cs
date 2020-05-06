using UnityEngine;

public class Figure : MonoBehaviour
{
    public float positionX;
    public float positionY;
    public float positionZ;

    public float scale;

    public float colorR;
    public float colorG;
    public float colorB;

    private MeshRenderer _meshRenderer;

    
    public enum Type
    {
        cube,
        sphere,
        cylinder
    }

    public Type myType;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        positionX = transform.position.x;
        positionY = transform.position.y;
        positionZ = transform.position.z;

        scale = transform.localScale.x;

        colorR = _meshRenderer.material.color.r;
        colorG = _meshRenderer.material.color.g;
        colorB = _meshRenderer.material.color.b;
    }
}
