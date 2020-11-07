using UnityEngine;

public class OnEntryLoadNextLevel : MonoBehaviour
{
    [SerializeField] private string sceneName;
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "Player")
            GameManager.GameManager.Instance.LoadScene(sceneName);
    }
}
