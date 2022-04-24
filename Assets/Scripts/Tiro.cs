using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    public Transform targetPosition, attackPos;
    public float movSpeed = 5f, attackRange = 5, ataqueValor = 10, timeBtwAttack, startTimeBtwAttack = .3f;
    public GameObject prefabTiro, target;
    public LayerMask enemiesLayer;
    public bool canAttack; 

    void Start()
    {

    }

    void Update()
    {   
        if (timeBtwAttack <= 0)
        {
            canAttack = true;
            // if (canAttack)
            // {
            //     Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemiesLayer);
            //     for (int i = 0; i < enemies.Length; i++)
            //     {   print("spawnou");
            //         GameObject obj = Instantiate(prefabTiro, enemies[i].GetComponent<Transform>().transform.position, Quaternion.identity);
            //         Vector3 moveDir = (targetPosition.transform.position - obj.transform.position).normalized;
            //         obj.transform.position += moveDir * movSpeed * Time.deltaTime;
            //     }
            // }
            timeBtwAttack = startTimeBtwAttack;
        }
        else 
        { 
            timeBtwAttack -= Time.deltaTime; 
            if (obj_ != null) { Mover(col_, obj_); }
            canAttack = false;
        }
        if (timeBtwAttack <= 0) { timeBtwAttack = 0; }
        else { timeBtwAttack -= Time.deltaTime; }
        
    }

    GameObject obj_;
    Collider2D col_;
    void OnTriggerStay2D(Collider2D col)
    {
        if (canAttack && col.gameObject.tag == "Inimigo")
        {
            GameObject obj = Instantiate(prefabTiro, this.transform.position, Quaternion.identity);
            obj_ = obj;
            col_ = col;
        }
    }

    void Mover(Collider2D col, GameObject obj)
    {
        Vector3 moveDir = (col.transform.position - obj.transform.position).normalized;
        obj.transform.position += moveDir * movSpeed * Time.deltaTime;
    }
}
