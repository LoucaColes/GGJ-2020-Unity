using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerInput[] playersIP = new PlayerInput[0];

    [SerializeField] private GameObject[] playersOB = new GameObject[0];

    private int playerCount = 0;

    public int PlayerCount { get { return playerCount; } }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelFlowManager.instance.CurrentFlowState == LevelFlowState.PLAYERSELECT)
        {
            HandlePlayerJoinAndLeave();
        }
    }

    private void HandlePlayerJoinAndLeave()
    {
        for (int index = 0; index < playersIP.Length; index++)
        {
            if (playersIP[index].Join)
            {
                Debug.Log("Joining");
                if (!playersOB[index].activeSelf)
                {
                    playerCount++;
                }
                playersOB[index].SetActive(true);
            }

            if (playersIP[index].Leave)
            {
                if (playersOB[index].activeSelf)
                {
                    playerCount--;
                }
                playersOB[index].SetActive(false);
            }

            if (playersIP[index].Interact)
            {
                if (playerCount > 0 )
                {
                    Debug.Log("Player Count is fine");
                    LevelFlowManager.instance.ChangeFlowState(LevelFlowState.SETUP);
                }
                else
                {
                    Debug.Log("Player Count: " + playerCount);
                }
            }
        }
    }
}
