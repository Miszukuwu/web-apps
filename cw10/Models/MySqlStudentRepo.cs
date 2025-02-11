namespace cw10.Models;

using Abstractions;
using MySql.Data.MySqlClient;

public class MySqlStudentRepo : IStudentRepo {
    private readonly string? _connectionString;
    public MySqlStudentRepo(string? connectionString) {
        _connectionString = connectionString;
    }
    public List<MyStudent> GetStudents() {
        MySqlConnection connection = new MySqlConnection(_connectionString);
        MySqlCommand command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM students";
        connection.Open();
        MySqlDataReader reader = command.ExecuteReader();
        List<MyStudent> students = new List<MyStudent>();
        while (reader.Read()) {
            students.Add(new MyStudent() {
                Id = reader.GetInt32("id"),
                FirstName = reader.GetString("firstname"),
                LastName = reader.GetString("lastname"),
                Age = reader.GetInt32("age")
            });
        }
        reader.Close();
        connection.Close();
        return students;
    }
    public MyStudent? GetStudentById(int id) {
        throw new NotImplementedException();
    }
    public void AddStudent(MyStudent student) {
        MySqlConnection connection = new MySqlConnection(_connectionString);
        MySqlCommand command = connection.CreateCommand();
        command.CommandText = $"INSERT INTO students(firstname, lastname, age) VALUES('{student.FirstName}', '{student.LastName}',{student.Age})";
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }
    public void UpdateStudent(MyStudent student) {
        throw new NotImplementedException();
    }
    public void DeleteStudent(int? id) {
        MySqlConnection connection = new MySqlConnection(_connectionString);
        MySqlCommand command = connection.CreateCommand();
        command.CommandText = $"DELETE FROM students where id={id}";
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }
}
