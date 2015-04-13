using UnityEngine;
using System.Collections;

public class EntityBase : MonoBehaviour 
{
	//basic attributes
	protected int max_hp; //health point
	protected int cur_hp;
	protected int hp_recover_dur;
		
	protected int max_mp; //magic point
	protected int cur_mp;
	protected int mp_recover_dur;

	protected int cur_att; //attack
	protected int att_rand; 
	protected int att_range;

	protected int armor;	
	protected int armor_extra;	

	protected Animator animator;  
	
	//TIME LAPSE
	protected float MOVE_TIMELAPSE = 0.02f;
	protected float CHECK_RANGE_DUR = 0.5f;
	protected float ATT_TIMELAPSE;

	//state
	protected int state;
	protected int MOVE_STATE 	= 1;
	protected int CHASE_STATE = 2;
	protected int ATT_STATE 	= 3;
	protected int DEAD_STATE 	= 4;

	//UI
	protected HpBarUI hpbar_ui;
	protected MpBarUI mpbar_ui;

	public PlayerMovement player_motion;

	//side
	int side;
	
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

	protected bool CheckAttDistance(Vector3 tar)
	{
		return GetDistance(tar) <= att_range;
	}

	protected void DoMove()
	{
		//StartCoroutine(_DoMove());
	}

	protected void DoAttack(GameObject other)
	{
		//StartCoroutine(_DoAttack(other));
	}
	
	public int GetAtt()
	{
		return cur_att + Random.Range(-att_rand, att_rand);
	}
	
	public virtual void GetDamage(int damage)
	{
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

	public virtual int GetSide() 
	{
		return side;
	}

	protected virtual void OnCollisionEnter(Collision other) 
	{
		
	}
	
	protected virtual void OnCollisionExit(Collision other) 
	{
		
	}
	
	protected virtual bool IsEnemy(EntityBase other) 
	{
		return other.GetSide() != side ;
	}

	protected virtual int GetArmor() 
	{
		return armor + armor_extra;
	}

}


