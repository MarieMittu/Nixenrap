using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nixe : MonoBehaviour
{

    public GameObject song;
    public GameObject bgMusik;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        song.gameObject.SetActive(false);
        bgMusik.gameObject.SetActive(true);
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            bgMusik.gameObject.SetActive(false);
            song.gameObject.SetActive(true);
            animator.Play("Sing");
        } else
        {
            song.gameObject.SetActive(false);
            bgMusik.gameObject.SetActive(true);
            animator.Play("Idle");
        }
    }
}
