using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyIA : MonoBehaviour 
{
	public GameObject GameAdmin;

	//Constantes
	public int MyDamage, MyCadence, MyBulletVel, MyMoveSpeed, MyLife, MyScore, MyDispersion, MyDefense;
	public List<Transform> MyShootPositions;
	//Nao constantes
	public int  AreaR, AreaL, AreaC;//Locais onde a nave ira atirar
	public float MyPercenteCadence, MyHitChance;
	public int XLimit, MyMoveCounter, StartMoveCounter, MyYDelay, MyYIndex;//Variaveis que armazenam valores relacionados ao movimento das naves.

	public bool OutOfScreen, RightSideOfScreen, CanShoot;

	void Start () 
	{
		GameAdmin = EnemyAdm.Instance.GameAdmin;
		PositionOnScreen ();
		Getting_Data ();
	
		this.MyYIndex = 0;
		this.StartMoveCounter = this.MyMoveCounter;

		if (this.RightSideOfScreen){this.MyMoveSpeed *= -1;}//The speed always begins like positive
	}

	void Update () 
	{
		Moving ();
		Shooting ();
	}

	void PositionOnScreen()//Void que testa se a nave esta dentro ou fora da tela, e se a posiçao dela e positiva ou negativa
	{
		if(this.gameObject.transform.position.x >= XLimit || this.gameObject.transform.position.x <= -XLimit)
		{
			this.OutOfScreen = true;
		}else
		{
			this.OutOfScreen = false;
		}

		if(this.gameObject.transform.position.x > 0)
		{
			this.RightSideOfScreen = true;
		}else
		{
			this.RightSideOfScreen = false;
		}
	}

	void Moving()
	{
		this.gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (this.MyMoveSpeed, 0);

		PositionOnScreen ();
		
		if(this.OutOfScreen)
		{
			this.gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
			this.MyMoveCounter --;
			
			if(this.MyMoveCounter <= 0)
			{
				if(this.MyYIndex <= 3)
				{
					this.MyYIndex += this.MyYDelay;
				}else{
					Debug.Log ("I Will Blow!");
					Destroy(this.gameObject);
				}

				GameAdmin.GetComponent<HumanAircraftAttributes>().PleaseRandom = true;
				Get_RandomAttributes();
				WhereShoot();
				this.gameObject.transform.position = new Vector3(gameObject.transform.position.x, GameAdmin.GetComponent<HumanAircraftAttributes>().YPositions[MyYIndex], gameObject.transform.position.z);
				this.MyMoveSpeed *= -1;
				this.gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (this.MyMoveSpeed, 0);
				this.MyMoveCounter = this.StartMoveCounter;
			}
		}else//Caso a nave esteja na tela
		{
			if (this.gameObject.transform.position.x == AreaR || this.gameObject.transform.position.x == AreaC || this.gameObject.transform.position.x == AreaL) 
			{
				CanShoot = true;
				Shooting();
			}
		}
	}

	void WhereShoot()
	{
		int BattleArea;
		BattleArea = XLimit * 2;

		switch (this.MyCadence) 
		{//Vendo quantas vezes eu irei atirar
		case 0:
			Debug.Log ("Don't Shoot");
		break;
		case 1:
			AreaC = Random.Range (-BattleArea / 2, BattleArea / 2);
		break;
		case 2:
			AreaR = Random.Range (0, BattleArea / 2);
			AreaL = Random.Range (-BattleArea / 2, 0);
		break;
		case 3:
			AreaR = Random.Range (BattleArea / 3, 40);
			AreaC = Random.Range (-BattleArea / 3, BattleArea / 3);
			AreaL = Random.Range (-40, -BattleArea);
		break;
		}
	}

	void Shooting()
	{
		if (CanShoot) 
		{
			switch (this.MyDispersion) {//Estou vendo quantas balas eu devo atirar.
			case 1:
				GameObject Bullet1 = Instantiate (GameAdmin.GetComponent<HumanAircraftAttributes>().Bullets [0], this.MyShootPositions[0].position, Quaternion.identity) as GameObject;
				Bullet1.name = this.gameObject.name + "Bullet";
				break;
			case 2:
				GameObject Bullet2 = Instantiate (GameAdmin.GetComponent<HumanAircraftAttributes>().Bullets [0], this.MyShootPositions[0].position, Quaternion.identity) as GameObject;
				Bullet2.name = this.gameObject.name + "Bullet";
				GameObject Bullet3 = Instantiate (GameAdmin.GetComponent<HumanAircraftAttributes>().Bullets [0], this.MyShootPositions[1].position, Quaternion.identity) as GameObject;
				Bullet3.name = this.gameObject.name + "Bullet";
				break;
			case 3:
				GameObject Bullet4 = Instantiate (GameAdmin.GetComponent<HumanAircraftAttributes>().Bullets [0], this.MyShootPositions[0].position, Quaternion.identity) as GameObject;
				Bullet4.name = this.gameObject.name + "Bullet";
				GameObject Bullet5 = Instantiate (GameAdmin.GetComponent<HumanAircraftAttributes>().Bullets [0], this.MyShootPositions[1].position, Quaternion.identity) as GameObject;
				Bullet5.name = this.gameObject.name + "Bullet";
				GameObject Bullet6 = Instantiate (GameAdmin.GetComponent<HumanAircraftAttributes>().Bullets [0], this.MyShootPositions[2].position, Quaternion.identity) as GameObject;
				Bullet6.name = this.gameObject.name + "Bullet";
				break;
			}
			CanShoot = false;
		}
	}

	void Get_RandomAttributes()
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
		this.MyDispersion = GameAdmin.GetComponent<HumanAircraftAttributes>().Dispersion [Index];
		this.MyDefense = GameAdmin.GetComponent<HumanAircraftAttributes>().Defense_Rate [Index];
		this.MyYDelay = GameAdmin.GetComponent<HumanAircraftAttributes> ().YDelays [Index];
	}

	void Getting_Data()
	{
		int IndexY = 0;
		switch(gameObject.name)
		{
			case "Aircraft01":
			IndexY = 0;
				this.MyShootPositions.Insert(0, gameObject.transform.FindChild("ShootPosition01"));//Pegando os ShootPositions que sao filhos do proprio obj
			break;
			case "Aircraft02":
			IndexY = 1;
				this.MyShootPositions.Insert(0, gameObject.transform.FindChild("ShootPosition01"));//Pegando os ShootPositions que sao filhos do proprio obj
			break;
			case "Aircraft03":
			IndexY = 2;
				this.MyShootPositions.Insert(0, gameObject.transform.FindChild("ShootPosition01"));//Pegando os ShootPositions que sao filhos do proprio obj
				this.MyShootPositions.Insert(1, gameObject.transform.FindChild("ShootPosition02"));//Pegando os ShootPositions que sao filhos do proprio obj
			break;
			case "Aircraft04":
			IndexY = 3;
				this.MyShootPositions.Insert(0, gameObject.transform.FindChild("ShootPosition01"));//Pegando os ShootPositions que sao filhos do proprio obj
				this.MyShootPositions.Insert(1, gameObject.transform.FindChild("ShootPosition02"));//Pegando os ShootPositions que sao filhos do proprio obj
			break;
			case "VTOLBoss":
			IndexY = 4;
				this.MyShootPositions.Insert(0, gameObject.transform.FindChild("ShootPosition01"));//Pegando os ShootPositions que sao filhos do proprio obj
				this.MyShootPositions.Insert(1, gameObject.transform.FindChild("ShootPosition02"));//Pegando os ShootPositions que sao filhos do proprio obj
				this.MyShootPositions.Insert(2, gameObject.transform.FindChild("ShootPosition03"));//Pegando os ShootPositions que sao filhos do proprio obj
			break;
			case "Cargo_Aircraft":
			IndexY = 5;
			break;
			case "Passenger_Aircraft":
			IndexY = 6;
			break;
		}
		//Pegando dados do Script HumanAircraftAttributes do GameAdmin
		this.MyDamage = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[0,IndexY];
		this.MyBulletVel = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[1,IndexY];
		this.MyMoveSpeed = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[2,IndexY];
		this.MyLife = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[3,IndexY];
		this.MyMoveCounter = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[4,IndexY];
		this.MyScore = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[5,IndexY];
		this.MyHitChance = GameAdmin.GetComponent<HumanAircraftAttributes>().PercenteHit[IndexY];
		this.MyPercenteCadence = GameAdmin.GetComponent<HumanAircraftAttributes>().PercenteCadence[IndexY];
		this.MyCadence = GameAdmin.GetComponent<HumanAircraftAttributes>().Cadence[IndexY];
		this.MyDispersion = GameAdmin.GetComponent<HumanAircraftAttributes>().Dispersion[IndexY];
		this.MyDefense = GameAdmin.GetComponent<HumanAircraftAttributes>().Defense_Rate[IndexY];
		this.MyYDelay = GameAdmin.GetComponent<HumanAircraftAttributes>().YDelays[IndexY];
	}
}
