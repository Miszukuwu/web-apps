namespace cw10.Models.Abstractions;

public interface IStudentRepo {
    List<MyStudent> GetStudents();
    MyStudent? GetStudentById(int id);
    void AddStudent(MyStudent student);
    void UpdateStudent(MyStudent student);
    void DeleteStudent(int id);
}
