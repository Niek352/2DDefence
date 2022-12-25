using System;
using Game.Enemy;
using Game.Health;
using Game.Services.EnemyStorage;
using Game.Services.PlayerStorage;
using Game.Ui;
using VContainer.Unity;

namespace Game.MatchController.Impl
{
	public class MatchController : IStartable, IMatchController
	{
		private const int SCORE_FOR_WIN = 30;
		private readonly IEnemyStorage _enemyStorage;
		private readonly IPlayerStorage _playerStorage;
		private readonly WinWindow _winWindow;
		private readonly LooseWindow _looseWindow;
		private int _currentScore;

		private bool _isEnd;
		public event Action<int> OnScoreChanged;
		
		public MatchController(IEnemyStorage enemyCleanUp, IPlayerStorage playerStorage, WinWindow winWindow, LooseWindow looseWindow)
		{
			_enemyStorage = enemyCleanUp;
			_winWindow = winWindow;
			_looseWindow = looseWindow;
			_playerStorage = playerStorage;
		}
		
		public void Start()
		{
			_enemyStorage.OnDead += OnEnemyDead;
			_playerStorage.Player.Health.OnDead += OnPlayerDead;
		}
		
		private void OnPlayerDead(IHealth obj)
		{
			if (!_isEnd)
			{
				EndMatch(false);
			}
		}

		private void OnEnemyDead(IEnemyContext obj)
		{
			_currentScore += obj.ScorePoints;
			OnScoreChanged?.Invoke(_currentScore);
			if (_currentScore >= SCORE_FOR_WIN && !_isEnd)
			{
				EndMatch(true);
			}
		}

		private void EndMatch(bool isWin)
		{
			_isEnd = true;
			if (isWin)
			{
				_winWindow.Show();
			}
			else
			{
				_looseWindow.Show();
			}
		}
	}
}