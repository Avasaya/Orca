using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Area1_LevelSelectionController : MonoBehaviour
{
    public static Area1_LevelSelectionController levelSelection;
    public GameObject staminaRequirementScreen;
    private int levelNo;

    void Start()
    {
        staminaRequirementScreen.SetActive(false);
    }

    public void EnterLevel1() //make multiple EnterLevels with specified level no
    {
        staminaRequirementScreen.SetActive(true);
        levelNo = 1;
    }

    public void StartLevel()
    {
        //Case will increase the more levels there are
        switch (levelNo)
        {
        case 1:
            SceneManager.LoadScene("CS-Introduction");
            break;
        default:
            
            break;
        }
    }

     public void BacktoAreaSelection() 
    {
        SceneManager.LoadScene("AreaSelection");
    }

   
}
