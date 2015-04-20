using UnityEngine;
using System.Collections;

public class BuffBase
{
	protected int id ;
	protected string name;

	protected bool has_triggered;
	protected int trigger_turn; //wait n turns to trigger

	protected int max_last_turn; //buff will last for n turns
	protected int cur_last_turn; //already last for n turns

	protected string buff_name;

	protected virtual void init()
	{
		//each child should have its own initialization
		id = 0;
		name = "TEST BUFF";
		has_triggered = false;
		trigger_turn = 2;

		max_last_turn = 3;
		cur_last_turn = 0;
	}

	protected void UpdateTrigger()
	{
		if(!has_triggered)
		{
			if(trigger_turn == 0)
			{
				has_triggered = true;
				DoTrigger();
			}
			else
			{
				trigger_turn--;
			}
		}
		else
		{
			cur_last_turn ++	;
			if(cur_last_turn >= max_last_turn)
			{
				cur_last_turn = 0;
				has_triggered = false;
			}
		}
	}

	protected virtual void DoTrigger()
	{

	}

	protected virtual void UpdateByTurn()
	{
		UpdateTrigger();
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
}
