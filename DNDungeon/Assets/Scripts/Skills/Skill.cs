using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour {

    private string m_name;
    private int m_rank;
    private int m_level;
    private int m_levelMax;
    private int m_exp;
    private int[] m_expRequired;

    public Skill()
    {
        m_name = "";
        m_rank = 0;
        m_level = 0;
        m_levelMax = 0;
        m_exp = 0;
        m_expRequired = new int[] { };
    }

    public Skill(string name, int rank, int level, int levelMax, int exp, int[] expRequired)
    {
        m_name = name;
        m_rank = rank;
        m_level = level;
        m_levelMax = levelMax;
        m_exp = exp;
        m_expRequired = expRequired;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
