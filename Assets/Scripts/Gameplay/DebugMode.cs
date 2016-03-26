using UnityEngine;
using System.Collections;

public class DebugMode : MonoBehaviour 
{
	public static DebugMode instance;

	//EnemyIA DebugMode
	public int EnemyIACanMoveCounter;
	//EnemyAdm DebugMode
	public int EnemyAdmSpawnCounter;

	void Start () 
	{
		instance = this;
	}

	void Update () 
	{
	
	}
}
