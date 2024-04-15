using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;



public class EnemyController : MonoBehaviour
{
    [SerializeField] int Soul = 0;
    // [SerializeField] string Wish = "Wish";
    [SerializeField] TextMeshProUGUI SoulField;
    [SerializeField] TextMeshProUGUI WishField;
    [SerializeField] Wishes wish;
    [SerializeField] Image EnemyImage;
    [SerializeField] Sprite startingEnemyImage;
    [SerializeField] GameObject SuccessDialogue;
    [SerializeField] GameObject FailDialogue;
    [SerializeField] string RoundNumber;
    GameObject _GameController;
    [SerializeField] GameObject _RoundCounter;
    [SerializeField] GameObject rivalEnemy;


    [SerializeField] EnemyState[] states;
    int maxWishes;
    int currentWish = 0;
    int startingSoul;
    bool wishEnded = false;

    void Start()
    {
        WishField.text = wish.GetWish();
        maxWishes = wish.powerWords.Length;
       ChangeEnemyImage(startingEnemyImage);
        startingSoul = Soul;
        _GameController = GameObject.Find("GameController");
      
    }

    // Update is called once per frame
    void Update()
    {
        SoulField.text = Soul.ToString();
        if (gameObject.activeSelf)
        {
            _RoundCounter.SetActive(true);
            _RoundCounter.GetComponent<TextMeshProUGUI>().text = RoundNumber;
        }
    }

    public void ChangeEnemyImage(Sprite EnemySprite){
        EnemyImage.sprite = EnemySprite;
        EnemyImage.SetNativeSize();
    }

    public void WordCheck(string CardName)
    {
        if (wishEnded) return;
        
        if(CardName=="Exit")
        {
            autoFail();
            return;
        }
       
       if (wish.GetPowerWords(currentWish).Contains(CardName))
        {
            Debug.Log("Ano");
            Soul += 2;
        } else
        {
            Debug.Log("Ne");
            Soul -= 5;
        }

        if (Soul < 0) Soul = 0;
        currentWish++;

        if (currentWish >= maxWishes)
        {
            if (rivalEnemy != null) rivalEnemy.GetComponent<EnemyController>().autoFail();
            if (Soul > 0) _GameController.GetComponent<GameController>().soulCount += Soul;
            if (Soul >= (startingSoul)) {WishField.text = wish.GetSuccessResponse();} 
             else {WishField.text = wish.GetFailResponse(); }
             Invoke("wishEnd", 2.0f);
            
        }
    }

    public void autoFail()
    {
       

        WishField.text = wish.GetFailResponse();
        Invoke("wishEnd", 2.0f);
    }
    private void wishEnd() {

        gameObject.SetActive(false);
        SuccessDialogue.SetActive(true);
        _RoundCounter.SetActive(false);
      //  _GameController.GetComponent<GameController>().SummoningEnds();
    }
}
