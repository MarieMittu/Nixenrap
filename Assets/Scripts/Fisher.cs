using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fisher : MonoBehaviour
{


    public float lureAmount;
    float secondTimer = 0f;
    public bool isLuring = false;
    float decreaseTimer = 0f;
    private AudioSyncer audioSyncer;
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        lureAmount = 0;
        audioSyncer = FindObjectOfType<AudioSyncer>();
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void AddLure(float plus)
    {
        lureAmount += plus;
        Debug.Log("LUREAMOUNT" + lureAmount);
    }

    public void DecreaseLure(float minus)
    {
        lureAmount -= minus;
        if (lureAmount <= 0)
            {
            lureAmount = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isLuring)
        {

            if (audioSyncer.beatCatch && Input.GetKeyDown(KeyCode.Return))
            {
                AddLure(0.6f);
            } else if (!audioSyncer.beatCatch && Input.GetKeyDown(KeyCode.Return))
            {
                DecreaseLure(0.6f);
            } else
            {
                Debug.Log("is being lured" + lureAmount);
                secondTimer = secondTimer + Time.deltaTime;
                if (secondTimer >= 1f)
                {
                    AddLure(0.2f);
                    secondTimer--;
                }
            }
            
        } else
        {
            secondTimer = 0f;
            decreaseTimer += Time.deltaTime;
            if (decreaseTimer >= 1f)
            {
                DecreaseLure(0.6f);
                decreaseTimer -= 1f;
            }
           

        }

        if (lureAmount <= 0)
        {
            lureAmount = 0;
        }

        if (lureAmount >= 2)
        {
            lureAmount = 2;

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
        DinnerManager.instance.AddDinner();
        Destroy(gameObject);

        
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("lure"))
        {
            isLuring = true;
            decreaseTimer = 0f;
            animator.Play("Lured");

        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("lure"))
        {
            isLuring = false;
            animator.Play("Idle");

        }

    }
}
