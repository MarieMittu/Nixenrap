using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fisher : MonoBehaviour
{

    public static float lureAmount;
    float secondTimer = 0f;
    bool isLuring = false;

    // Start is called before the first frame update
    void Start()
    {
        lureAmount = 0;
    }

    public void AddLure()
    {
        lureAmount += 0.1f;
        Debug.Log("LUREAMOUNT" + lureAmount);
    }

    // Update is called once per frame
    void Update()
    {
        if (isLuring)
        {
            Debug.Log("is being lured" + lureAmount);
            secondTimer = secondTimer + Time.deltaTime;
            if (secondTimer >= 1f)
            {
                AddLure();
                secondTimer--;
            }
        } else
        {
            secondTimer = 0f;
        }
       

        if (lureAmount >= 1)
        {
            lureAmount = 1;

            StartCoroutine(JumpKillFisher());
           

        }
    }

    private IEnumerator JumpKillFisher()
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = startPos;
        endPos.y -= 1f;

        float duration = 0.2f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            transform.position = Vector3.Lerp(startPos, endPos, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = endPos;
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);

    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("lure"))
        {
            isLuring = true;

        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("lure"))
        {
            isLuring = false;

        }

    }
}
