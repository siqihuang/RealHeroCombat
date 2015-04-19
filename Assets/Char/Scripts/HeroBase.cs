using UnityEngine;
using System.Collections;

public class HeroBase : EntityBase
{
	protected SkillBase [] skill_list;

	protected override void init() 
	{
		//initialize all attributes here
	}

	// Update is called once per  game logic turn
	protected override void UpdateByTurn() 
	{
		RecoverHp ()	;
		RecoverMp ()	;
		UpdateSkill();
	}
	
	public void RecoverHp()
	{
		AddHp (recover_hp);
	}

	public void RecoverMp()
	{
		AddMp (recover_mp);
	}
	//=================Skill==================
	protected virtual void InitSkill()
	{
		
	}

	bool CanUse(SkillBase skill)
	{
		if(! skill.CheckCD())
		{
			Debug.Log("Can not use skill, cold down now!" + skill.Name);
			return false;
		}

		if(cur_mp < skill.NeedMp)
		{
			Debug.Log("Can not use skill, not enough mp!" + skill.Name);
			return false;
		}

		return true;
	}

	public void UseSkill(SkillBase skill)
	{
		if (!CanUse(skill))
		{
			return;
		}
		SubMp(skill.NeedMp);
		skill.AfterEffect(this);
	}

	//By turn
	public void UpdateSkill()
	{
		for(int i = 0; i < skill_list.Length; ++i)
		{
			skill_list[i].UpdateByTurn();
		}
	}
}
