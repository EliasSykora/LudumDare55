using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;


public class CardController : MonoBehaviour, IEndDragHandler
{

    [SerializeField] int CardCost = 2;
    [SerializeField] string CardName = "Card name";
    [SerializeField] TextMeshProUGUI CardNameField;
    [SerializeField] TextMeshProUGUI CardCostField;
    [SerializeField] GameObject CanBeDroppedEffect;
    GameObject _GameController;

    [SerializeField] float requiredReputation;

    [SerializeField] string[] requiredVariables;

    Collider2D myCollider;
    GameObject enemyTarget;
    string PowerWord;

    void Start()
    {
        CardNameField.text = CardName;
        CardCostField.text = CardCost.ToString();
        myCollider = GetComponent<Collider2D>();
        PowerWord = CardName;
        UpdateCanBeDropped(false);
        _GameController = GameObject.Find("GameController");
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        // Debug.Log("Dropped");
        if (enemyTarget != null)
        {
            enemyTarget.GetComponent<EnemyController>().WordCheck(CardName);
            _GameController.GetComponent<GameController>().soulCount -= CardCost;
        }
        // enemyTarget.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("Triggered");
        if (other.tag == "Enemy") enemyTarget = other.gameObject;
        UpdateCanBeDropped(true);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Enemy") enemyTarget = null;
        UpdateCanBeDropped(false);
    }

    public string GetPowerWord(int index)
    {
        return PowerWord;
    }

    void UpdateCanBeDropped(bool canBeDropped)
    {
        CanBeDroppedEffect.SetActive(canBeDropped);
    }
}
