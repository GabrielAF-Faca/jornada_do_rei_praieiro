using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject enemy;
    private Enemy e;
    private float timer = 0, tempoEspera = 0;

    // Start is called before the first frame update
    void Start()
    {
        tempoEspera = Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= tempoEspera && GameObject.FindGameObjectWithTag("Player") != null)
        {
            timer = 0;
         
            tempoEspera = Random.Range(2, 11);

            GameObject instance = Instantiate(enemy, this.transform);
            e = instance.GetComponent<Enemy>();

            e.player = GameObject.FindGameObjectWithTag("Player");

        }

    }
}
