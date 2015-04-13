using UnityEngine;
using System.Collections;

public class Hero_1:  EntityBase
{
	private int max_exp; 
	private int cur_exp; 
	
	private int max_level; //level
	private int cur_level; 
	

	//Vfx
	//public GameObject upgrade_vfx;
	//public GameObject blood_vfx;

	void Start () 
	{
		max_level = 11;
		cur_level = 1;
		
		max_exp = 1000;
		cur_exp = 0;
		
		max_hp = (cur_level * 100) + 25;
		cur_hp = max_hp;
		
		max_mp = (cur_level * 20) + 125;
		cur_mp = max_mp;
		
		armor = (cur_level * 2);
		cur_att  = (cur_level) * 20;
		att_range =  4;
		
	
		hp_recover_dur = 1;
		mp_recover_dur = 1;
		
		hpbar_ui = GameObject.Find("HpBarUI").GetComponent<HpBarUI>(); 
		mpbar_ui = GameObject.Find("MpBarUI").GetComponent<MpBarUI>(); 
		
		player_motion = gameObject.GetComponent<PlayerMovement>();
			
		RecoverHp();
		RecoverMp();
	}
	
	public int GetCurMp()
	{
		return cur_mp;
	}
	
	void AddMp(int val)
	{
		if(cur_mp >= max_mp)
		{
			return;
		}
		cur_mp = Mathf.Min (max_mp, cur_mp + val);
		RefreshMpUI();
	}
	
	public void AddHp(int val)
	{
		if(cur_hp >= max_hp)
		{
			return ;
		}
		cur_hp = Mathf.Min (max_hp, cur_hp + val);
		RefreshHpUI();
	}
	
	IEnumerator _RecoverHp()
	{
		while(true)
		{
			AddHp(1);
			yield return new WaitForSeconds(hp_recover_dur);
		}
	}
	
	void RecoverHp()
	{
		StartCoroutine(_RecoverHp());
	}
	
	IEnumerator _RecoverMp()
	{
		while(true)
		{
			AddMp(1);
			yield return new WaitForSeconds(mp_recover_dur);
		}
	}
	
	void RecoverMp() 
	{
		StartCoroutine(_RecoverMp());
	}
	
	public void SubMp(int val, string spell_name)
	{
		int new_mp = cur_mp - val	;
		if(new_mp < 0)
		{
			Debug.LogError("SubMp error! Mp negative!" + spell_name);
			new_mp = 0;
		}
		cur_mp = new_mp ;
		Debug.Log("SubMp !" + cur_mp.ToString());
		//refresh new_mp;
		RefreshMpUI();
	}
	
	protected float GetDistance(Vector3 tar)
	{
		return Vector3.Distance(transform.position, tar);
	}
	
	protected bool CheckAttDistance(Vector3 tar)
	{
		//print ("dis:" + GetDistance(tar).ToString());
		return GetDistance(tar) <= att_range;
	}

	void TryAttack(Collider other)
	{
		if(other.tag == "Enemy" && CheckAttDistance(other.transform.position))
		{
			EntityBase ins = other.gameObject.GetComponent<EntityBase>();
			if(ins)
			{
				DoAttack (ins);
			}
		}
	}
	

	void RefreshHpUI()
	{
		float ratio = (float)cur_hp/(float)max_hp;
		hpbar_ui.UpdateHp(ratio) ;
	}
	
	void RefreshMpUI()
	{
		float ratio = (float)cur_mp/(float)max_mp;
		mpbar_ui.UpdateMp(ratio) ;
	}
		
	public void DoAttack(EntityBase enemy)
	{
		//animation
		player_motion.EnterAttack(enemy.transform.position);
		enemy.GetDamage(GetAtt());
		//Vfx
		//Instantiate(blood_vfx, transform.position, Quaternion.identity);
	}
	

	public void OnKill(int mon_level, Vector3 position)
	{
		cur_exp = Mathf.Min(cur_exp + mon_level * 5, max_exp);
		//upgrade
		if(cur_exp % 100 == 0)
		{
			int next_lvl = cur_exp / 100;
			if(next_lvl > cur_level && next_lvl < max_level)
			{
				cur_level = next_lvl;
			}
			//VFX
			//Instantiate(upgrade_vfx, gameObject.transform.position, Quaternion.AngleAxis(-90, Vector3.right));
		}
		//VFX
		//Instantiate(upgrade_vfx, gameObject.transform.position, Quaternion.AngleAxis(-90, Vector3.right));
		//refresh UI
		//TODO
	}
	
	void OnDie()
	{
		Destroy(gameObject);
		Application.LoadLevel("LoseScene");
	}

}
