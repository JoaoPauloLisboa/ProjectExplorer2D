using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    Rigidbody2D rbody;
	public static Animator anim;
    public static Vector2 movement_vector;
    public static bool froze = false;
	AudioSource source;
    //float oldPositionX = 0;
    //float oldPositionY = 0;

    // Use this for initialization
    void Awake() {
		source = GetComponent<AudioSource>();
	}
	void Start ()
    {
		rbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	void StartSound() {
		if(!source.isPlaying) {
			source.Play();
		}
	}

	void PauseSound() {
		if(source.isPlaying) {
			source.Stop();
		}
	}

    // Update is called once per frame
    void Update()
    {
    
       movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
#if UNITY_ENGINE || UNITY_STANDALONE || UNITY_WEBPLAYER
        if (movement_vector != Vector2.zero)
        {
			StartSound();
            anim.SetBool("iswalking", true);
            anim.SetFloat("input_x", movement_vector.x);
            anim.SetFloat("input_y", movement_vector.y);
            Debug.Log("xis " + movement_vector.x);
            Debug.Log("ipslon " + movement_vector.y);
        }
        else
        {
            anim.SetBool("iswalking", false);
			PauseSound();
        }
		//ControlaSom(){
//}
        rbody.MovePosition(rbody.position + movement_vector * Time.deltaTime);
#else
        if (Input.touchCount > 0 && Input.touchCount < 2 )
        {
            Touch touch = Input.GetTouch(0); // reconhece o primeiro touch

            if ((touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) && froze == false )
            {
                StartSound();
                
                // touchposition para pixels do cel
                Vector2 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                anim.SetBool("iswalking", true);
                

                /*
                if ((touchedPos.x > oldPositionX && touchedPos.y > oldPositionY) || (touchedPos.x < oldPositionX && touchedPos.y > oldPositionY))
                {
                    oldPositionX = touchedPos.x;
                    oldPositionY = touchedPos.y;
                    touchedPos.x = 0;
                    touchedPos.y = 1;

                }

                else if ((touchedPos.x > oldPositionX && touchedPos.y < oldPositionY) || (touchedPos.x < oldPositionX && touchedPos.y < oldPositionY))
                {
                    oldPositionX = touchedPos.x;
                    oldPositionY = touchedPos.y;
                    touchedPos.x = 0;
                    touchedPos.y = -1;

                }
                else if ((touchedPos.x < oldPositionX && touchedPos.y < oldPositionY) || (touchedPos.x < oldPositionX && touchedPos.y > oldPositionY))
                {
                    oldPositionX = touchedPos.x;
                    oldPositionY = touchedPos.y;
                    touchedPos.x = -1;
                    touchedPos.y = 0;

                }
                else if ((touchedPos.x > oldPositionX && touchedPos.y < oldPositionY) || (touchedPos.x > oldPositionX && touchedPos.y > oldPositionY))
                {
                    oldPositionX = touchedPos.x;
                    oldPositionY = touchedPos.y;
                    touchedPos.x = 1;
                    touchedPos.y = 0;

                }
                */
                anim.SetFloat("input_x", touchedPos.x);
                anim.SetFloat("input_y", touchedPos.y);
                // set a posicao do objeto para a do touch ao longo do tempo
                transform.position = Vector3.Lerp(transform.position, touchedPos, Time.deltaTime);

                Debug.Log("xis " + touchedPos.x);
                Debug.Log("ipslon " + touchedPos.y);

            }
            else
            {
                anim.SetBool("iswalking", false);
                PauseSound();
            }
        }
#endif
    }

}
