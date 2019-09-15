using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GameObject.Find("MobileMaleFree1").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void jump()
    {
        animator.SetBool("IsJumping",true);
        StartCoroutine(Example());
    }

    public void walk()
    {
        animator.SetBool("IsWalking", true);
        StartCoroutine(Example());
    }

    public void run()
    {
        animator.SetBool("IsRunning", true);
        StartCoroutine(Example());
    }

    IEnumerator Example()
    {
        print(Time.time);
        yield return new WaitForSeconds(1);
        animator.SetBool("IsJumping", false);
        animator.SetBool("IsWalking", false);
        animator.SetBool("IsRunning", false);
        print(Time.time);
    }
}
