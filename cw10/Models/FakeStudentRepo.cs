using cw10.Models.Abstractions;

namespace cw10.Models;

public class FakeStudentRepo : IStudentRepo{
    private List<MyStudent> _students;
    
    public FakeStudentRepo() {
        _students = new List<MyStudent>(){
            new MyStudent(){Age=43, FirstName="Jan", LastName = "Kowalski", Id = 0},
            new MyStudent(){Age=23, FirstName="Adam", LastName = "Nowak", Id = 1}};
    }
        
    public List<MyStudent> GetStudents() {
        return _students;
    }
    public MyStudent? GetStudentById(int id) {
        return _students.FirstOrDefault(s => s.Id == id);
    }
    public void AddStudent(MyStudent student) {
        _students.Add(student);
    }
    public void UpdateStudent(MyStudent student) {
        throw new NotImplementedException();
    }
    public void DeleteStudent(int id) {
        MyStudent? student = _students.FirstOrDefault(s => s.Id == id);
        if (student == null) {
            return;
        }
        _students.Remove(student);
    }
}
