using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ship : MonoBehaviour 
{
	private GameObject ShipsAdmin; // Pegando o objeto que contem o script com todas as informaçoes sobre as nave
	private int Speed; // Variavel que armazena a velocidade de movimento da nave
	private int YDelay; // Variavel que armazena o quanto a nave desce a cada retorno
	private int XLimit; // Variavel que armazena o valor X onde a nave fara o retorno

	//Variaveis que decidem quando a nave podera se mover, este sistema e randomico
	private int DelayToMove; // Variavel que armazena o tempo que a nave ira esperar ate começar a se mover
	private int ThisMaxDelayToMove; // Variavel que armazena o valor maximo que a nave pode esperar para se mover

	//Variavel que define se a nave pode começar a se mover
	private bool CanMove;

	//Lista com todos os canhoes da nave
	public List<Transform> ShootPos;

	//Variavel que determina se a nave pode atirar ou nao
	public bool CanShoot;

	//Variavel que define a posiçao X cuja qual a nave ira atirar
	public int XShootPosition;

	//Variaveis que definem de onde eu estou vindo
	public bool ComingFromRight;
	public bool ComingFromLeft;

	//Prefab da bala
	public GameObject Bullet;

	void Start () 
	{
		ShipsAdmin = GameObject.Find ("SpaceShipsAdmin");
		SpaceShipGetData ();

		this.DelayToMove = Random.Range(0, ThisMaxDelayToMove);
		this.CanMove = true;
		this.CanShoot = true;
	}

	void Update () 
	{
		if(this.CanMove == true)
		{
			this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Speed, 0);
		}

		Redirecting ();
		Shooting ();
	}

	//Funçao que faz o "retorno" da nave (Quando esta do lado direito da tela, seguir para o lado esquerdo, e vice-versa)
	void Redirecting()
	{
		//Nave do lado DIREITO, indo para a ESQUERDA
		if(this.gameObject.transform.position.x >= this.XLimit)
		{
			CanMove = false;
			this.gameObject.transform.position = new Vector3 (XLimit, gameObject.transform.position.y,0);
			this.DelayToMove--;
			CanShoot = true;

			if(this.DelayToMove <= 0)
			{
				this.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - YDelay, 0);
				this.Speed = this.Speed * -1;
				this.CanMove = true;
				this.DelayToMove = Random.Range(0, ThisMaxDelayToMove);
			}

			ComingFromRight = true;
			ComingFromLeft = false;
		}

		//Nave do lado ESQUERDO, indo para a DIREITA
		if(this.gameObject.transform.position.x <= -this.XLimit)
		{
			CanMove = false;
			this.gameObject.transform.position = new Vector3 (-XLimit, gameObject.transform.position.y,0);
			this.DelayToMove--;
			CanShoot = true;
			
			if(this.DelayToMove <= 0)
			{
				this.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - YDelay, 0);
				this.Speed = this.Speed * -1;
				this.CanMove = true;
				this.DelayToMove = Random.Range(0, ThisMaxDelayToMove);
			}

			ComingFromRight = false;
			ComingFromLeft = true;
		}
	}

	void Shooting()
	{
		//Se estou vindo da Direita, e minha posiçao X e menor que minha posiçao de tiro OU Se estou vindo da esquerda, e minha posiçao X e maior que minha posiçao de tiro ((E posso atirar)
		if(ComingFromRight && gameObject.transform.position.x <= XShootPosition && CanShoot || ComingFromLeft && gameObject.transform.position.x >= XShootPosition && CanShoot)
		{
			if(this.gameObject.name == "Ship01(Clone)")
			{
				GameObject Bull = Instantiate(Bullet, this.ShootPos[0].transform.position, Quaternion.identity) as GameObject;
			}
			
			if(this.gameObject.name == "Ship02(Clone)")
			{
				GameObject Bull = Instantiate(Bullet, this.ShootPos[0].transform.position, Quaternion.identity) as GameObject;
				GameObject Bull2 = Instantiate(Bullet, this.ShootPos[1].transform.position, Quaternion.identity) as GameObject;
			}
			
			if(this.gameObject.name == "Ship03(Clone)")
			{
				GameObject Bull = Instantiate(Bullet, this.ShootPos[0].transform.position, Quaternion.identity) as GameObject;
				GameObject Bull2 = Instantiate(Bullet, this.ShootPos[1].transform.position, Quaternion.identity) as GameObject;
				GameObject Bull3 = Instantiate(Bullet, this.ShootPos[2].transform.position, Quaternion.identity) as GameObject;
			}

			CanShoot = false;
		}


	}

	//Pegando do Script "SpaceShipsAdmin" as atributos de cada nave.
	void SpaceShipGetData()
	{
		if(this.gameObject.name == "Ship01(Clone)")
		{
			this.Speed = ShipsAdmin.GetComponent<SpaceShipsAdmin> ().ShipsSpeed [0];
			this.YDelay = ShipsAdmin.GetComponent<SpaceShipsAdmin> ().ShipsYDelay [0];
			this.XLimit = ShipsAdmin.GetComponent<SpaceShipsAdmin> ().ShipsXLimit [0];
			this.ThisMaxDelayToMove = ShipsAdmin.GetComponent<SpaceShipsAdmin> ().ShipsMaxDelayToMove [0];
		}
		else if(this.gameObject.name == "Ship02(Clone)")
		{
			this.Speed = ShipsAdmin.GetComponent<SpaceShipsAdmin> ().ShipsSpeed [1];
			this.YDelay = ShipsAdmin.GetComponent<SpaceShipsAdmin> ().ShipsYDelay [1];
			this.XLimit = ShipsAdmin.GetComponent<SpaceShipsAdmin> ().ShipsXLimit [1];
			this.ThisMaxDelayToMove = ShipsAdmin.GetComponent<SpaceShipsAdmin> ().ShipsMaxDelayToMove [1];
		}
		else if (this.gameObject.name == "Ship03(Clone)")
		{
			this.Speed = ShipsAdmin.GetComponent<SpaceShipsAdmin> ().ShipsSpeed [2];
			this.YDelay = ShipsAdmin.GetComponent<SpaceShipsAdmin> ().ShipsYDelay [2];
			this.XLimit = ShipsAdmin.GetComponent<SpaceShipsAdmin> ().ShipsXLimit [2];
			this.ThisMaxDelayToMove = ShipsAdmin.GetComponent<SpaceShipsAdmin> ().ShipsMaxDelayToMove [2];
		}
		else if(this.gameObject.name == "SpecialShip(Clone)")
		{
			this.Speed = ShipsAdmin.GetComponent<SpaceShipsAdmin> ().ShipsSpeed [3];
			this.YDelay = ShipsAdmin.GetComponent<SpaceShipsAdmin> ().ShipsYDelay [3];
			this.XLimit = ShipsAdmin.GetComponent<SpaceShipsAdmin> ().ShipsXLimit [3];
			this.ThisMaxDelayToMove = ShipsAdmin.GetComponent<SpaceShipsAdmin> ().ShipsMaxDelayToMove [3];
		}
	}
}
