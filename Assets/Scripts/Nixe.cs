using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nixe : MonoBehaviour
{

    public GameObject song;
    public GameObject bgMusik;


    // Start is called before the first frame update
    void Start()
    {
        song.gameObject.SetActive(false);
        bgMusik.gameObject.SetActive(true);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            bgMusik.gameObject.SetActive(false);
            song.gameObject.SetActive(true);
        } else
        {
            song.gameObject.SetActive(false);
            bgMusik.gameObject.SetActive(true);
        }
    }
}
