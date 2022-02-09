namespace PP_Lab1.Patterns
{
    public interface IFlag
    {
        string ShowFlag();
    }

    public class UkrainianFlag : IFlag
    {
        public string ShowFlag()
        {
            return "Ukrainian";
        }
    }

    public class PortugalFlag : IFlag
    {
        public string ShowFlag()
        {
            return "Protugal";
        }
    }

    public interface ICoach
    {
        string ShowCoach();
    }

    public class UkrainianCoach : ICoach
    {
        public string ShowCoach()
        {
            return "Andrey Shevchenko";
        }
    }

    public class PortugalCoach : ICoach
    {
        public string ShowCoach()
        {
            return "Fernando Santos";
        }
    }

    public interface ITeamFactory
    {
        IFlag CreateFlag();
        ICoach CreateCoach();
    }

    public class UkrainianTeam : ITeamFactory
    {
        public IFlag CreateFlag()
        {
            return new UkrainianFlag();
        }
        public ICoach CreateCoach()
        {
            return new UkrainianCoach();
        }
    }

    public class PortugalTeam : ITeamFactory
    {
        public IFlag CreateFlag()
        {
            return new PortugalFlag();
        }
        public ICoach CreateCoach()
        {
            return new PortugalCoach();
        }
    }

    public class FootballTeam
    {
        public IFlag Flag { get; set; }
        public ICoach Coach { get; set; }

        public FootballTeam(ITeamFactory TeamFactory)
        {
            Flag = TeamFactory.CreateFlag();
            Coach = TeamFactory.CreateCoach();
        }

        public string GetInformation()
        {
            return $"Flag: {Flag.ShowFlag()}, Coach: {Coach.ShowCoach()}";
        }
    }
}
