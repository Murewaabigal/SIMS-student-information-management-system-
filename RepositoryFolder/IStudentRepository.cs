using SIMS.model;

namespace SIMS.RepositoryFolder
{
    public interface IStudentRepository
    {
        public void Add(Student entity);
        public void Update(Student entity);
        public void Delete(string matricNum);
        public Student GetStudent(string firstname);
    }
}
