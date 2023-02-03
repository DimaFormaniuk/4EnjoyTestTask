using Game.Services;
using Infrastructure.Services;
using Infrastructure.Services.Factory;
using Infrastructure.Services.GameStateMachine;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoad;

namespace Infrastructure.States
{
    public class LateRegistrationState : IState
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly AllServices _services;
        private readonly ICoroutineRunner _coroutineRunner;

        public LateRegistrationState(IGameStateMachine stateMachine, AllServices services, ICoroutineRunner coroutineRunner)
        {
            _stateMachine = stateMachine;
            _services = services;
            _coroutineRunner = coroutineRunner;
        }

        public void Enter()
        {
            LateRegistration();

            _stateMachine.Enter<LoadMainState>();
        }

        public void Exit()
        {
        }

        private void LateRegistration()
        {
            SubscribeToFactory();

            _services.RegisterSingle<ILifeService>(new LifeService(_services.Single<IPersistentProgressService>(),_services.Single<ISaveLoadService>()));
            _services.RegisterSingle<ITimerService>(new TimerService(_services.Single<IPersistentProgressService>(), _services.Single<ILifeService>(), _coroutineRunner));
            //_services.RegisterSingle<IDailyBonusService>(new DailyBonusService(_services.Single<IPersistentProgressService>()));
        }

        private void SubscribeToFactory()
        {
            _services.Single<IFactoryService>().Registered(_services.Single<ISaveLoadService>());
        }
    }
}