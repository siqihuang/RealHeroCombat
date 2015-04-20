using UnityEngine;
using System.Collections;

public class HeroBase : EntityBase
{
	protected int max_exp; 
	protected int cur_exp; 
	
	protected int max_level; //level
	protected int cur_level; 

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

	public SkillBase GetSkillByIndex(int index)
	{
		if(index > skill_list.Length)
		{
			Debug.LogError("[GetSkillById] index is too big!" + index.ToString());
			return null;
		}
		return skill_list[index - 1];
		/*
		for(int i = 0; i < skill_list.Length; ++i)		
		{
			if(skill_list[i].Id == id)
			{
				return skill_list[i];
			}
		}
		return null;
		*/
	}

	public void UseSkill(int index)
	{
		SkillBase skill = GetSkillByIndex(index);
		if(skill == null) return;

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
