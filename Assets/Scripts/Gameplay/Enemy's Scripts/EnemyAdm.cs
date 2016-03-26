using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAdm : MonoBehaviour 
{
	/*Neste script, eu armazeno, sorteio, e instancio cada nave*/

	public static EnemyAdm Instance; 
	public GameObject GameAdmin;

	public int ShipReady; //Armazena o valor do indice (Ships[ShipReady]) que ira ser instanciado.
	public List<GameObject> Ships;//Armazena os prefabs das naves (13).
	public List<GameObject> ShipsInBattle;//Armazena as naves que foram instanciadas.

	public int SpawnCounter, SpawnCounterStart; //Variaveis que definem quando a nave tem de ser spawnada. Caso o SpawnCounter seja menor que 0, instancia a nave.
	public List<Transform> SpawnPositions;//Posiçoes onde serao spawnadas as naves inicialmente.

	void Start () 
	{
		Instance = this;
		GameAdmin = this.gameObject;
		SpawnCounterStart = SpawnCounter;
		ShipReady = Random.Range(0, 2);
	}

	void Update () 
	{
		SpawnCounter--;

		if(SpawnCounter < 0)
		{
			SpawnCounter = SpawnCounterStart;
			GameObject Ship = Instantiate(Ships[ShipReady], SpawnPositions[0]/*[Random(0,SpawnPositions.Count)]*/.transform.position, Quaternion.identity) as GameObject;
			Ship.name = Ships[ShipReady].name;
			Ship.transform.SetParent(GameAdmin.transform);
			ShipsInBattle.Add(Ship);
			ShipReady = Random.Range(0, 2);
		}
	}
}
