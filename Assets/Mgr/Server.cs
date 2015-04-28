using UnityEngine;
using System.Collections;

public class Server : MonoBehaviour 
{
	private int unit_num;
	public EntityBase unit_1;
	public EntityBase unit_2;
	public EntityBase unit_3;
	public EntityBase unit_4;
	public EntityBase unit_5;
	public EntityBase unit_6;

	public EntityBase[] unit_list;

	private bool started;
	private int next_index;

	private static int SortBySpeed(EntityBase a, EntityBase b)
	{
		return a.MoveSpeed - b.MoveSpeed;
	}
	
	// Use this for initialization
	void Start () 
	{
		started = false	;
		next_index = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void UpdateServer()
	{
		ResortAllEntity();
		NextEntity();
	}

	//take turn
	void NextEntity()
	{
		EntityBase next_entity = unit_list[next_index];
		//todo RPC
	}

	void ResortAllEntity()
	{
		//unit_list.Sort(SortBySpeed); 
		next_index = 0;
	}

	//============RPC function Receive=================
	void  RecvMove()
	{

	}

	void  RecvDefend()
	{

	}

	void  RecvAttack()
	{

	}

	void  RecvWait()
	{

	}

	void RecvReady()
	{

	}

	void RecvUseSkill()
	{

	}
	//============RPC function Receive=================

	//============RPC function Send=================
	/*
	void SendEntityMove()
	{

	}
	*/
	//============RPC function Send=================
}
