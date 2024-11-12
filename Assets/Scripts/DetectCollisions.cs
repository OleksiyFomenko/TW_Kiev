using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    [SerializeField] GameObject areaDestruction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject!=null)
        {
            areaDestruction.transform.localScale = gameObject.transform.localScale * 2;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstical"))
        {
            areaDestruction = Instantiate(areaDestruction, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }    
}
