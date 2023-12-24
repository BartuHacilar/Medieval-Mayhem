using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public int targetSceneBuildIndex = 1; // Set the target scene build index in the Inspector.

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) // Check if the Enter key is pressed.
        {
            // Load the target scene based on its build index.
            SceneManager.LoadScene(targetSceneBuildIndex);
        }
    }
}
                    