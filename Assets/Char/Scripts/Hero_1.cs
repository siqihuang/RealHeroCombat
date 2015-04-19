using UnityEngine;
using System.Collections;

public class Hero_1:  HeroBase
{
	private int max_exp; 
	private int cur_exp; 
	
	private int max_level; //level
	private int cur_level; 

	protected override void init() 
	{
		//initialize all attributes here
		max_level = 11;
		cur_level = 1;
		
		max_exp = 1000;
		cur_exp = 0;
		
		max_hp = (cur_level * 100) + 25;
		cur_hp = max_hp;
		recover_hp = 10;
		
		max_mp = (cur_level * 20) + 125;
		cur_mp = max_mp;
		recover_mp = 5;
		
		armor = (cur_level * 2);
		cur_att  = (cur_level) * 20;
		att_range =  4;

		//hpbar_ui = GameObject.Find("HpBarUI").GetComponent<HpBarUI>(); 
		//mpbar_ui = GameObject.Find("MpBarUI").GetComponent<MpBarUI>(); 
		
		player_motion = gameObject.GetComponent<PlayerMovement>();
		InitSkill ();
	}

	protected override void InitSkill()
	{
		/*
		Skill_1 skill_1 = Instantiate(skill_1) as Skill_1;
		Skill_2 skill_2 = Instantiate(skill_2) as Skill_2;
		Skill_3 skill_3 = Instantiate(skill_3) as Skill_3;
		*/

		Skill_1 skill_1 = new Skill_1();
		Skill_2 skill_2 = new Skill_2();
		Skill_3  skill_3 = new Skill_3();

		skill_list = new SkillBase[3];
		skill_list[0] =skill_1;
		skill_list[1] =skill_2;
		skill_list[2] =skill_3;
	}
}
