using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject startPoint;
    public GameObject Player;
    public GameObject pipe;
    public float spawnRate = 2;
    private float timer = 0;
    public LogicScript logic;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<LogicScript>();
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer = timer  + Time.deltaTime;
        }
        else
        {
            spawnPipe();
            timer = 0;
        }
        
    }

    void spawnPipe()
    {
        Instantiate(pipe, transform.position, transform.rotation);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            logic.gameOver();
        }
    }
}
