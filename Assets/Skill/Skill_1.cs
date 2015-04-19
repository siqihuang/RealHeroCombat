using UnityEngine;
using System.Collections;

//Skill description:
//name:  
//effect:

public class Skill_1 : SkillBase
{
	/*
	public Skill_1()
	{
		init();
	}
	*/


	protected override void init()
	{
		//each child should have its own initialization
		id = 0;
		test_name = "xixue guanghuan";
		name = "xixue guanghuan";

		need_mp = 0;

		max_cd = 0;
		cur_cd = 0;

		vfx_name = "SkillFireVfx";

		Debug.Log("[SKILL][init]: " + name);
	}

	protected override void DoEffect(HeroBase hero)
	{
		base.DoEffect(hero);

		//absorb hp
		int add_hp = (int)(hero.Att * 0.1f);
		hero.AddHp(add_hp);
		//Instantiate(vfx, hero.transform.position, Quaternion.identity);
	}
}
