using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
	void Update(){
		if(Input.GetKeyDown (KeyCode.D)){
			// print(PlayerPrefs.GetInt("Score"));
			PlayerPrefs.DeleteAll();
			PlayerPrefs.Save();
			print("semua skor dihapus");
		}

		if(Input.GetKeyDown (KeyCode.S)){
			// print(PlayerPrefs.GetInt("Score"));
			LihatScore();
		}
	}

    public void AddScore(int scoreToAdd){
    	// PlayerPrefs.SetInt("Score", scoreToAdd);
		int indexkorkosong = IndexScoreKosong();
		if(indexkorkosong < 5){
			PlayerPrefs.SetInt("Score"+indexkorkosong, scoreToAdd);
		}
		else
		{
			print("score penuh!!!");
			if(scoreToAdd > ScoreTerkecil()){
				print("skor lebih besar");
				PlayerPrefs.SetInt("Score"+IndexScoreTerkecil(), scoreToAdd);
			}
			else{
				print("skor lebih kecil");
			}
		}
		PlayerPrefs.Save();
    }

    int IndexScoreKosong(){
    	for(int i=0;i<5;i++){
    		if(!PlayerPrefs.HasKey ("Score" + i) ){
    			return i;
    		}
    	}
    	return 5;
    }

	void LihatScore(){
		for(int i=0; i<IndexScoreKosong(); i++){
			print(PlayerPrefs.GetInt("Score"+i));
		}
	}

	int ScoreTerkecil(){
		int skor = PlayerPrefs.GetInt("Score0");
		for(int i=1;i<5;i++){
    		skor = Mathf.Min(skor, PlayerPrefs.GetInt("Score"+i));
    	}
		return skor;
	}

	int IndexScoreTerkecil(){
		int skorterkecil = ScoreTerkecil();
		int index = 0;
		for(int i=0;i<5;i++){
    		if(PlayerPrefs.GetInt ("Score" + i) == skorterkecil){
    			index = i;
				break;
    		}
    	}
		return index;
	}

	public int[] Scores(){
		int[] scores = new int[5];

		for(int i=0; i<IndexScoreKosong(); i++){
			scores[i] = PlayerPrefs.GetInt ("Score" + i);
		}
		System.Array.Sort(scores);
		System.Array.Reverse(scores);
		return scores;
	}
}
