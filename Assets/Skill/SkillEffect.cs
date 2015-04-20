using UnityEngine;
using System.Collections;

public class SkillEffect : MonoBehaviour 
{
	bool trigger = false;
	Vector3 move_step;
	float distance;
	int damage;

	void FixedUpdate () 
	{
		if(trigger)
		{
			rigidbody.MovePosition (transform.position + move_step);
		}
	}

	public void TriggerActive(Vector3 st_pos, Vector3 _dir, float _move_speed, int _damage)
	{
		trigger = true	;	
		transform.position = st_pos;
		_dir = Vector3.Normalize(_dir);
		damage = _damage;
		move_step =  _dir * _move_speed *  Time.deltaTime;
	}

	void OnArriveDest()
	{
		trigger = false;
		Destroy(gameObject);
	}

	void OnCollisionEnter(Collision other) 
	{
		if(other.collider.CompareTag("Entity") || other.collider.CompareTag(""))
		{
			other.collider.gameObject.SendMessage("GetDamageWithAtt", damage, SendMessageOptions.DontRequireReceiver);
			OnArriveDest();
		}
	}
}
