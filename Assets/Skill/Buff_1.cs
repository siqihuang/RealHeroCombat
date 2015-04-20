using UnityEngine;
using System.Collections;

//absorb halo
public class Buff_1 : BuffBase
{
	protected virtual void init()
	{
		//each child should have its own initialization
		id = 1;
		name = "TEST XIXUE";
		has_triggered = false;
		trigger_turn = 0;

		max_last_turn = 100000;
		cur_last_turn = 0;
	}

	protected override void DoTrigger()
	{
		//for all your friends in range, add the 	
	}

	protected override void UpdateByTurn()
	{
		UpdateTrigger();
	}
}
