namespace SSU.ADONET.Ex2.Inheritance.Subtask.Man
{
    public class Man
    {
        public string FirstName { get; set; }

        public int Age { get; set; }

        public double Weight { get; set; }

        public double Height { get; set; }

        public Man() { }

        public Man(Man previousMan)
        {
            FirstName = previousMan.FirstName;
            Age = previousMan.Age;
            Weight = previousMan.Weight;
            Height = previousMan.Height;
        }
    }
}
