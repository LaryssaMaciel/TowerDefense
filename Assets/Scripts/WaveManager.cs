using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    
    public GameObject[] prefabs; // tipos de inimigos
    public Transform[] spawn;
    public int numWave = 0;
    public bool ended;
    public float timer = .5f, ctimer = 0;
    bool canSpawn;

    void Update()
    {
        
        if (ctimer <= 0)
        {
            ctimer = timer;
            canSpawn = true;
        }
        else
        {   
            ctimer -= Time.deltaTime;
            canSpawn = false;
        }

        switch(numWave)
        {
            case 0:
                StartCoroutine(Spawn(prefabs[0], 3, spawn[0], "target", "c0"));
                break;
            case 1:
                StartCoroutine(Spawn(prefabs[0], 3, spawn[1], "target1", "c1"));
                break;
            case 2:
                StartCoroutine(Spawn(prefabs[0], 3, spawn[0], "target", "c0"));
                break;
            case 3:
                break;
        }
    }

    IEnumerator Spawn(GameObject prefab, int qtd, Transform pontoSpawn, string rotaTarget, string caminhoNome)
    {
        if (canSpawn)
        {
            for (int i = 0; i < qtd; i++)
            {
                GameObject obj = Instantiate(prefab, pontoSpawn.transform.position, Quaternion.identity);
                obj.GetComponent<Inimigo>().caminhoTag = caminhoNome;
                obj.GetComponent<Inimigo>().tagTarget = rotaTarget;
                yield return new WaitForSeconds(1f);
            }
            numWave++;
        }
        
        canSpawn = false;
        yield break;
        
    }
}
