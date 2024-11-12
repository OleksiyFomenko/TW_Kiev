using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckResult : MonoBehaviour
{
    [SerializeField] bool winSituation = false;
    [SerializeField] Animator doorOpen;
    [SerializeField] GameObject player;
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject losePanel;
    [SerializeField] PlayerController playerController;

    public int obstacleCount = 0;
    private int obstacleCountStart;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckWinSituation();
    }

    private void OnTriggerEnter(Collider other)
    {
            winSituation = false;
            doorOpen.Play("New Station");
    }

    private void OnTriggerStay(Collider other)
    {
        winSituation = false;
        doorOpen.Play("New Station");            
    }
    void OnTriggerExit(Collider other)
    {
        winSituation = true;
    }
    private void CheckWinSituation()
    {
        if (player.transform.localScale.y <= 0.2)
        {
            ShowLosePanel();
        }
        if (winSituation)
        {
            doorOpen.Play("Open");
            ShowWinPanel();
            StartCoroutine("Move");
        }
    }
    private IEnumerator Move()
    {
        yield return new WaitForSeconds(2f);
        player.transform.position += Vector3.forward * Time.deltaTime; ;
    }
    private void ShowWinPanel()
    {
        playerController.gameOn = false;
        winPanel.active = true;
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject obj in objects)
        {
            Destroy(obj);
        }
    }
    private void ShowLosePanel()
    {
        Time.timeScale = 0;
        playerController.gameOn = false;
        losePanel.active = true;
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject obj in objects)
        {
            Destroy(obj);
        }
    }
}
