using UnityEngine;
using System.Collections;

public class SkillBase
{
	protected int id;
	protected string test_name;
	protected string name;
	protected int need_mp;

	//cold down
	protected int max_cd; 
	protected int cur_cd; //current cold down 

	//protected int release_range;

	protected GameObject vfx;
	protected string vfx_name;

	protected  HeroBase hero;

	public SkillBase()
	{
		init ();
	}

	// Use this for initialization
	void Start() 
	{
		init ();
	}

	protected virtual void init()
	{
		//each child should have its own initialization
		id = 0;
		name = "TEST";
		need_mp = 50;

		max_cd = 5;
		cur_cd = 0;

		vfx_name = "SkillFireVfx";
		Debug.Log("[SKILL][init]: " + name);
	}

	public int Id
	{
		get
		{ 
			return id; 
		}
		private set 
		{ 
			id = value;
		}
	}

	public string Name
	{
		get
		{ 
			return name; 
		}
		private set 
		{ 
			name = value;
		}
	}

	public int NeedMp 
	{
		get
		{ 
			return need_mp; 
		}
		private set 
		{ 
			if(value >= 0)
			{
				need_mp = value;
			}
		}
	}
	
	public bool CheckCD()
	{
		return cur_cd <= 0;
	}

	public void AfterEffect(HeroBase hero)
	{
		BeginCD();
		DoEffect(hero);
	}

	protected virtual void DoEffect(HeroBase hero)
	{
		//each child re-write this function
		Debug.Log ("Skill DoEffect! " + name);
	}

	//===============cold down=================
	void BeginCD()
	{
		cur_cd = max_cd;
	}

	void UpdateCD()
	{
		if(cur_cd > 0)
		{
			cur_cd -=1;
		}
	}
	//===============cold down=================

	// Update is called once per frame
	void Update () 
	{
	
	}

	public virtual void UpdateByTurn()
	{
		UpdateCD();
	}
}
