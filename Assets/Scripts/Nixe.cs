using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nixe : MonoBehaviour
{

    public GameObject song;


    // Start is called before the first frame update
    void Start()
    {
        song.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            song.gameObject.SetActive(true);
        } else
        {
            song.gameObject.SetActive(false);
        }
    }
}
