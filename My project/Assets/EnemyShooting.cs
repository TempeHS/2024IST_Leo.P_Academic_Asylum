using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject book;
    public Transform bookPos;

    private float timer; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 2)
        {
            timer = 0;
            shoot();
        }
    }

    void shoot()
    {
        Instantiate(book, bookPos.position, Quaternion.identity);
    }
}
