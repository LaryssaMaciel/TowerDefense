using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    public float movSpeed = 5f, ataqueValor = 10, timeBtwAttack, startTimeBtwAttack = .3f;
    public GameObject prefabTiro;
    public bool canAttack; 
    GameObject obj_;
    Collider2D col_;

    void Start()
    {

    }

    void Update()
    {   
        if (timeBtwAttack <= 0)
        {
            canAttack = true;
            
            timeBtwAttack = startTimeBtwAttack; 
        }
        else 
        { 
            timeBtwAttack -= Time.deltaTime; 
            if (obj_ != null && col_ != null) { Mover(col_, obj_); }
            canAttack = false;
        }
        if (timeBtwAttack <= 0) { timeBtwAttack = 0; }
        else { timeBtwAttack -= Time.deltaTime; }
        
    }
    
    void OnTriggerStay2D(Collider2D col)
    {
        if (canAttack && col.gameObject.tag == "Inimigo")
        {
            GameObject obj = Instantiate(prefabTiro, this.transform.position, Quaternion.identity);
            obj_ = obj;
            col_ = col;
            canAttack = false;
        }
    }

    void Mover(Collider2D col, GameObject obj)
    {
        // move na direção do target
        Vector3 moveDir = (col.transform.position - obj.transform.position).normalized;
        obj.transform.position += moveDir * movSpeed * Time.deltaTime;
        // rotaciona pro target
        float angle = Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg;
        obj.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
