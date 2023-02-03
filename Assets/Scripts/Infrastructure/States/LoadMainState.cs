using Data;
using Infrastructure.Services.Factory;
using Infrastructure.Services.GameStateMachine;

namespace Infrastructure.States
{
    public class LoadMainState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IFactoryService _factoryService;

        public LoadMainState(IGameStateMachine gameStateMachine, SceneLoader sceneLoader, IFactoryService factoryService)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _factoryService = factoryService;
        }

        public void Enter()
        {
            _sceneLoader.Load(Scenes.Main.GetDescription(), OnLoaded);
        }

        public void Exit()
        {
        }

        private void OnLoaded()
        {
            _factoryService.CreateUIRoot();
            _factoryService.CreateMenu();

            _gameStateMachine.Enter<DailyBonusState>();
        }
    }
}