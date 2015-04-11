using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MpBarUI : MonoBehaviour 
{

	Image pro;
	void Start()
	{
		pro = GetComponent<Image>()	;
	}

	public void UpdateMp(float ratio) 
	{
		pro.fillAmount = ratio;
	}
}
