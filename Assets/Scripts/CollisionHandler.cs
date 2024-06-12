
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag) 
        {
        case "Finish":
            Debug.Log("Finish");
            break;
        case "Fuel":
            Debug.Log("Fuel");
            break;
        case "Friendly":
            Debug.Log("Friendly");
            break;
        default:
            Debug.Log("Unfriendly");
            break;
        }
    }
}