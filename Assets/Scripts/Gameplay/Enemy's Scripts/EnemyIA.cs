using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyIA : MonoBehaviour 
{
	public GameObject GameAdmin;

	public int MyDamage, MyCadence, MyBulletVel, MyMoveSpeed, MyDispersion, MyLife, MyDefense, MyYDelay, MyYIndex, MyScore;  
	public int XLimit, MyMoveCounter, StartMoveCounter; //XLimit - posiçao em X onde a nave ja tera saido da tela/MoveCounter+StartMoveCounter - Decremento que informa se a nave pode se mover.
	public float MyPercenteCadence, MyHitChance;
	public Transform MyShootPosition;
	public string OutOfScreen, SideOfScreen;

	void Start () 
	{
		GameAdmin = EnemyAdm.Instance.GameAdmin;

		this.MyYIndex = 1;

		Getting_Data ();

		this.StartMoveCounter = this.MyMoveCounter;

		PositionOnScreen ();
		if (this.SideOfScreen == "Right"){this.MyMoveSpeed *= -1;}
	}

	void Update () 
	{
		PositionOnScreen ();

		//Fazendo a naver ir e voltar na tela
		this.gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (this.MyMoveSpeed, 0);

		if(this.OutOfScreen == "OutOfScreen")
		{
			this.gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
			this.MyMoveCounter --;

			if(this.MyMoveCounter <= 0)
			{
				GameAdmin.GetComponent<HumanAircraftAttributes>().PleaseRandom = true;
				//Recalculate_Chances();

				this.MyYIndex += this.MyYDelay;
				this.gameObject.transform.position = new Vector3(gameObject.transform.position.x, HumanAircraftAttributes.Instance.YPositions[MyYIndex], gameObject.transform.position.z);
				this.MyMoveSpeed *= -1;
				this.gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (this.MyMoveSpeed, 0);
				this.MyMoveCounter = this.StartMoveCounter;
			}
		}
		//------------------------------------

		Shooting ();
	}

	void PositionOnScreen()//Void que testa se a nave esta dentro ou fora da tela, e se a posiçao dela e positiva ou negativa
	{
		if(this.gameObject.transform.position.x >= XLimit || this.gameObject.transform.position.x <= -XLimit)
		{
			this.OutOfScreen = "OutOfScreen";
		}else
		{
			this.OutOfScreen = "InScreen";
		}

		if(this.gameObject.transform.position.x > 0)
		{
			this.SideOfScreen = "Right";
		}else
		{
			this.SideOfScreen = "Left";
		}
	}

	void Shooting()
	{
		bool CanShoot = false;
		int AreaR, AreaL, AreaC, BattleArea;
		BattleArea = XLimit * 2;

		switch (MyCadence) {//Vendo quantas vezes eu irei atirar
		case 0:
			Debug.Log ("Don't Shoot");
			break;
		case 1:
			AreaC = Random.Range (-BattleArea / 2, BattleArea / 2);
			if (this.gameObject.transform.position.x == AreaC) {
				CanShoot = true;
			}
			break;
		case 2:
			AreaR = Random.Range (0, BattleArea / 2);
			AreaL = Random.Range (-BattleArea / 2, 0);
			if (this.gameObject.transform.position.x == AreaR || this.gameObject.transform.position.x == AreaL) {
				CanShoot = true;
			}
			break;
		case 3:
			AreaR = Random.Range (BattleArea / 3, 40);
			AreaC = Random.Range (-BattleArea / 3, BattleArea / 3);
			AreaL = Random.Range (-40, -BattleArea);
			if (this.gameObject.transform.position.x == AreaC || this.gameObject.transform.position.x == AreaR || this.gameObject.transform.position.x == AreaL) {
				CanShoot = true;
			}
			break;
		}

		if (CanShoot) {
			switch (MyDispersion) {//Estou vendo quantas balas eu devo atirar.
			case 1:
				GameObject Bullet1 = Instantiate (HumanAircraftAttributes.Instance.Bullets [0], this.MyShootPosition.position, Quaternion.identity) as GameObject;
				Bullet1.transform.SetParent (this.gameObject.transform);
				break;
			case 2:
				GameObject Bullet2 = Instantiate (HumanAircraftAttributes.Instance.Bullets [0], this.MyShootPosition.position, Quaternion.identity) as GameObject;
				GameObject Bullet3 = Instantiate (HumanAircraftAttributes.Instance.Bullets [0], this.MyShootPosition.position, Quaternion.identity) as GameObject;
				Bullet2.transform.SetParent (this.gameObject.transform);
				Bullet3.transform.SetParent (this.gameObject.transform);
				break;
			case 3:
				GameObject Bullet4 = Instantiate (HumanAircraftAttributes.Instance.Bullets [0], this.MyShootPosition.position, Quaternion.identity) as GameObject;
				GameObject Bullet5 = Instantiate (HumanAircraftAttributes.Instance.Bullets [0], this.MyShootPosition.position, Quaternion.identity) as GameObject;
				GameObject Bullet6 = Instantiate (HumanAircraftAttributes.Instance.Bullets [0], this.MyShootPosition.position, Quaternion.identity) as GameObject;
				Bullet4.transform.SetParent (this.gameObject.transform);
				Bullet5.transform.SetParent (this.gameObject.transform);
				Bullet6.transform.SetParent (this.gameObject.transform);
				break;
			}
			CanShoot = false;
		}
	}

	void Recalculate_Chances()
	{
		int Index = 0;
		switch(gameObject.name)
		{
		case "Aircraft01":
			Index = 0;
		break;
		case "Aircraft02":
			Index = 1;
		break;
		case "Aircraft03":
			Index = 2;
		break;
		case "Aircraft04":
			Index = 3;
		break;
		case "VTOLBoss":
			Index = 4;
		break;
		case "Cargo_Aircraft":
			Index = 5;
		break;
		case "Passenger_Aircraft":
			Index = 6;
		break;
		}

		this.MyCadence = GameAdmin.GetComponent<HumanAircraftAttributes>().Cadence [Index];
		this.MyDispersion = GameAdmin.GetComponent<HumanAircraftAttributes>().Dispersion_Rate [Index];
		this.MyDefense = GameAdmin.GetComponent<HumanAircraftAttributes>().Defense_Value [Index];
	}

	void Getting_Data()
	{
		int IndexY = 0;
		switch(gameObject.name)
		{
			case "Aircraft01":
			IndexY = 0;
			break;
			case "Aircraft02":
			IndexY = 1;
			break;
			case "Aircraft03":
			IndexY = 2;
			break;
			case "Aircraft04":
			IndexY = 3;
			break;
			case "VTOLBoss":
			IndexY = 4;
			break;
			case "Cargo_Aircraft":
			IndexY = 5;
			break;
			case "Passenger_Aircraft":
			IndexY = 6;
			break;
		}

		this.MyDamage = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[0,IndexY];
		this.MyBulletVel = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[1,IndexY];
		this.MyMoveSpeed = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[2,IndexY];
		this.MyLife = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[3,IndexY];
		this.MyMoveCounter = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[4,IndexY];
		this.MyScore = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[5,IndexY];
		this.MyHitChance = GameAdmin.GetComponent<HumanAircraftAttributes>().Hit_Chance[IndexY];
		this.MyPercenteCadence = GameAdmin.GetComponent<HumanAircraftAttributes>().PercenteCadence[IndexY];
		this.MyCadence = GameAdmin.GetComponent<HumanAircraftAttributes>().Cadence[IndexY];
		this.MyDispersion = GameAdmin.GetComponent<HumanAircraftAttributes>().Dispersion_Rate[IndexY];
		this.MyDefense = GameAdmin.GetComponent<HumanAircraftAttributes>().Defense_Value[IndexY];
		this.MyYDelay = GameAdmin.GetComponent<HumanAircraftAttributes>().YDelays[IndexY];
	}
}
