using UnityEngine;
using System.Collections;

public class BodyScript : MonoBehaviour {

    static Animator anim;
    static float speedWalk = 1.0F;
    static float speedRun = 3.0F;
    static float rotationSpeed = 100.0F;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        float translation= Input.GetAxis("Vertical") * speedWalk;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
     
        if (Input.GetButtonDown( "Jump" ))//прыжок 
        {
            anim.SetTrigger("isJumping");
        }

        if (Input.GetKeyDown(KeyCode.E))//dance 
        {
            anim.SetTrigger("isDancing");
        }
        
       
        
        //transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        if( (translation != 0))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetBool("isRunning", true);
                transform.Translate(0, 0, translation * speedRun);
            }
            else
            {
                transform.Translate(0, 0, translation);
                anim.SetBool("isWalking", true);
            }
            if(Input.GetKey(KeyCode.C))
            {
                anim.SetBool("isShiftRunning", true);
            }
        }
        else
        {
            anim.SetBool("isShiftRunning", false);
            anim.SetBool("isRunning", false);
            anim.SetBool("isWalking", false);
        }
        



	}
}
