using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
   
    [System.Serializable]
    public class GameState
    {
        public float reputation = 0.0f;
       

        public Dictionary<string, string> variables = new Dictionary<string, string>();
    }

    [SerializeField]
    private GameObject _hand;
    [SerializeField]
    private GameObject _soulCounter;
    [SerializeField]
    private GameObject _cardHolder;
    public int soulCount = 5;
    [SerializeField]
    private GameObject _totalCountObject;
    [SerializeField]
    public int totalCount = 0;
    [SerializeField]
    private TextMeshProUGUI _totalCountText;

    public static GameController instance
    {
        get
        {
            var gameObject = GameObject.FindWithTag(Tags.GameController);
            var gameController = gameObject?.GetComponent<GameController>();
            Debug.Assert(gameController != null);
            return gameController;
        }
    }

    public GameObject hand { get { return _hand; } }
    public GameObject soulCounter { get { return _soulCounter; } }
    public GameObject cardHolder { get { return _cardHolder; } }

    private GameState state = new GameState();

    public float reputation
    {
        get { return state.reputation; }
    }

    public string GetVariable(string variableName)
    {
        string value;
        if (state.variables.TryGetValue(variableName, out value))
        {
            return value;
        }
        return null;
    }

    void Update()
    {if (soulCount < 0) soulCount = 0;
        _soulCounter.GetComponent<TMP_Text>().text = soulCount.ToString();
    }

    public void SummoningEnds()
    {
        totalCount += soulCount;
        _totalCountText.text = totalCount.ToString();
        _totalCountObject.SetActive(true);

    }
}
