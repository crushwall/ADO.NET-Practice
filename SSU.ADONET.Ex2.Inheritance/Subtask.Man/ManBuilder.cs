namespace SSU.ADONET.Ex2.Inheritance.Subtask.Man
{
    public class ManBuilder
    {
        private Man _man = new Man();

        public void CreateMan(string firstName = "Noname", int age = 0, double weight = 0, double height = 0)
        {
            _man.FirstName = firstName;
            _man.Age = age;
            _man.Weight = weight;
            _man.Height = height;
        }

        public Man GetMan()
        {
            Man tmp = new Man(_man);
            _man = new Man();

            return tmp;
        }
    }
}
