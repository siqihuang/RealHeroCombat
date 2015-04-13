using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	private float speed = -6f;            // The speed that the player will move at.
	
	Vector3 movement;                   // The vector to store the direction of the player's movement.
	Animator animator; // Reference to the animator component.
	public Camera myCam;

	//audio
	//public AudioClip att_sound;
	
	void Awake ()
	{
		animator = GetComponent <Animator> ();
		audio.Stop();
	}
	
	void FixedUpdate ()
	{
		/*
		float v = Input.GetAxisRaw ("Vertical");
		if(v != 0f)
		{
			animator.SetBool ("is_attacking",  v == 0f);
		}
		*/
	}

	public void Move (bool need_walk)
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

	public IEnumerator AttackOnce(Vector3 tar_pos)
	{
		EnterAttack(tar_pos);
		yield return new WaitForSeconds(1);
		ExitAttack();
	}
	
	public void EnterAttack(Vector3 tar_pos)
	{
		animator.SetBool ("is_attacking", true);
		transform.LookAt(tar_pos);
		//AudioSource.PlayClipAtPoint(att_sound, transform.position);
	}
	
	public void ExitAttack()
	{
		animator.SetBool ("is_attacking", false);
	}
	
	public bool IsAttacking()
	{
		return animator.GetBool("is_attacking");
	}

	public void TestAttack()
	{
		StartCoroutine(AttackOnce(transform.position));
	}

	public void TestMove(bool flag)
	{
		Move(flag);
	}
}