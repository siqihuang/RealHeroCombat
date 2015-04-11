using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	//basic attributes
	private int max_hp; //health point
	private int cur_hp;
	private int hp_recover_dur;
	
	private int max_level; //level
	private int cur_level; 
	
	private int max_exp; //experience
	private int cur_exp; 
	
	private int armor;
	
	private int max_mp; //magic point
	private int cur_mp;
	private int mp_recover_dur;
	
	private int cur_att; //attack
	private int att_range; //attack

	//UI
	private HpBarUI hpbar_ui;
	private MpBarUI mpbar_ui;
	
	public PlayerMovement player_motion;
	
	//Vfx
	//public GameObject upgrade_vfx;
	//public GameObject blood_vfx;
	
	//Enemy
	private EntityBase attack_tar;
	private float ATT_TIMELAPSE;
	
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
		
		//move_speed = 0.03f;
		//rotate_speed = 0.1f;
		
		hp_recover_dur = 1;
		mp_recover_dur = 1;
		
		hpbar_ui = GameObject.Find("HpBarUI").GetComponent<HpBarUI>(); 
		mpbar_ui = GameObject.Find("MpBarUI").GetComponent<MpBarUI>(); 
		
		player_motion = gameObject.GetComponent<PlayerMovement>();

		ATT_TIMELAPSE = 0.5f;
		
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
	
	void FixedUpdate()
	{
		// Update the state machine here
		//UpdateStateMachine();
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
	
	void Update () 
	{
		//click object
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hitInfo = new RaycastHit();
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo))
			{
				TryAttack(hitInfo.collider);
			}
		}
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
	
	IEnumerator _DoChase(Collider other)
	{
		yield break;
	}
	
	void DoChase(Collider other)
	{
		StartCoroutine(_DoChase(other));
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
	
	public bool GetDamage(EntityBase tar)
	{
		int damage = tar.GetAtt();
		cur_hp = Mathf.Max(cur_hp - damage, 0);
		RefreshHpUI();
		if(cur_hp == 0)
		{
			OnDie();
		}
		if(attack_tar == null)
		{
			DoAttack(tar);
		}
		return true;
	}
	
	public IEnumerator _DoAttack(EntityBase enemy)
	{
		attack_tar = enemy;
		//animation
		player_motion.EnterAttack(enemy.transform.position);
		
		//cache: avoid the enemy is dead
		int enemy_level = enemy.GetLevel();
		Vector3 enemy_pos = enemy.transform.position;
		
		while(true)
		{
			if(! player_motion.IsAttacking())
			{
				attack_tar = null;
				yield break;
			}
			
			if(!enemy) //enemy target is dead
			{
				OnKillMonster(enemy_level, enemy_pos);
				player_motion.ExitAttack();
				attack_tar = null;
				yield break;
			}
			
			if(Vector3.Distance(transform.position, enemy_pos) > att_range) //out of attack range
			{
				attack_tar = null;
				player_motion.ExitAttack();
				yield break;
			}
			else //in attack range
			{
				enemy.SendMessage("GetDamageWithAtt", cur_att, SendMessageOptions.DontRequireReceiver);
				//Vfx
				//Instantiate(blood_vfx, transform.position, Quaternion.identity);
			}
			yield return new WaitForSeconds(ATT_TIMELAPSE); 
		}
	}
	
	public IEnumerator AttackOnce(Vector3 tar_pos)
	{
		player_motion.EnterAttack(tar_pos);
		yield return new WaitForSeconds(ATT_TIMELAPSE);
		player_motion.ExitAttack();
	}
	
	/*
	public void DoAttack(EntityBase tar)
	{
		StartCoroutine(_DoAttack(tar));
	}
	*/
	
	public void DoAttack(EntityBase tar)
	{
		if(tar!= attack_tar || !player_motion.IsAttacking())
		{
			StartCoroutine(_DoAttack(tar));
		}
	}
	
	public void OnKillMonster(int mon_level, Vector3 position)
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
