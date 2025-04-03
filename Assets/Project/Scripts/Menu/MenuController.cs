using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    public static int CountGird = 5;
    public TextMeshProUGUI TextGirdCont;
    public GameObject[] gameManagers; 
    private void Update()
    {
        TextGirdCont.text = CountGird.ToString();
    }
    public void StartGame()
    {
        gameObject.SetActive(false);
        for (int i = 0; i < gameManagers.Length; i++)
        {
            gameManagers[i].SetActive(true);
        }
    }
    public void IncreaseNumber()
    {
      if (CountGird < 9) 
        CountGird += 2;
    }
    public void DecreaseNumber()
    {
        if (CountGird > 3)
            CountGird -= 2;
    }
}
