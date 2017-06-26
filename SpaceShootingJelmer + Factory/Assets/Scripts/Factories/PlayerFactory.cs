using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFactory : MonoBehaviour, IFactory
{
    public GameObject player;

    public GameObject Create(Vector2 position)
    {
        GameObject player_object = GameObject.Instantiate(player, position, Quaternion.identity);
        return player_object;
    }
}
