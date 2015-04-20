using UnityEngine;
using System.Collections;

public class GameCtrl : MonoBehaviour 
{
	private int unit_num;
	public EntityBase unit_1;
	public EntityBase unit_2;
	public EntityBase unit_3;
	public EntityBase unit_4;
	public EntityBase unit_5;
	public EntityBase unit_6;

	public EntityBase[] unit_list;

	// Use this for initialization
	void Start () 
	{
		unit_num = 6;

		Instantiate(unit_1, new Vector3(10.0f, 0.0f, 0.0f), Quaternion.identity);
		Instantiate(unit_2, new Vector3(20.0f, 0.0f, 0.0f), Quaternion.identity);
		Instantiate(unit_3, new Vector3(30.0f, 0.0f, 0.0f), Quaternion.identity);
		Instantiate(unit_4, new Vector3(40.0f, 0.0f, 0.0f), Quaternion.identity);
		Instantiate(unit_5, new Vector3(50.0f, 0.0f, 0.0f), Quaternion.identity);
		Instantiate(unit_6, new Vector3(60.0f, 0.0f, 0.0f), Quaternion.identity);


		unit_list = new HeroBase[unit_num];
		/*
		for(int i = 0; i < unit_num; ++i)
		{
			//Instantiate(unit_list[i], new Vector3(10.0f * i, 0.0f, 0.0f), Quaternion.identity);
			unit_list[i] = unit_1;
		}
		*/
		unit_list[0] = unit_1;
		unit_list[1] = unit_2;
		unit_list[2] = unit_3;
		unit_list[3] = unit_4;
		unit_list[4] = unit_5;
		unit_list[5] = unit_6;

		Debug.Log("Gamectrl init finished!");
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
