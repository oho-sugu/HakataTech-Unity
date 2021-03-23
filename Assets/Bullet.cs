using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1f;

    private float timelimit = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var position = gameObject.transform.position;
        position += gameObject.transform.forward * speed * Time.deltaTime;
        gameObject.transform.position = position;

        timelimit -= Time.deltaTime;
        if(timelimit < 0f) {
            Destroy(gameObject);
        }
    }
}
