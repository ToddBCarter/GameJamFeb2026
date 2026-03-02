using UnityEngine;

public class Player2Toggle : MonoBehaviour
{
    void Awake()
    {
        gameObject.SetActive(SplitScreenCamera.isMulti);
    }
}
