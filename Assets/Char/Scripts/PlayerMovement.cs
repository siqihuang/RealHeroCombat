using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	private float speed = -6f;            // The speed that the player will move at.
	
	Vector3 movement;                   // The vector to store the direction of the player's movement.
	Animator animator; // Reference to the animator component.
	public Camera myCam;
	//audio
	public AudioClip att_sound;
	
	void Awake ()
	{
		animator = GetComponent <Animator> ();
		audio.Stop();
	}
	
	void FixedUpdate ()
	{
		//get the current state
		//AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
		
		//if we're in "Run" mode, respond to input for jump, and set the Jump parameter accordingly. 
		/*
		if(stateInfo.nameHash == Animator.StringToHash("Base Layer.idle"))
		{
			if(Input.GetButton("Fire1")) 
				animator.SetBool("Jump", true );
		}
		*/
		if(Input.GetButton("Jump"))
		{
			animator.SetBool ("is_jumping", true) ;
			return;
		}
		else
		{
			animator.SetBool ("is_jumping", false) ;
		}
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");
		bool to_move = (h != 0f || v != 0f);	
		if(to_move)
		{
			
			//movement.Set (h, 0f, v);
			//debug: horizontal view
			//movement.Set (v, 0f, h);

			//movement = Input.GetAxis("Vertical") * Camera.transform.forward + Input.GetAxis("Horizontal") * Camera.transform.right;
			movement = myCam.transform.forward * v * 0.3f + h * myCam.transform.right*0.2f;
			movement.y = 0;
			//movement = movement.normalized * speed * Time.deltaTime;
			Turning (movement);
		}
		Move (to_move);
	}


	void Move (bool need_walk)
	{
		//bool state = animator.GetBool("is_walking");
		if(need_walk) 
		{
			rigidbody.MovePosition (transform.position + movement);
			//audio.Play ();
		}
		else if(!need_walk)
		{
			//audio.Stop();
		}
		animator.SetBool ("is_walking", need_walk);
	}
	
	public void Turning (Vector3 rot)
	{
		Quaternion newRotation = Quaternion.LookRotation (rot);	
		newRotation =  Quaternion.Lerp(transform.rotation, newRotation,  0.5f);
		rigidbody.MoveRotation (newRotation);
	}
	
	public void EnterAttack(Vector3 tar_pos)
	{
		animator.SetBool ("is_attacking", true);
		transform.LookAt(tar_pos);
		AudioSource.PlayClipAtPoint(att_sound, transform.position);
	}
	
	public void ExitAttack()
	{
		animator.SetBool ("is_attacking", false);
	}
	
	
	public bool IsAttacking()
	{
		return animator.GetBool("is_attacking");
	}
}