using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyIA : MonoBehaviour 
{
	public GameObject GameAdmin;

	public int MyDamage, MyCadence, MyBulletVel, MyMoveSpeed, MyDispersion, MyLife, MyDefense, MyYDelay, MyScore;  
	public int XLimit, MyMoveCounter, StartMoveCounter; //XLimit - posiçao em X onde a nave ja tera saido da tela/MoveCounter+StartMoveCounter - Decremento que informa se a nave pode se mover.
	public float MyPercenteCadence, MyHitChance;
	public string OutOfScreen, SideOfScreen;
	public List<int> YPositions; 

	void Start () 
	{
		GameAdmin = EnemyAdm.Instance.GameAdmin;

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

				this.MyMoveSpeed *= -1;
				this.gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (this.MyMoveSpeed, 0);
				this.MyMoveCounter = this.StartMoveCounter;
			}
		}
		//------------------------------------
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

	/*void Shooting_IA()
	{
		switch(gameObject.name)
		{
		case "Ship01(Clone)":
				if(this.transform.position.x == this.XShootPosition01)
				{
					XShootPosition01 = Random.Range(MinShootPosition, MaxShootPosition);
					//atirar bala
					Debug.Log ("atirei01");
				}
			break;
		case "Ship02(Clone)":
				if(this.transform.position.x == this.XShootPosition01)
				{
					XShootPosition01 = Random.Range(MinShootPosition, MaxShootPosition);
					//atirar bala
					Debug.Log ("atirei01");
				}
			break;
		case "Ship03(Clone)":
				if(this.transform.position.x == this.XShootPosition01)
				{
					XShootPosition02 = Random.Range(MinShootPosition, MidShootPosition);
					//atirar bala
					Debug.Log ("atirei01");
				}
				if(this.transform.position.x == this.XShootPosition02)
				{
					XShootPosition01 = Random.Range(MidShootPosition, MaxShootPosition);
					//atirar bala
					Debug.Log ("atirei02");
				}
			break;
		case "Ship04(Clone)":
				if(this.transform.position.x == this.XShootPosition01)
				{
					XShootPosition02 = Random.Range(MinShootPosition, MidShootPosition);
					//atirar bala
					Debug.Log ("atirei01");
				}
				if(this.transform.position.x == this.XShootPosition02)
				{
					XShootPosition01 = Random.Range(MidShootPosition, MaxShootPosition);
					//atirar bala
					Debug.Log ("atirei02");
				}
			break;
		case "ShipBoss(Clone)":
				if(this.transform.position.x == this.XShootPosition01)
				{
					XShootPosition02 = Random.Range(MinShootPosition, MidShootPosition);
					//atirar bala
					Debug.Log ("atirei01");
				}
				if(this.transform.position.x == this.XShootPosition02)
				{
					XShootPosition01 = Random.Range(MidShootPosition, MaxShootPosition);
					//atirar bala
					Debug.Log ("atirei02");
				}
			break;
		case "ShipSpecial(Clone)":
				Debug.Log ("I don't Shoot");
			break;
		}

	}*/

	/*void Recalculate_Chances()
	{
		switch (this.gameObject.name) 
		{
		case "Ship01(Clone)":
			this.MyCadence = GameAdmin.GetComponent<HumanAircraftAttributes>().Cadence [0];
			this.MyDispersion = GameAdmin.GetComponent<HumanAircraftAttributes>().Dispersion_Rate [0];
			this.MyDefense = GameAdmin.GetComponent<HumanAircraftAttributes>().Defense_Value [0];
			break;
		case "Ship02(Clone)":
			this.MyCadence = GameAdmin.GetComponent<HumanAircraftAttributes>().Cadence [1];
			this.MyDispersion = GameAdmin.GetComponent<HumanAircraftAttributes>().Dispersion_Rate [1];
			this.MyDefense = GameAdmin.GetComponent<HumanAircraftAttributes>().Defense_Value [1];
			break;
		case "Ship03(Clone)":
			this.MyCadence = GameAdmin.GetComponent<HumanAircraftAttributes>().Cadence [2];
			this.MyDispersion = GameAdmin.GetComponent<HumanAircraftAttributes>().Dispersion_Rate [2];
			this.MyDefense = GameAdmin.GetComponent<HumanAircraftAttributes>().Defense_Value [2];
			break;
		case "Ship04(Clone)":
			this.MyCadence = GameAdmin.GetComponent<HumanAircraftAttributes>().Cadence [0];
			this.MyDispersion = GameAdmin.GetComponent<HumanAircraftAttributes>().Dispersion_Rate [0];
			this.MyDefense = GameAdmin.GetComponent<HumanAircraftAttributes>().Defense_Value [0];
			break;
		case "ShipBoss(Clone)":
			this.MyCadence = GameAdmin.GetComponent<HumanAircraftAttributes>().Cadence [3];
			this.MyDispersion = GameAdmin.GetComponent<HumanAircraftAttributes>().Dispersion_Rate [3];
			this.MyDefense = GameAdmin.GetComponent<HumanAircraftAttributes>().Defense_Value [3];
			break;
		case "ShipSpecial(Clone)":
			this.MyCadence = GameAdmin.GetComponent<HumanAircraftAttributes>().Cadence [4];
			this.MyDispersion = GameAdmin.GetComponent<HumanAircraftAttributes>().Dispersion_Rate [4];
			this.MyDefense = GameAdmin.GetComponent<HumanAircraftAttributes>().Defense_Value [4];
			break;
		}
	}*/

	void Getting_Data()
	{
		switch(gameObject.name)
		{
			case "Aircraft01":
				this.MyDamage = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[0,0];
				this.MyBulletVel = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[1,0];
				this.MyMoveSpeed = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[2,0];
				this.MyLife = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[3,0];
				this.MyMoveCounter = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[4,0];
				this.MyScore = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[5,0];
				this.MyHitChance = GameAdmin.GetComponent<HumanAircraftAttributes>().Hit_Chance[0];
				this.MyPercenteCadence = GameAdmin.GetComponent<HumanAircraftAttributes>().PercenteCadence[0];
				this.MyCadence = GameAdmin.GetComponent<HumanAircraftAttributes>().Cadence[0];
				this.MyDispersion = GameAdmin.GetComponent<HumanAircraftAttributes>().Dispersion_Rate[0];
				this.MyDefense = GameAdmin.GetComponent<HumanAircraftAttributes>().Defense_Value[0];
				this.MyYDelay = GameAdmin.GetComponent<HumanAircraftAttributes>().YDelays[0];
			break;
		case "Aircraft02":
				this.MyDamage = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[0,1];
				this.MyBulletVel = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[1,1];
				this.MyMoveSpeed = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[2,1];
				this.MyLife = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[3,1];
				this.MyMoveCounter = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[4,1];
				this.MyScore = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[5,1];
				this.MyHitChance = GameAdmin.GetComponent<HumanAircraftAttributes>().Hit_Chance[1];
				this.MyPercenteCadence = GameAdmin.GetComponent<HumanAircraftAttributes>().PercenteCadence[1];
				this.MyCadence = GameAdmin.GetComponent<HumanAircraftAttributes>().Cadence[1];
				this.MyDispersion = GameAdmin.GetComponent<HumanAircraftAttributes>().Dispersion_Rate[1];
				this.MyDefense = GameAdmin.GetComponent<HumanAircraftAttributes>().Defense_Value[1];
				this.MyYDelay = GameAdmin.GetComponent<HumanAircraftAttributes>().YDelays[1];
			break;
		case "Aircraft03":
				this.MyDamage = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[0,2];
				this.MyBulletVel = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[1,2];
				this.MyMoveSpeed = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[2,2];
				this.MyLife = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[3,2];
				this.MyMoveCounter = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[4,2];
				this.MyScore = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[5,2];
				this.MyHitChance = GameAdmin.GetComponent<HumanAircraftAttributes>().Hit_Chance[2];
				this.MyPercenteCadence = GameAdmin.GetComponent<HumanAircraftAttributes>().PercenteCadence[2];
				this.MyCadence = GameAdmin.GetComponent<HumanAircraftAttributes>().Cadence[2];
				this.MyDispersion = GameAdmin.GetComponent<HumanAircraftAttributes>().Dispersion_Rate[2];
				this.MyDefense = GameAdmin.GetComponent<HumanAircraftAttributes>().Defense_Value[2];
				this.MyYDelay = GameAdmin.GetComponent<HumanAircraftAttributes>().YDelays[2];
			break;
		case "Aircraft04":
				this.MyDamage = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[0,3];
				this.MyBulletVel = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[1,3];
				this.MyMoveSpeed = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[2,3];
				this.MyLife = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[3,3];
				this.MyMoveCounter = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[4,3];
				this.MyScore = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[5,3];
				this.MyHitChance = GameAdmin.GetComponent<HumanAircraftAttributes>().Hit_Chance[3];
				this.MyPercenteCadence = GameAdmin.GetComponent<HumanAircraftAttributes>().PercenteCadence[3];
				this.MyCadence = GameAdmin.GetComponent<HumanAircraftAttributes>().Cadence[3];
				this.MyDispersion = GameAdmin.GetComponent<HumanAircraftAttributes>().Dispersion_Rate[3];
				this.MyDefense = GameAdmin.GetComponent<HumanAircraftAttributes>().Defense_Value[3];
				this.MyYDelay = GameAdmin.GetComponent<HumanAircraftAttributes>().YDelays[3];
			break;
		case "VTOLBoss":
				this.MyDamage = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[0,4];
				this.MyBulletVel = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[1,4];
				this.MyMoveSpeed = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[2,4];
				this.MyLife = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[3,4];
				this.MyMoveCounter = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[4,4];
				this.MyScore = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[5,4];
				this.MyHitChance = GameAdmin.GetComponent<HumanAircraftAttributes>().Hit_Chance[4];
				this.MyPercenteCadence = GameAdmin.GetComponent<HumanAircraftAttributes>().PercenteCadence[4];
				this.MyCadence = GameAdmin.GetComponent<HumanAircraftAttributes>().Cadence[4];
				this.MyDispersion = GameAdmin.GetComponent<HumanAircraftAttributes>().Dispersion_Rate[4];
				this.MyDefense = GameAdmin.GetComponent<HumanAircraftAttributes>().Defense_Value[4];
				this.MyYDelay = GameAdmin.GetComponent<HumanAircraftAttributes>().YDelays[4];
			break;
		case "Cargo_Aircraft":
				this.MyDamage = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[0,5];
				this.MyBulletVel = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[1,5];
				this.MyMoveSpeed = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[2,5];
				this.MyLife = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[3,5];
				this.MyMoveCounter = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[4,5];
				this.MyScore = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[5,5];
				this.MyHitChance = GameAdmin.GetComponent<HumanAircraftAttributes>().Hit_Chance[5];
				this.MyPercenteCadence = GameAdmin.GetComponent<HumanAircraftAttributes>().PercenteCadence[5];
				this.MyCadence = GameAdmin.GetComponent<HumanAircraftAttributes>().Cadence[5];
				this.MyDispersion = GameAdmin.GetComponent<HumanAircraftAttributes>().Dispersion_Rate[5];
				this.MyDefense = GameAdmin.GetComponent<HumanAircraftAttributes>().Defense_Value[5];
				this.MyYDelay = GameAdmin.GetComponent<HumanAircraftAttributes>().YDelays[5];
			break;
		case "Passenger_Aircraft":
			this.MyDamage = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[0,5];
			this.MyBulletVel = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[1,5];
			this.MyMoveSpeed = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[2,5];
			this.MyLife = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[3,5];
			this.MyMoveCounter = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[4,5];
			this.MyScore = GameAdmin.GetComponent<HumanAircraftAttributes>().HShips_Basic_Attributes[5,5];
			this.MyHitChance = GameAdmin.GetComponent<HumanAircraftAttributes>().Hit_Chance[5];
			this.MyPercenteCadence = GameAdmin.GetComponent<HumanAircraftAttributes>().PercenteCadence[5];
			this.MyCadence = GameAdmin.GetComponent<HumanAircraftAttributes>().Cadence[5];
			this.MyDispersion = GameAdmin.GetComponent<HumanAircraftAttributes>().Dispersion_Rate[5];
			this.MyDefense = GameAdmin.GetComponent<HumanAircraftAttributes>().Defense_Value[5];
			this.MyYDelay = GameAdmin.GetComponent<HumanAircraftAttributes>().YDelays[5];
			break;
		}
	}
}
