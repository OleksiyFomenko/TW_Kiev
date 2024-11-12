using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticalsCreator : MonoBehaviour
{
    [SerializeField] GameObject obsticalsPrefab;
    [SerializeField] int obsticalsCount = 100;
    [SerializeField] float xMin;
    [SerializeField] float xMax;
    [SerializeField] float zMin;
    [SerializeField] float zMax;
    private Vector3 spawnPos;

    // Start is called before the first frame update
    void Start()
    {
        SpawnObstacle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnObstacle()
    {
        for (int i = 0; i < obsticalsCount; i++)
        {
            spawnPos = new Vector3(Random.Range(xMin, xMax), -1.9f, Random.Range(zMin, zMax));
            Instantiate(obsticalsPrefab, spawnPos, obsticalsPrefab.transform.rotation);
        }
    }    
}
