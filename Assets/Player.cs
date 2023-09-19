using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float velocidade;

    private Rigidbody2D rb;

    public Transform right, left, up, down;

    public TextMeshProUGUI ui;

    public GameObject overlay;
    public GameObject bullet;

    private Bullet b;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    int dir_x = 0, dir_y = 0;

    // Update is called once per frame
    void Update()
    {

        dir_x = 0;
        dir_y = 0;
        

        if(Input.GetKey(KeyCode.D))
        {

            dir_x = 1;
            
        } 
        else if (Input.GetKey(KeyCode.A))
        {

            dir_x = -1;

        }

        if (Input.GetKey(KeyCode.S)) 
        {

            dir_y = -1;

        } 
        else if (Input.GetKey(KeyCode.W))
        {

            dir_y = 1;

        }

        
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {

            atirar(1, 0, right);

            

        } else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {

            atirar(-1, 0, left);

        } else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            atirar(0, 1, up);

        } else if (Input.GetKeyUp(KeyCode.DownArrow))
        {

            atirar(0, -1, down);

        }


        rb.velocity = new Vector2(dir_x * velocidade, dir_y * velocidade);

    }
    void atirar(int dir_x, int dir_y, Transform pos)
    {
        GameObject go = Instantiate(bullet, pos.position, pos.rotation);
        b = go.GetComponent<Bullet>();
        b.dir = new Vector2(dir_x, dir_y);
        b.ui = this.ui;
    }

}
