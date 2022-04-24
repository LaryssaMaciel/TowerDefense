using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public GameObject[] targets;
    public GameObject target;
    public int num = 0, speed = 3, totalTargets = 10, vida = 5; // numero do target
    public GameObject caminho;
    public string caminhoTag, tagTarget;

    void Update()
    {
        caminho = GameObject.FindGameObjectWithTag(caminhoTag);
        targets = GameObject.FindGameObjectsWithTag(tagTarget);

        if (vida <= 0)
        {
            Destroy(this.gameObject);
        }

        if (num < totalTargets && targets != null) 
        {
            target = targets[num];
        }
        
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);
    
        if (tagTarget == "target1")
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    void Flip()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "tiro")
        {
            vida--;
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "target" || col.gameObject.tag == "target1")
        {
            num++;
        }
    }
}
