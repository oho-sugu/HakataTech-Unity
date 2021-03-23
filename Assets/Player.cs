using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;

    private AudioSource bang;

    // Start is called before the first frame update
    void Start()
    {
        bang = GetComponent<AudioSource>();
        StartCoroutine(GetText());
    }

    // Update is called once per frame
    void Update()
    {
        var position = gameObject.transform.position;
        position += gameObject.transform.forward * Input.GetAxis("Vertical") * 0.2f;
        gameObject.transform.position = position;

        gameObject.transform.Rotate(0f, Input.GetAxis("Horizontal")*1.0f, 0f);

        if(Input.GetKeyDown(KeyCode.Space)){
            Instantiate(bullet, gameObject.transform.position, gameObject.transform.rotation, null);
            bang.Play();
        }
    }

    IEnumerator GetText(){
        UnityWebRequest req = UnityWebRequest.Get("https://oho-sugu.github.io/hakatademo/index.txt");
        yield return req.SendWebRequest();

        if(req.isNetworkError || req.isHttpError){
            Debug.Log(req.error);
        } else {
            Debug.Log(req.downloadHandler.text);
        }
    }
}
