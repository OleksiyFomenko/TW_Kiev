using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject player;
    [SerializeField] GameObject pass;
    [SerializeField] Vector3 spawnPos;

    private bool isHolding = false;
    private GameObject bullet;
    private bool moving = false;
    public bool gameOn = true;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && gameOn)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                moving = false;
                bullet = Instantiate(bulletPrefab, spawnPos, bulletPrefab.transform.rotation);
                bullet.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
                isHolding = true;
            }
            else if (touch.phase == TouchPhase.Stationary)
            {
                bullet.transform.localScale += new Vector3(1f * Time.deltaTime, 1f * Time.deltaTime, 1f * Time.deltaTime);
                player.transform.localScale -= new Vector3(0.5f* Time.deltaTime, 0.5f*Time.deltaTime, 0.5f * Time.deltaTime);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                moving = true;
                isHolding = false;
            }
        }

        if (bullet != null && moving)
        {
            bullet.transform.position += Vector3.forward * Time.deltaTime * 2f;
        }
    }
}
