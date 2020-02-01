using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private int playerID = 0;

    private Player player = null;

    // Start is called before the first frame update
    void Start()
    {
        player = ReInput.players.GetPlayer(playerID);
    }

    
    public float Horizontal { get { return player.GetAxis("Horizontal"); } }
    public float Vertical { get { return player.GetAxis("Vertical"); } }

    public Vector2 MovementInput { get { return player.GetAxis2D("Horizontal", "Vertical"); } }

    public bool Interact { get { return player.GetButtonDown("Interact"); } }
    public bool Join { get { return player.GetButtonDown("Join"); } }
    public bool Leave { get { return player.GetButtonDown("Leave"); } }
}
