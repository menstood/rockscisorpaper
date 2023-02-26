using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    [SerializeField]
    private Button rockButton;
    [SerializeField]
    private Button scissorButton;
    [SerializeField]
    private Button paperButton;
    [SerializeField]
    private Text resultText;
    [SerializeField]
    private Text computerChoiceLabel;

    void Start()
    {
        rockButton.onClick.AddListener(() => SelectChoice(Choice.Rock));
        scissorButton.onClick.AddListener(() => SelectChoice(Choice.Scissor));
        paperButton.onClick.AddListener(() => SelectChoice(Choice.Paper));
    }

    //Select choice function for player
    void SelectChoice(Choice choice)
    {

        var computerChoice = GetRandomChoice();
        computerChoiceLabel.text = computerChoice.ToString();
        var result = GetResult(choice, computerChoice);
        resultText.text = result;
    }


    //Create GetRandomChoice
    Choice GetRandomChoice()
    {
        var random = Random.Range(0, 3);
        return (Choice)random;
    }

    

    // get result of the game by 2 input from choice enum without using if else
    string GetResult(Choice playerChoice, Choice computerChoice)
    {
        var result = (computerChoice - playerChoice + 3) % 3;
        switch (result)
        {
            case 0:
                return "Draw";
            case 1:
                return "You Win";
            case 2:
                return "You Lose";
            default:
                return "Error";
        }
    }


}
