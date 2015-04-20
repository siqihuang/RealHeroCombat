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

	public GameObject vfx;

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
	
	protected override void DoEffect(HeroBase hero)
	{
		base.DoEffect(hero);

		Instantiate(vfx, hero.transform.position, Quaternion.identity) ;
		//Vector3 position = p.transform.position;
		//p.AttackOnce(position);
		//p.AddHp(add_hp);
		//obj = Instantiate(Resources.Load(vfx_name), position+new Vector3(0.0f, 0.5f, 0.0f), Quaternion.identity) as GameObject;
	}
}
