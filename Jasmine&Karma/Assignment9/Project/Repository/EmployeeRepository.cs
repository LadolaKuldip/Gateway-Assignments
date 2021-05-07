namespace Project.Repository
{
    public class EmployeeRepository : IGetDataRepository
    {
        public string[] GetAll()
        {
            string[] array = { "Kuldip","Parth"};
            return array;
        }

        public string GetNameById(int id)
        {
            string name;
            if (id == 1)
            {
                name = "Kuldip";
            }
            else if (id == 2)
            {
                name = "Parth";
            }
            else
            {
                name = "Not Found";
            }
            return name;
        }
    }
}
