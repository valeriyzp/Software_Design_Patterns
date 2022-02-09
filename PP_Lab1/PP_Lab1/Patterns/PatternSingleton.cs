namespace PP_Lab1.Patterns
{
    class ProgrammInformation
    {
        private static ProgrammInformation _programmInformation;
        public string Readme { get; set; }
        private ProgrammInformation()
        {
            Readme = "Author Valeriy Kozlov";
        }
        public static ProgrammInformation GetProgrammInformation()
        {
            if(_programmInformation == null)
                _programmInformation = new ProgrammInformation();

            return _programmInformation;
        }
    }
}
