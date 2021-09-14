using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauranTesti : MonoBehaviour
{
	[SerializeField] List<GameObject> playPrefabs1 = new List<GameObject>();
	[SerializeField] List<GameObject> playPrefabs = new List<GameObject>();
	[SerializeField] List<Transform> spawnPos = new List<Transform>();
	[SerializeField] List<Transform> spawnPos1 = new List<Transform>();
	private int spawnPosLeft;

	void Start()
	{
		spawnPosLeft = spawnPos.Count;
		for (int i = 0; i < spawnPosLeft; i++)
		{
			var randomPos = spawnPos[Random.Range(0, spawnPos.Count)];
			var randomObject = playPrefabs[Random.Range(0, playPrefabs.Count)];

			Instantiate(randomObject, randomPos);
			playPrefabs1.Add(randomObject);
			spawnPos1.Add(randomPos);

			playPrefabs.Remove(randomObject);
			spawnPos.Remove(randomPos);

		}

	}
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
			DestroyKeys();
			RemovePrevious();
			SpawnKeys();
        }
    }
    private void SpawnKeys()
	{
		for (int i = 0; i < spawnPosLeft; i++)
		{
			var randomPos = spawnPos[Random.Range(0, spawnPos.Count)];
			var randomObject = playPrefabs[Random.Range(0, playPrefabs.Count)];
			Instantiate(randomObject, randomPos);

			playPrefabs1.Add(randomObject);
			spawnPos1.Add(randomPos);

			playPrefabs.Remove(randomObject);
			spawnPos.Remove(randomPos);


		}
	}

	private void DestroyKeys()
	{
		Destroy(GameObject.FindGameObjectWithTag("BlueDot"));
		Destroy(GameObject.FindGameObjectWithTag("GreenDot"));
		Destroy(GameObject.FindGameObjectWithTag("RedDot"));

	}

	private void RemovePrevious()
	{
		for (int i = 0; i < spawnPosLeft; i++)
		{
			var randomObject1 = playPrefabs1[Random.Range(0, playPrefabs1.Count)];
			var randomSpot1 = spawnPos1[Random.Range(0, spawnPos1.Count)];
			playPrefabs.Add(randomObject1);
			spawnPos.Add(randomSpot1);

			playPrefabs1.Remove(randomObject1);
			spawnPos1.Remove(randomSpot1);
		}
	}

} 
