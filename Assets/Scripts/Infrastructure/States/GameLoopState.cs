using Infrastructure.Services.GameStateMachine;

namespace Infrastructure.States
{
    public class GameLoopState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;

        public GameLoopState(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Exit()
        {

        }

        public void Enter()
        {

        }
    }
}