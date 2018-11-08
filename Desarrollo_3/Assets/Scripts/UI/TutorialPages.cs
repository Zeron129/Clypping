using UnityEngine;
using UnityEngine.UI;

public class TutorialPages : MonoBehaviour {

    [SerializeField] GameObject[] Pages;
    [SerializeField] Text PageNumberText;
    int _pageNumber;
    
    void Awake () {
        PageNumberText.text = 1+ "/" + Pages.Length.ToString();
    }	
	/*void Update () {	
	}*/

    public void NextPage() {
        Pages[_pageNumber].SetActive(false);
        if (_pageNumber!= Pages.Length-1)
            _pageNumber++;
        else
            _pageNumber = 0;
        Pages[_pageNumber].SetActive(true);
        PageNumberText.text = _pageNumber + 1 + "/" + Pages.Length.ToString();
    }

    public void LastPage() {
        Pages[_pageNumber].SetActive(false);
        if (_pageNumber != 0)
            _pageNumber--;
        else
            _pageNumber = Pages.Length-1;
        Pages[_pageNumber].SetActive(true);
        PageNumberText.text = _pageNumber + 1 + "/" + Pages.Length.ToString();
    }
}
