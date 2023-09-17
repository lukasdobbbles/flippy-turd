using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletMiddleScript : MonoBehaviour
{
    public LogicScript logic;
    public PoopScript poop;


    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<LogicScript>();
        poop = GameObject.FindGameObjectWithTag("Bird").GetComponent<PoopScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3 && poop.birdIsAlive)
        {
            logic.addScore(1);
        }
        
    }
}
