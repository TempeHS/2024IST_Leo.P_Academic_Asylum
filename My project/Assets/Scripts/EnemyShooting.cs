using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject book;
    public Transform bookPos;

    private float timer; 
    private GameObject player;

    public float shootDelay;
    public int range;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector2.Distance(transform.position, player.transform.position);
        
        if(distance < range)
        {
            timer += Time.deltaTime;

            if(timer > shootDelay)
            {
                timer = 0;
                shoot();
            }
        }
    }

    void shoot()
    {
        Instantiate(book, bookPos.position, Quaternion.identity);
    }
}
