using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadChecking : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag(GameTag.Platform.ToString()))
        {
            var platform = col.gameObject.GetComponent<Platform>();
            if(platform is Enemy)
            {
                
                if (GameManager.Ins)
                {
                    GameManager.Ins.state = GameState.Gameover;
                }
                if (GUIManager.Ins && GUIManager.Ins.gameoverDialog)
                {
                    GUIManager.Ins.gameoverDialog.Show(true);
                }

                if (AudioController.Ins)
                {
                    AudioController.Ins.PlaySound(AudioController.Ins.gameover);
                }
                Destroy(col.gameObject);

                Debug.Log("Gameover!");
            }
        }

    }
}
