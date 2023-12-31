using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static GameManager instance;
    [SerializeField] private GameObject[] characters;
    private int __charIndex; 

    public int CharIndex
    {
        get { return __charIndex; } // Getter
        set { __charIndex = value; } // Setter
    }
    private void Awake(){
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
            
        }
    }
    private void OnEnable(){
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;

    }
    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode){
        if (scene.name == "GamePlay")
        {
            Instantiate(characters[CharIndex]);
        }
    }
}
