using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        GameObject x = Instantiate(prefab);
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2.Distance(transform.position, transform.forward)

        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
            
    }
}
