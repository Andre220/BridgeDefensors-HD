using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpaceShipsAdmin : MonoBehaviour 
{
	//Linha que permite outros scripts acessarem este script
	static public SpaceShipsAdmin instance;

	//Listas de variaveis que vao definir os atributos de cada nave. Assim que cada nave ser spawnada, ela ira pegar seus atributos particulares destas listas.
	[Header("Ships Attributes")]
	public List<int> ShipsSpeed; // Velocidade de movimento da nave
	public List<int> ShipsYDelay; // A cada passada, a nave desce um pouco. Esta lista armazena em cada indice, o quanto a nave desce(Valor padrao = 4). 
	public List<int> ShipsXLimit; // Posiçao X onde a nave fara o retorno.
	public List<int> ShipsMaxDelayToMove; // Define qual o valor maximo do delay que fara com que a nave comece a se mover.

	//Lista de alvos disponiveis
	[Header ("Targets")]
	public List<GameObject> Targets;
	
	//Lista de Naves que podem ser spawnadas.
	[Header("Available Ships")]
	public List<GameObject> ShipsToSpawn;

	//tempo necessario ate que outra nave possa ser spawnada
	[Header("Spawn Delay")]
	public int SpawnDelay;
	public int SpawnStartDelay;

	//Posiçoao cuja qual as naves serao spawnadas
	[Header("Position Where Ships will be spawned")]
	public Vector3 SpawnPosition;

	//Variavel que conta o tempo passado, e libera naves mais poderosas para atacar
	public int Timer;
	public int ShipsLevel2;
	public int ShipsLevel3;

	void Start () 
	{
		instance = this;
		SpawnStartDelay = SpawnDelay;

		Targets.Capacity = 10;
		foreach(GameObject Tar in GameObject.FindGameObjectsWithTag("Target"))
		{
			Targets.Add(Tar);
		}
	}

	void Update () 
	{
		Timer++;
		SpawnDelay--;

		if(SpawnDelay <= 0)
		{
			GameObject Ship = Instantiate(ShipsToSpawn[Random.Range(0,ShipsToSpawn.Count)], SpawnPosition, Quaternion.identity) as GameObject;
			Ship.transform.SetParent(GameObject.Find ("SpaceShipsAdmin").transform);
			SpawnDelay = SpawnStartDelay;
		}

		if(Timer > ShipsLevel2)
		{
			//Debug.Log ("Naves de nivel 2 disponiveis");
			
			if(Timer > ShipsLevel3)
			{
				//Debug.Log ("Naves de nivel 3 disponiveis");
			}

		}
	
	}
}
