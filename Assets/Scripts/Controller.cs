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
    private Button spockButton;
    [SerializeField]
    private Button lizardButton;
    [SerializeField]
    private Text resultText;
    [SerializeField]
    private Text computerChoiceLabel;

    void Start()
    {
        rockButton.onClick.AddListener(() => SelectChoice(Choice.Rock));
        scissorButton.onClick.AddListener(() => SelectChoice(Choice.Scissors));
        paperButton.onClick.AddListener(() => SelectChoice(Choice.Paper));
        spockButton.onClick.AddListener(() => SelectChoice(Choice.Spock));
        lizardButton.onClick.AddListener(() => SelectChoice(Choice.Lizard));
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
        var random = Random.Range(0, 5);
        return (Choice)random;
    }

    // get result of the game by 2 input from choice enum
    string GetResult(Choice playerChoice, Choice computerChoice)
    {
        var result = (computerChoice - playerChoice) % 5;
        var result_mod = result % 5;
        if (result_mod == 0)
        {
            return "Draw";
        }
        else if (result_mod % 2 == 0)
        {
            return "You Lost";
        }
        else// (result_mod % 2 == 1)
        {
            return "You Won";
        }

    }

}
