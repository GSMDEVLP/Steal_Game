using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    private static int _score = 0;
    private static Text _scoreText;
    // Start is called before the first frame update
    void Start()
    {
        _scoreText = GetComponent<Text>();
        _scoreText.text = _score.ToString();
    }

    public static void ScoreHit(int scorePerHit)
    {
        _score += scorePerHit;
        _scoreText.text = _score.ToString();
    }
}
