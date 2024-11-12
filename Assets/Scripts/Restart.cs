using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] ObsticalsCreator creator;
    [SerializeField] Vector3 startPosition;
    [SerializeField] GameObject goal;
    [SerializeField] GameObject panel;
    [SerializeField] PlayerController playerController;
    [SerializeField] Animator doorClose;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        panel.active = false;
        doorClose.Play("New State");
        GameObject[] objectsToRemove = GameObject.FindGameObjectsWithTag("Obstical");
        foreach (GameObject obj in objectsToRemove)
        {
            Destroy(obj);
        }
        if (creator != null)
        {
            creator.SpawnObstacle();
        }
        player.transform.position = startPosition;
        player.transform.localScale = Vector3.one;
        playerController.gameOn = true;
    }
}
