using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Rigidbody2D rb;

    public float velocidade;

    public TextMeshProUGUI ui;

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
        if (collision.tag != "Player" && collision.tag != "Bullet")
        {
            Destroy(this.gameObject);

        }

        if (collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);

            ui.text = ""+(Int32.Parse(ui.text) + 1);

        }
    }
}
