using UnityEngine;
using System.Collections;

//Skill description:
//name: FIRE BALL
//effect: spawn a fire ball and hit enemies
public class Skill_2 : SkillBase
{
	float move_speed;
	float move_distance;
	public SkillEffect fire_ball;
	int damage ;

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

		vfx_name = "SkillFireVfx";
		move_speed = 10;
		move_distance = 5;
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
		/*
		Vector3  st_pos = p.transform.position;
		st_pos.y += 2;
		Instantiate(Resources.Load(vfx_name), st_pos, p.transform.rotation);
		SkillEffect ball = Instantiate(fire_ball, st_pos, Quaternion.identity) as SkillEffect;
		ball.TriggerActive(st_pos, p.transform.forward,  move_speed, damage);
		*/
	}
}
