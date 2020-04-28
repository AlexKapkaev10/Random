using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] figures;

    [Header("Position X")]
    [SerializeField] private float minPosX;
    [SerializeField] private float maxPosX;

    [Header("Position Y")]
    [SerializeField] private float minPosY;
    [SerializeField] private float maxPosY;

    [Header("Position Z")]
    [SerializeField] private float minPosZ;
    [SerializeField] private float maxPosZ;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int currentFigureNum = Random.Range(0, figures.Length);
            float randomPosX = Random.Range(minPosX, maxPosX);
            float randomPosY = Random.Range(minPosY, maxPosY);
            float randomPosZ = Random.Range(minPosZ, maxPosZ);

            GameObject thisFigure = Instantiate(figures[currentFigureNum], new Vector3(randomPosX, randomPosY, randomPosZ), Quaternion.identity);
        }
    }
}
