using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using TMPro;

public class menu : MonoBehaviour
{
    public GameObject levelSelect;
    public GameObject mainMenu;
    public TextMeshProUGUI header;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
      
        
    }

    public void Back()
    {
    
    }

    public void options()
    {
    
    }

    public void exit()
    {
    
    }

    public void LevelSelect()
    {
        if (mainMenu.activeSelf)
        {
            mainMenu.SetActive(false);
            levelSelect.SetActive(true);
            header.text = "Level Select";
        } else if(levelSelect.activeSelf)
        {
            mainMenu.SetActive(true);
            levelSelect.SetActive(false);
            header.text = "Main Menu";
        }
    
    }


}
