using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject boom;

    [SerializeField]
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag.Equals("Bullet")){
            Debug.Log("衝突したよ");
            gameManager.AddScore(100);
            Instantiate(boom, gameObject.transform.position, Quaternion.identity, null);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
