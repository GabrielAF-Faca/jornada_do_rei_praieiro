using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Rigidbody2D rb;

    private Transform right, left, up, down;

    public GameObject bullet;

    private Enemy_Bullet b;

    private float timer = 0, tempoTiro;

    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        right = GetComponentsInChildren<Transform>()[1];
        left = GetComponentsInChildren<Transform>()[2];
        up = GetComponentsInChildren<Transform>()[3];
        down = GetComponentsInChildren<Transform>()[4];

        tempoTiro = 1;

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            timer += Time.deltaTime;

            float diff_x = Math.Abs(player.transform.position.x - this.transform.position.x);
            float diff_y = Math.Abs(player.transform.position.y - this.transform.position.y);

            if (diff_x > diff_y)
            {
                if (player.transform.position.x > this.transform.position.x)
                {
                    rb.velocity = new Vector2(1, 0);

                }
                else
                {
                    rb.velocity = new Vector2(-1, 0);
                }
            }
            else
            {
                if (player.transform.position.y > this.transform.position.y)
                {
                    rb.velocity = new Vector2(0, 1);

                }
                else
                {
                    rb.velocity = new Vector2(0, -1);
                }
            }

            if (timer >= tempoTiro)
            {
                timer = 0;

                tempoTiro = UnityEngine.Random.Range(1, 4);

                if (diff_x > diff_y)
                {
                    if (player.transform.position.x > this.transform.position.x)
                    {
                        atirar(1, 0, right);

                    }
                    else
                    {
                        atirar(-1, 0, left);
                    }
                }
                else
                {
                    if (player.transform.position.y > this.transform.position.y)
                    {
                        atirar(0, 1, up);

                    }
                    else
                    {
                        atirar(0, -1, down);
                    }
                }


            }
        } else
        {
            rb.velocity = Vector2.zero;
        }
    }

    void atirar(int dir_x, int dir_y, Transform pos)
    {
        GameObject go = Instantiate(bullet, pos.position, pos.rotation);
        b = go.GetComponent<Enemy_Bullet>();
        b.dir = new Vector2(dir_x, dir_y);
    }
}
