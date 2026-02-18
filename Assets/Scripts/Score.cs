using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score Instance { get; private set; }
    [SerializeField] private TextMeshProUGUI _scoreText;
    private int _score;

    private void Awake()
    {
        Instance = this;
    }

    public int ScoreBoard
    {
        get => _score;

        set
        {
            if (_score == value) return;

            _score = value;

            _scoreText.SetText($"Score: {_score}");
        }
    }
}