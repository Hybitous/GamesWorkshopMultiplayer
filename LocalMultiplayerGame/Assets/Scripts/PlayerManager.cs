using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    Dictionary<int, GameObject> players;
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addPlayer(GameObject player)
    {
        PlayerInput playerInput = player.GetComponent<PlayerInput>();
        if (playerInput == null)
        {
            Debug.Log(player + " is missing PlayerInput Component");
        }
        if (players == null)
        {
            players = new Dictionary<int, GameObject>();
        }
        players.Add(playerInput.playerIndex, player);
    }

    public GameObject getPlayer(int index)
    {
        return players[index];
    }
}
