using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class IconCD : MonoBehaviour {

    public Image icon;
    public caracterContorl character;
    private float skillCD;
    private float maxSkillCD;
	// Use this for initialization
	void Start () {
        maxSkillCD = character.getSkillMaxCD("dash");
	}
	
	// Update is called once per frame
	void Update () {
        skillCD = character.getSkillCD("dash");
        icon.fillAmount = skillCD / maxSkillCD;
	}
}
