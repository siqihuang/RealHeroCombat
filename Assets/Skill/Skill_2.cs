using UnityEngine;
using System.Collections;

//Skill description:
//name: FIRE BALL
//effect: spawn a fire ball and hit enemies
public class Skill_2 : SkillBase
{
	float move_speed;
	int damage ;

	public GameObject vfx;
	public SkillEffect se;
	
	// Use this for initialization
	protected override void init()
	{
		id = 2;
		name = "FIRE BALL";

		max_cd = 0;
		cur_cd = 0;
		need_mp = 10;

		//debug
		//cold_down = 1;
		//need_mp = 1;

		vfx_name = "Skill_2";
		move_speed = 3;
		damage = 100;

		Debug.Log("[SKILL][init]: " + name);
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	protected override void DoEffect(HeroBase hero)
	{
		base.DoEffect(hero);

		Vector3  st_pos = hero.transform.position;
		//st_pos.y += 2;
		//Instantiate(Resources.Load("Skill_2"), st_pos, hero.transform.rotation);
		vfx = Instantiate(vfx, st_pos, Quaternion.identity) as GameObject;

		SkillEffect ball = Instantiate(se, st_pos, Quaternion.identity) as SkillEffect;
		ball.TriggerActive(st_pos, hero.transform.forward,  move_speed, damage, vfx);
	}
}
