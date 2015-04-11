using UnityEngine;
using System.Collections;

public class EntityBase : MonoBehaviour 
{
	//basic attributes
	protected int max_hp; //health point
	protected int cur_hp;
	
	protected int max_level; //level
	protected int cur_level; //level
	
	protected int cur_att; //attack
	protected int att_range;
	
	
	protected Animator animator;  
	
	//TIME LAPSE
	protected float MOVE_TIMELAPSE = 0.02f;
	protected float CHECK_RANGE_DUR = 0.5f;
	protected float ATT_TIMELAPSE;
	
	//move
	protected float move_speed;
	protected Vector3 move_tar;
	protected Vector3 move_step;
	protected int chase_range;
	
	
	protected GameObject enemy_tar;
	
	//state
	protected int state;
	protected int MOVE_STATE 	= 1;
	protected int CHASE_STATE = 2;
	protected int ATT_STATE 	= 3;
	protected int DEAD_STATE 	= 4;
	
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	protected void Awake ()
	{
		animator = GetComponent <Animator> ();
	}
	
	protected float GetDistance(Vector3 tar)
	{
		return Vector3.Distance(transform.position, tar);
	}
	
	protected bool CheckChasingDistance(Vector3 tar)
	{
		return GetDistance(tar) <= chase_range;
	}
	
	protected bool CheckAttDistance(Vector3 tar)
	{
		/*
		float col_size = 0;
		if(col.GetType() == typeof(CapsuleCollider))
		{
			CapsuleCollider tmp = col;
			col_size = tmp.radius;
		}
		else if (col.GetType() == typeof(BoxCollider))
		{
			BoxCollider tmp = col;
			col_size = Mathf.Max(tmp.size.x, tmp.size.z);
		}
		return GetDistance(col.transform.position) - col_size <= att_range;
		*/
		return GetDistance(tar) <= att_range;
	}
	
	protected virtual IEnumerator _DoMove()
	{
		yield break;
	}
	
	protected void DoMove()
	{
		StartCoroutine(_DoMove());
	}
	
	protected virtual IEnumerator _DoAttack(GameObject other)
	{
		yield break;
	}
	
	protected void DoAttack(GameObject other)
	{
		StartCoroutine(_DoAttack(other));
	}
	
	public int GetAtt()
	{
		return cur_att;
	}
	
	public int GetLevel()
	{
		return cur_level;
	}
	
	protected virtual void GetDamageWithAtt(int damage)
	{
		cur_hp = Mathf.Max (0, cur_hp - damage);
		if(cur_hp <= 0)
		{
			OnDie();
		}	
	}
	
	protected virtual void GetDamage(EntityBase tar)
	{
		int damage = tar.GetAtt();
		cur_hp = Mathf.Max (0, cur_hp - damage);
		if(cur_hp <= 0)
		{
			OnDie();
		}	
	}
	
	protected virtual void OnDie()
	{
		state = DEAD_STATE;
		Destroy(gameObject);
	}
	
	protected virtual void OnCollisionEnter(Collision other) 
	{
		
	}
	
	protected virtual void OnCollisionExit(Collision other) 
	{
		
	}
	
	protected virtual bool IsEnemy(GameObject other) 
	{
		return false;
	}
}


