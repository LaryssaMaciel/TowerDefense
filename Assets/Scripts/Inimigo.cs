using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public GameObject[] targets;
    public GameObject target;
    public int num = 0, speed = 3, totalTargets = 3; // numero do target
    public GameObject caminho;
    
    void Start()
    {
        targets = GameObject.FindGameObjectsWithTag("target");
    }

    void Update()
    {
        target = targets[num];
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "tiro")
        {
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "target")
        {
            num++;
        }
    }
}
