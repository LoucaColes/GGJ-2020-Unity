using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    private GameObject playerJoinUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (LevelFlowManager.instance.CurrentFlowState == LevelFlowState.PLAYERSELECT)
        //{
        //    if (playerJoinUI.activeInHierarchy == false)
        //    {
        //        playerJoinUI.SetActive(true);
        //    }
        //}
    }

    private void SetUIState(GameObject targetUI, LevelFlowState levelFlowState, bool setState)
    {
        if (LevelFlowManager.instance.CurrentFlowState == levelFlowState)
        {
            if (targetUI.activeInHierarchy == !setState)
            {
                targetUI.SetActive(setState);
            }
        }
    }
}
