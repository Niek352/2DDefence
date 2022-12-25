using Game.MatchController;
using Ui;

namespace Game.Ui.Controllers
{
	public class ScoreController : UiController<ScoreView>
	{
		public ScoreController(IMatchController matchController)
		{
			matchController.OnScoreChanged += OnScoreChanged;
		}
		
		private void OnScoreChanged(int obj)
		{
			View.ScoreTXT.text = $"Score: {obj}";
		}
	}
}