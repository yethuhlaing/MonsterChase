using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject[] charactersArray;
    [SerializeField] private Transform left;
    [SerializeField] private Transform right;
    private int randomMonsterIndex, randomIndex;
    private GameObject randomMonster;


    void Start()
    {
        StartCoroutine("SpawnMonsters");
    }

    // Update is called once per frame
    IEnumerator SpawnMonsters(){
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1,3));
            randomMonsterIndex = Random.Range(0, charactersArray.Length);
            randomMonster = Instantiate(charactersArray[randomMonsterIndex]);
            randomIndex = Random.Range(0, 2);
            if (randomIndex == 0)
            {
                randomMonster.transform.position = left.position;
                randomMonster.GetComponent<Monster>().speed = Random.Range(7, 10);
            }
            else
            {
                randomMonster.transform.position = right.position;
                randomMonster.GetComponent<Monster>().speed = -Random.Range(5,10);
                randomMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
    }
}
