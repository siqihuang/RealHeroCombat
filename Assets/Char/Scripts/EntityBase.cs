using UnityEngine;
using System.Collections;

public class EntityBase : MonoBehaviour 
{
	//=======define basic attributes=============

	protected int id;
	protected string name;

	//decide friend or enemy
	protected int side;
	
	//health point
	protected int max_hp; 
	protected int cur_hp;
	protected int recover_hp;

	//magic point
	protected int max_mp; 
	protected int cur_mp;
	protected int recover_mp;

	//attack
	protected int cur_att; 
	protected int att_rand; 
	protected int att_range;
	protected int extra_att;

	//speed
	protected int move_speed;
	protected int extra_move_speed;

	//armor
	protected int armor;	
	protected int extra_armor;	


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

	protected PlayerMovement player_motion;


	// Use this for initialization
	void Start () 
	{
		init ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	protected virtual void init() 
	{
		//initialize all attributes here
	}

	// Update is called once per  game logic turn
	protected virtual void UpdateByTurn() 
	{
		
	}

	protected void Awake ()
	{
		animator = GetComponent <Animator> ();
	}

	//=============position================
	protected float GetDistance(Vector3 tar)
	{
		return Vector3.Distance(transform.position, tar);
	}

	protected bool CheckAttDistance(Vector3 tar)
	{
		return GetDistance(tar) <= att_range;
	}

	public void DoMove()
	{
		//StartCoroutine(_DoMove());
	}

	public int  MoveSpeed
	{
		get{return move_speed + extra_move_speed;}
	}
	
	//=============position================

	//=============attack================
	public int  Att
	{
		get
		{
			return cur_att + Random.Range(-att_rand, att_rand) + extra_att;
		}
	}
	
	public int ExtraAtt
	{
		get
		{
			return extra_att;
		}
		set
		{
			if(value >= 0)
			{
				extra_att = value;
			}
		}
	}

	bool CanAttack(EntityBase other)
	{
		if(other.tag == "Enemy" && CheckAttDistance(other.transform.position))
		{
			EntityBase ins = other.gameObject.GetComponent<EntityBase>();
			if(ins)
			{
				return true;
			}
		}
		return false;
	}

	//attack other
	public void DoAttack(EntityBase other)
	{
		if(CanAttack(other)) 
		{
			player_motion.EnterAttack(other.transform.position);
			other.GetDamage(Att);
		
			//Vfx
		}
	}

	//attacked by other
	public void GetDamage(int damage)
	{
		cur_hp = Mathf.Max (0, cur_hp - damage);
		if(cur_hp <= 0)
		{
			OnDie();
		}	
	}

	//need to override
	public virtual void OnDie()
	{
		state = DEAD_STATE;
		Destroy(gameObject);
	}
	//==========attack================

	//=========side===============
	public int GetSide() 
	{
		return side;
	}
	
	public bool IsEnemy(EntityBase other) 
	{
		return other.GetSide() != side ;
	}
	//=========side===============

	//=========armor===============
	public int Armor
	{
		get{return armor + extra_armor;}
	}

	public int ExtraArmor
	{
		get{return armor + extra_armor;}
		set
		{
			if(value >= 0)
			{
				extra_armor = value;
			}
		}
	}
	//=========armor===============

	//=========mp===============
	public int  CurMp
	{
		get{return cur_mp;}
		set
		{
			if(value >= 0)
			{
				cur_mp = value;
			}
		}
	}

	public void AddMp(int val)
	{
		if(cur_mp >= max_mp || val <= 0)
		{
			return;
		}
		cur_mp = Mathf.Min (max_mp, cur_mp + val);
		RefreshMpUI();
	}

	public void SubMp(int val)
	{
		if(val <= 0)
		{
			return;
		}

		int new_mp = cur_mp - val	;
		if(new_mp < 0)
		{
			Debug.LogError("SubMp error! Mp negative!");
			new_mp = 0;
		}

		cur_mp = new_mp ;

		Debug.Log("[EntityBase][SubMp]: " + cur_mp.ToString());

		//refresh new_mp;
		RefreshMpUI();
	}
	//=========mp===============

	//=========hp===============
	public void AddHp(int val)
	{
		if(cur_hp >= max_hp)
		{
			return ;
		}
		cur_hp = Mathf.Min (max_hp, cur_hp + val);
		RefreshHpUI();
	}

	//=========hp===============
	
	//=================UI====================
	void RefreshHpUI()
	{
		float ratio = (float)cur_hp/(float)max_hp;
		//hpbar_ui.UpdateHp(ratio) ;
	}
	
	void RefreshMpUI()
	{
		float ratio = (float)cur_mp/(float)max_mp;
		//mpbar_ui.UpdateMp(ratio) ;
	}
	//=================UI====================
		
	//kill other
	public void OnKill()
	{
		
	}

	protected virtual void OnCollisionEnter(Collision other) 
	{
		
	}
	
	protected virtual void OnCollisionExit(Collision other) 
	{
		
	}
}

