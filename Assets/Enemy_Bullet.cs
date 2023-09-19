using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{

    private Rigidbody2D rb;

    public float velocidade;

    [HideInInspector]
    public Vector2 dir;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity =  dir * velocidade;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Enemy" && collision.tag != "Bullet")
        {
            Destroy(this.gameObject);

            if (collision.tag == "Player")
            {
                Player p = collision.gameObject.GetComponent<Player>();
                p.overlay.SetActive(true);
                Destroy(collision.gameObject);
            }


        }

        //if (collision.tag == "Enemy")
        //{
        //    Destroy(collision.gameObject);
        //}
    }
}
