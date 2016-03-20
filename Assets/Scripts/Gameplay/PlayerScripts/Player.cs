using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour 
{
	//Instanciando esta classe
	[HideInInspector]
	public static Player PlayerInstance;
	[HideInInspector]
	public PlayerAttributes Play_Att;
	
	[Header("Shoot Buttoms")]
	public KeyCode MainButtom, RightButtom, LeftButtom;

	//Variaveis que armazenam o intervalo entre cada tiro, vulgo "Cadencia".
	//As variaveis com "start" sao variaveis que armazenam o valor inicial do delay do tiro, para que ele seja reinicializado.
	[Header("Shoot Delay")]
	public float MainDelay, RightDelay, LeftDelay;
	private float MainStartDelay, RightStartDelay, LeftStartDelay;

	//Listas que armazenam os sprites dos canhoes.
	[Header("Cannon Sprites")]
	public List<Sprite> MainCannonSprites, RightCannonSprites, LeftCannonSprites;

	[Header("Bullet Pref")]
	public GameObject Bullet;

	//Posiçoes de onde as balas de cada canhao sairao
	private Transform MainShootPosition, RightShootPosition, LeftShootPosition;

	void Start () 
	{
		PlayerInstance = this;
		Play_Att = GameObject.Find ("GameAdmin").GetComponent<PlayerAttributes> ();
		//Fazendo com que as variaveis que armazanem o valor inicial dos delay, recebam os valores dos delays.
		MainStartDelay = MainDelay;
		RightStartDelay = RightDelay;
		LeftStartDelay = LeftDelay;

		//Atribuindo as posiçoes de tiro
		MainShootPosition = gameObject.transform.FindChild ("MainCannon").transform.FindChild ("ShootPosition").transform;
		RightShootPosition = gameObject.transform.FindChild ("RightCannon").transform.FindChild ("ShootPosition").transform;
		LeftShootPosition = gameObject.transform.FindChild ("LeftCannon").transform.FindChild ("ShootPosition").transform;
	}

	void Update () 
	{
		//Decrementando os delays, caso sejam menores que 0, o canhao estara disponivel para atirar.
		MainDelay--;
		RightDelay--;
		LeftDelay--;

		Inputs ();
	}

	void Inputs()
	{
		//Se eu aperto o botao de tiro do canhao do meio + Delay do canhao do meio esta menor que 0 + Este objeto esta vivo.
		if(Input.GetKey(MainButtom) && MainDelay <= 0)
		{
			GameObject MainBullet = Instantiate(Bullet, MainShootPosition.transform.position, Quaternion.identity) as GameObject;
			MainBullet.transform.SetParent (this.gameObject.transform.FindChild("MainCannon").transform);
			MainDelay = MainStartDelay;
		}
		
		if(Input.GetKey(RightButtom) && RightDelay <= 0)
		{
			GameObject RightBullet = Instantiate(Bullet, RightShootPosition.transform.position, Quaternion.identity) as GameObject;
			RightBullet.transform.SetParent(this.gameObject.transform.FindChild("RightCannon").transform);
			RightBullet.transform.localEulerAngles = new Vector3(0,0,45);
			RightDelay = RightStartDelay;
		}
		
		if(Input.GetKey(LeftButtom) && LeftDelay <= 0)
		{
			GameObject LeftBullet = Instantiate(Bullet, LeftShootPosition.transform.position, Quaternion.identity) as GameObject;
			LeftBullet.transform.SetParent(this.gameObject.transform.FindChild("LeftCannon").transform);
			LeftBullet.transform.localEulerAngles = new Vector3(0,0,315);
			LeftDelay = LeftStartDelay;
		}
	}
}