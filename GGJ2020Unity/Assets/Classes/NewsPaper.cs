using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NewsPaper : MonoBehaviour
{
    [SerializeField] private Sprite[] faces;
    [SerializeField] private Image[] faceImages;

    [SerializeField, TextArea] private string[] resultMessages;
    [SerializeField] private TextMeshProUGUI resultText;

    private void OnEnable()
    {
        float audienceReaction = LevelFlowManager.instance.audienceEngagement;

        if (audienceReaction >= 0 && audienceReaction < 33.3f)
        {
            foreach (var faceImage in faceImages)
            {
                faceImage.sprite = faces[1];
            }

            resultText.text = resultMessages[1];
        }

        if (audienceReaction >= 33.3 && audienceReaction < 66.6f)
        {
            foreach (var faceImage in faceImages)
            {
                faceImage.sprite = faces[0];
            }

            resultText.text = resultMessages[0];
        }

        if (audienceReaction >= 66.6f)
        {
            foreach (var faceImage in faceImages)
            {
                faceImage.sprite = faces[2];
            }

            resultText.text = resultMessages[2];
        }
    }
}
