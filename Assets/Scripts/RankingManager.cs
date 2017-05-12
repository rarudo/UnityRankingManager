using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RankingManager : MonoBehaviour
{
	[SerializeField]
	private List<rank> rankList;

    [Serializable]
	public struct rank{
		public int score;
        public string name;
	}

	[Serializable]
	public struct rankingStruct
	{
		public rank[] ranks;
	}

	// Use this for initialization
	void Start ()
	{
		rank[] rankings;
		rankings = new rank[10];
		for (int i = 0; i < rankings.Length; i++)
		{
			rankings[i].score = i;
			rankings[i].name = "taro" + i;
		}
		rankingStruct rans = new rankingStruct();
		rans.ranks = rankings;


		string json = JsonUtility.ToJson(rans);
		print(json);
		rankList = new List<rank>();
		foreach (rank rank in rankings)
		{
			rankList.Add(rank);
		}
		string json2 = JsonUtility.ToJson(rankList);
		print(json2);



	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
