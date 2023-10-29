using Dapper;
using System.Data;
using System.Data.SqlClient;
using SIMS.model;
using static Dapper.SqlMapper;

namespace SIMS.RepositoryFolder
{
    public class StudentRepository:IStudentRepository
    { 
        private readonly string _connectionString;
        private IDbConnection _dbCon;
        public StudentRepository()
        {
            _connectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=SIMSDb;Integrated Security=True;Connect Timeout=30;Encrypt=False";
            _dbCon = new SqlConnection(_connectionString);
        }
        public void Add(Student entity)
        {
            string query = "INSERT INTO Student (FirstName, LastName,Age, MatricNum) Values(@firstname,@lastname,@age, @matricNum)";
            _dbCon.Open();
            _dbCon.Execute(query, new { firstname = entity.FirstName, lastname = entity.LastName, age = entity.Age, matricNum = entity.MatricNumber });
            _dbCon.Close();
        }
        public void Update(Student entity)
        {
            string query = $"UPDATE Student(FirstName, LastName, Age, MatricNum) VALUES (@firstname, @lastname, @age, @matricNum)";
            _dbCon.Open();
            _dbCon.Execute(query, new { firstname = entity.FirstName, lastname = entity.LastName, age = entity.Age, matricnum = entity.MatricNumber});
            _dbCon.Close();
        }
        public void Delete(string matricNum)
        {
            
            string query = $"DELETE FROM Student WHERE matricNum='{matricNum}'";
            _dbCon .Open();
            _dbCon.Execute(query, new {});
            _dbCon.Close();
        }
        public Student GetStudent( string matricNum) {

            string query = $"Select * from Student Where MatricNum='{matricNum}'";
            _dbCon.Open();
            Student student= _dbCon.Query<Student>(query).SingleOrDefault();
            _dbCon.Close();
            return student;
        }
    }
}
