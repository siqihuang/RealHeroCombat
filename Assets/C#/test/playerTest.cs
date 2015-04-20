using UnityEngine;
using System.Collections;
using Vuforia;

public class playerTest : MonoBehaviour{
	public int speed;
	public GameObject battleField;
	public int state,pos,target;
	public float moveSpeed;
	public Hero_1 hero;
	public PlayerMovement playerMovement;
	// Use this for initialization
	void Start () {
		state = -1;
		target = 0;
		pos = 0;
		speed = 5;	
		moveSpeed = 5f;
		battleField = GameObject.Find ("battleField");
		gameObject.transform.Rotate (0, 90, 0);

		hero = this.GetComponent<Hero_1> ();
		playerMovement = hero.GetComponent<PlayerMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (state == 0) {
			highlightCube();
			state=1;
		}
		else if(state==2){
			resetCube();
			state=3;
			playerMovement.TestMove(true);
			//start walking
		}
		else if(state==3){
			moveToCube();
		}
		else if(state==4){
			Vector3 targetPos=new Vector3(target%12-5.5f,0,-target/12+3.5f);
			gameObject.transform.position=targetPos;
			pos=target;

			playerMovement.TestMove(false);
			//stop walking

			Vector3 dv=new Vector3(1,0,0);
			gameObject.transform.LookAt(gameObject.transform.position+dv);
			//turn back
			state=-1;
		}
	}

	void highlightCube(){
		int x, z,tx,tz;
		x = pos % 12;
		z = pos / 12;
		for (int i=0; i<96; i++) {
			tx=i%12;
			tz=i/12;
			if(Mathf.Abs(tx-x)+Mathf.Abs(tz-z)<=speed){
				string name="Cube"+i.ToString();
				GameObject child=GameObject.Find(name);
				colorTest color=child.GetComponent<colorTest>();
				color.changeColor(1);
				color.state=1;
			}
		}
	}

	void resetCube(){
		for (int i=0; i<96; i++) {
			string name="Cube"+i.ToString();
			GameObject child=GameObject.Find(name);
			colorTest color=child.GetComponent<colorTest>();
			color.changeColor(0);
			color.state=0;
		}
	}

	void moveToCube(){
		int newX, newZ;
		float oldX, oldZ, dx, dz;
		Vector3 newPos=gameObject.transform.position;
		newX = target % 12-6;
		newZ = -target / 12+4;
		oldX = gameObject.transform.position.x;
		oldZ = gameObject.transform.position.z;
		dx = newX - oldX;
		dz = newZ - oldZ;
		if (Mathf.Abs (dx) > 0.1f) {//still not arrive
			if (dx >= 0) {
				//gameObject.rigidbody.rotation=Quaternion.Euler(0,90,0);
				Vector3 dv=new Vector3(1,0,0);
				gameObject.transform.LookAt(gameObject.transform.position+dv);
				newPos.x+=moveSpeed*Time.deltaTime;
				gameObject.transform.position=newPos;
			}
			else{//dx<0
				//gameObject.rigidbody.rotation=Quaternion.Euler(0,270,0);
				//gameObject.transform.Rotate(0,180,0);//turn around
				Vector3 dv=new Vector3(-1,0,0);
				gameObject.transform.LookAt(gameObject.transform.position+dv);
				newPos.x-=moveSpeed*Time.deltaTime;
				gameObject.transform.position=newPos;
			}
		}
		else if(Mathf.Abs(dz)>0.1f) {
			if (dz >= 0) {
				Vector3 dv=new Vector3(0,0,1);
				gameObject.transform.LookAt(gameObject.transform.position+dv);
				newPos.z+=moveSpeed*Time.deltaTime;
				gameObject.transform.position=newPos;
			}
			else{//dz<0
				//gameObject.rigidbody.rotation=Quaternion.Euler(0,180,0);
				//gameObject.transform.Rotate(0,180,0);//turn around
				Vector3 dv=new Vector3(0,0,-1);
				gameObject.transform.LookAt(gameObject.transform.position+dv);
				newPos.z-=moveSpeed*Time.deltaTime;
				gameObject.transform.position=newPos;
			}
		}
		else{
			state=4;
		}
	}
}
