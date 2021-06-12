using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public Animator walkingAnim;
    int movementSpeed = 20;
    public SpriteRenderer sr;
    public GameObject eAnimation;
    public SpriteRenderer whiteFade;
    bool triggered = false;
    void Start()
    {
        eAnimation.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)){
            sr.flipX = false;
            playerRb.AddForce(transform.right * -movementSpeed);
            walkingAnim.SetBool("moving", true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            sr.flipX = true;
            playerRb.AddForce(transform.right * movementSpeed);
            walkingAnim.SetBool("moving", true);
        }
        if(Input.GetKeyUp(KeyCode.A)||Input.GetKeyUp(KeyCode.D))
        {
            walkingAnim.SetBool("moving", false);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        eAnimation.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        eAnimation.SetActive(false);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.E)&&triggered == false){
            triggered = true;
            StartCoroutine(FadeToWhite());
        }
    }
    IEnumerator FadeToWhite()
    {
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            // set color with i as alpha
            whiteFade.color = new Color(1, 1, 1, i);
            yield return null;
        }
        yield return new WaitForSeconds(1);
        //SceneManager.LoadScene("Forest_Level");
        print("Loading Forest Level");
    }
}
