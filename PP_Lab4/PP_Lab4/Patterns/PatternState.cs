using System;

namespace PP_Lab4.Patterns
{
    public interface IState
    {
        public void Tap();
        public void Block();
        public void SetSmartphone(Smartphone smartphone);
    }

    public class Smartphone
    {
        private IState State { get; set; }

        public Smartphone()
        {
            ChangeState(new BlockedState());
        }

        public void ChangeState(IState state)
        {
            State = state;
            State.SetSmartphone(this);
        }

        public void BlockButton()
        {
            State.Block();
        }

        public void Tap()
        {
            State.Tap();
        }
    }

    public class BlockedState : IState
    {
        public Smartphone Smartphone { get; set; }

        public BlockedState() { ;}

        public void SetSmartphone(Smartphone smartphone)
        {
            Smartphone = smartphone;
        }

        public void Tap()
        {
            Console.WriteLine("On tap : No reaction");
        }

        public void Block()
        {
            Console.WriteLine("On block button : Smartphone unblocked");
            Smartphone.ChangeState(new UnblockedState());
        }
    }

    public class UnblockedState : IState
    {
        public Smartphone Smartphone { get; set; }

        public UnblockedState() {; }

        public void SetSmartphone(Smartphone smartphone)
        {
            Smartphone = smartphone;
        }

        public void Tap()
        {
            Console.WriteLine("On tap : tap commited");
        }

        public void Block()
        {
            Console.WriteLine("On block button : Smartphone blocked");
            Smartphone.ChangeState(new BlockedState());
        }
    }
}
