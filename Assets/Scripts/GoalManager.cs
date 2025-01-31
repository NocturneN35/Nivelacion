using UnityEngine;
using TMPro;

public class GoalManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _goalPrefab;  // The goal object prefab
    [SerializeField]
    private Camera _mainCamera;      // Reference to the main camera
    [SerializeField]
    private Camera _victoryCamera;   // Reference to the victory camera
    [SerializeField]
    private TextMeshProUGUI _victoryMessageText; // Victory message text

    private GameObject _goal;  // The goal object
    private bool _gameFinished = false;

    // Method to place the goal outside the maze, just beyond the maze boundary
    public void PlaceGoal(Vector3 mazeExitPosition, int mazeWidth)
    {
        _goal = Instantiate(_goalPrefab, new Vector3(mazeWidth + 1, 0, mazeExitPosition.z), Quaternion.identity);
        _goal.GetComponent<Collider>().isTrigger = true; // Ensure the goal is a trigger
    }

    // Called when the player enters the goal trigger zone
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !_gameFinished)  // Make sure the player has entered the goal area
        {
            _gameFinished = true;
            OnGameFinish();
        }
    }

    // Called when the game finishes
    private void OnGameFinish()
    {
        // Switch to victory camera
        _mainCamera.gameObject.SetActive(false);
        _victoryCamera.gameObject.SetActive(true);

        // Show the "You Win!" message
        _victoryMessageText.gameObject.SetActive(true);
        _victoryMessageText.text = "You Win!"; // You can change the message text here

        // Optionally, you can add any additional logic like playing a sound or delay here
        Debug.Log("Congratulations, You Win!");
    }
}
