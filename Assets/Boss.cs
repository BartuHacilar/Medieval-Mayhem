using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public Animator animator;
    public GameObject Player;
    public bool flip;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        Vector3 scale = transform.localScale;

        if (Player.transform.position.x > transform.position.x)
        {

            scale.x = Mathf.Abs(scale.x) * -1 *(flip ? -1:1);
            transform.Translate(speed * Time.deltaTime, 0, 0);
            animator.SetTrigger("IsFollowing");
        }
        else {
            scale.x = Mathf.Abs(scale.x) * -1 * (flip ? -1:1);
            transform.Translate(speed * Time.deltaTime, 0, 0);
            animator.SetTrigger("IsFollowing");
        }

        transform.localScale = scale;


        
    }
}
