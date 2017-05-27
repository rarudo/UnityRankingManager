using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;


public class RankingManager : MonoBehaviour
{
    FileInfo fi;
	List<int> scores = new List<int>();
	
	// Use this for initialization
	void Start ()
	{
        fi = new FileInfo("./Assets/Saves/Score.csv");
		loadSave();
	}
	
	public void insertScore(int score)
	{
		scores.Add(score);
        StreamWriter sw;
		sw = fi.AppendText();
		sw.WriteLine(score);
		sw.Flush();
		sw.Close();
	}

	private void loadSave()
	{
        // FileReadTest.txtファイルを読み込む
        try {
            using (StreamReader sr = new StreamReader(fi.OpenRead(), Encoding.UTF8)){
                // 一行毎読み込み
	            while(sr.Peek() >= 0){
                    string readLine = sr.ReadLine();
                    scores.Add(int.Parse(readLine));
                }
            }
        } catch (Exception e){
            // 改行コード
	        print(e);
        }
	}

	public List<int> getSortedScores()
	{
		scores.Sort();
		scores.Reverse();
		return scores;
	}

	public int getHighScore()
	{
		return getSortedScores()[0];
	}

	
	// Update is called once per frame
	void Update () {

	}
}
