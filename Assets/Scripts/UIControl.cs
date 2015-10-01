using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIControl : MonoBehaviour{
	
	public Text score;
	public Text totalScore;
	public Text round;
	public Text finalScore;
	public Text finalScoreText;
	public Image panel;

	// Use this for initialization
	void Start () {

		score.text = GameControl.score.ToString ();
		totalScore.text = GameControl.finalScore.ToString ();
		round.text = GameControl.round.ToString ();

		finalScore.canvasRenderer.SetAlpha (0f);
		finalScoreText.canvasRenderer.SetAlpha (0f);
		panel.canvasRenderer.SetAlpha (0f);

	}
	
	// Update is called once per frame
	void Update () {
		score.text = GameControl.score.ToString ();
		totalScore.text = GameControl.finalScore.ToString ();
		round.text = GameControl.round.ToString ();

		if (GameControl.round == 5) {
			finalScore.text = GameControl.finalScore.ToString ();

			finalScore.canvasRenderer.SetAlpha (1f);
			finalScoreText.canvasRenderer.SetAlpha (1f);
			panel.canvasRenderer.SetAlpha (1f);
		}
	}
}
