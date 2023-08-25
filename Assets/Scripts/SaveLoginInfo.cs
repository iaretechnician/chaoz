using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoginInfo : MonoBehaviour
{
	public Text txtLogin,txtPassword;
	// Start is called before the first frame update
	void OnEnable()
	{
	
	}
    void Start()
	{
		print("Starting load logins");
		print("Login Name"+PlayerPrefs.GetString("LoginName","Newbie"));
		print("txtLogin "+txtLogin.text);
		txtLogin.text = PlayerPrefs.GetString("LoginName","Newbie");
		txtPassword.text=PlayerPrefs.GetString("LoginPass","Pass");
		
    }

    // Update is called once per frame
    void Update()
    {
	    txtLogin.text=PlayerPrefs.GetString("LoginName","Newbie");
	    txtPassword.text=PlayerPrefs.GetString("LoginPass","Pass");
    }
    
	public void SaveInfo()
	{
		PlayerPrefs.SetString("LoginName",txtLogin.text);
		PlayerPrefs.SetString("LoginPass",txtPassword.text);
	}
    
	public void LoadSavedInfo()
	{
		
	}
}
