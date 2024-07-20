using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DinnerManager : MonoBehaviour
{

    public static DinnerManager instance;

    public Text dinnerText;

    public int dinner = 0;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        dinnerText.text = dinner.ToString();
    }

    public void AddDinner()
    {
        dinner++;
        dinnerText.text = dinner.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
