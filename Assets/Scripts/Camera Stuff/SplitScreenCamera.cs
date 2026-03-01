using UnityEngine;

public class SplitScreenCamera : MonoBehaviour
{
    public int playerIndex = 1;

    private void Awake()
    {
        Camera cam = GetComponent<Camera>();
        //Add if check here for if it's single player or two players
        if (playerIndex == 1)
            cam.rect = new Rect(0f, 0f, 0.5f, 1f); // left half
        else if (playerIndex == 2)
            cam.rect = new Rect(0.5f, 0f, 0.5f, 1f); // right half
    }
}