using Infrastructure.Services.DailyBonus;
using Infrastructure.Services.Factory;
using Infrastructure.Services.GameStateMachine;

namespace Infrastructure.States
{
    public class DailyBonusState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IDailyBonusService _dailyBonusService;
        private readonly IFactoryService _factoryService;
        
        public DailyBonusState(IGameStateMachine gameStateMachine, IDailyBonusService dailyBonusService, IFactoryService factoryService)
        {
            _factoryService = factoryService;
            _gameStateMachine = gameStateMachine;
            _dailyBonusService = dailyBonusService;
        }
        
        public void Enter()
        {
            if (_dailyBonusService.CheckHaveBonus())
                _factoryService.CreateDailyBonus();

            _gameStateMachine.Enter<GameLoopState>();
        }
        
        public void Exit()
        {
            
        }
    }
}