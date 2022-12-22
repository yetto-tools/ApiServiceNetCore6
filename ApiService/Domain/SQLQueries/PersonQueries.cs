namespace ApiService.Domain.SQLQueries
{
    public class PersonQueries
    {
        public string GetPeopleAll { get; }

        public PersonQueries() {
            GetPeopleAll = "SELECT * FROM db_rrhh.usuario";
        }
    }
}
