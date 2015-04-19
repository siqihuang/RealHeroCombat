using UnityEngine;
using System.Collections;

//Skill description:
//name: HEAL 
//effect: heal player's hp 

public class Skill_3 : SkillBase
{
	// Use this for initialization
	private int add_hp;
	GameObject obj;

	protected override void init() 
	{
		id = 3;
		name = "HEAL";
		cur_cd = 0;
		need_mp = 10;
		max_cd = 0;
		cur_cd = 0;
		need_mp = 10;

		add_hp = 30;
		vfx_name = "HealVfx";
		Debug.Log("[SKILL][init]: " + name);
	}
	
	// Update is called once per frame
	void Update () 
	{
		/*
		if(obj)
		{
			obj.transform.position = p.transform.position;
		}
		*/
	}

	protected override void DoEffect(HeroBase hero)
	{
		base.DoEffect(hero);
		//Vector3 position = p.transform.position;
		//p.AttackOnce(position);
		//p.AddHp(add_hp);
		//obj = Instantiate(Resources.Load(vfx_name), position+new Vector3(0.0f, 0.5f, 0.0f), Quaternion.identity) as GameObject;
	}
}
