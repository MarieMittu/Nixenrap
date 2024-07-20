using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lurebar : MonoBehaviour
{

    public Fisher fisher;

    Vector3 localScale;

    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;   
    }

    // Update is called once per frame
    void Update()
    {
        if (fisher != null)
        {
            localScale.x = fisher.lureAmount;
            transform.localScale = localScale;
        }
        
        


    }
}
