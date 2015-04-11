using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HpBarUI : MonoBehaviour {

	Color col;
	Image pro;

	void Start()
	{
		pro = GetComponent<Image>()	;
	}

	public void UpdateHp(float ratio) 
	{
		pro.fillAmount = ratio;
		if(ratio <= 0.2)
		{
			pro.color = Color.red;
		}
		else if(ratio > 0.2 && ratio < 0.7)
		{
			pro.color = Color.yellow;
		}
		else
		{
			pro.color = Color.green;
		}
	}
}
