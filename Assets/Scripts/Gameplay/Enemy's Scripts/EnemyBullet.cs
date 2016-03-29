using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour 
{
	public GameObject GameAdmin;
	public Vector3 Target;
	public int MyBulletVel;
	public float MyPercentHit, MyPercentage;

	// Use this for initialization
	void Start () 
	{
		GameAdmin = GameObject.Find ("GameAdmin");
		Getting_Data ();
		MyPercentage = Random.value;

		if(MyPercentage > MyPercentHit)
		{Target = GameAdmin.GetComponent<EnemyAdm>().Targets[Random.Range(0, GameAdmin.GetComponent<EnemyAdm>().Targets.Count)].transform.position;}
		else{Target = new Vector3(Random.Range(-20,20), Random.Range(-20,20), 0);}
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.gameObject.GetComponent<Rigidbody2D> ().velocity = Vector2.MoveTowards (gameObject.transform.position, Target, -this.MyBulletVel * Time.deltaTime);

		if(this.gameObject.transform.position == Target)
		{
			Debug.Log ("I Hit the Target");
			Destroy(this.gameObject);
		}else if(this.gameObject.transform.position.x >= 40 || this.gameObject.transform.position.x <= -40 || this.gameObject.transform.position.y >= 20 || this.gameObject.transform.position.y <= -20)
		{
			Debug.Log ("I out of screen");
			Destroy(this.gameObject);
		}
	}

	void Getting_Data()
	{
		switch(this.gameObject.name)
		{
			case "Aircraft01Bullet":
			this.MyBulletVel = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[1,0];
			this.MyPercentHit = GameAdmin.GetComponent<HumanAircraftAttributes>().PercenteHit[0];
			break;
			case "Aircraft02Bullet":
			this.MyBulletVel = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[1,1];
			this.MyPercentHit = GameAdmin.GetComponent<HumanAircraftAttributes>().PercenteHit[1];
			break;
			case "Aircraft03Bullet":
			this.MyBulletVel = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[1,2];
			this.MyPercentHit = GameAdmin.GetComponent<HumanAircraftAttributes>().PercenteHit[2];
			break;
			case "Aircraft04Bullet":
			this.MyBulletVel = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[1,3];
			this.MyPercentHit = GameAdmin.GetComponent<HumanAircraftAttributes>().PercenteHit[3];
			break;
			case "VTOLBossBullet":
			this.MyBulletVel = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[1,4];
			this.MyPercentHit = GameAdmin.GetComponent<HumanAircraftAttributes>().PercenteHit[4];
			break;
		}
	}
}
