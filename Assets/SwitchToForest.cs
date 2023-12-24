using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchToForest : MonoBehaviour
{
    public int targetSceneBuildIndex = 6; // Set the target scene build index in the Inspector.

    private void OnMouseDown()
    {
        // Load the target scene based on its build index when the collider is clicked.
        SceneManager.LoadScene(targetSceneBuildIndex);
    }
}
