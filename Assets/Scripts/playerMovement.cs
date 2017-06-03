using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
	Rigidbody2D rbody;
	public static Animator anim;
    public static Vector2 movement_vector;

    // Use this for initialization
    void Start ()
    {
		rbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

    // Update is called once per frame
    void Update()
    {
    
       movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
#if UNITY_ENGINE || UNITY_STANDALONE || UNITY_WEBPLAYER
        if (movement_vector != Vector2.zero)
        {
            anim.SetBool("iswalking", true);
            anim.SetFloat("input_x", movement_vector.x);
            anim.SetFloat("input_y", movement_vector.y);

        }
        else
        {
            anim.SetBool("iswalking", false);
        }
        rbody.MovePosition(rbody.position + movement_vector * Time.deltaTime);        
#else
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // reconhece o primeiro touch

            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                anim.SetBool("iswalking", true);
                // touchposition para pixels do cel
                Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                anim.SetFloat("input_x", touchedPos.x);
                anim.SetFloat("input_y", touchedPos.y);
                // set a posicao do objeto para a do touch ao longo do tempo
                transform.position = Vector3.Lerp(transform.position, touchedPos, Time.deltaTime);
            }
            else
            {
                anim.SetBool("iswalking", false);
            }
        }
#endif
    }
}
