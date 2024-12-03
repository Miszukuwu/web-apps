using System;
using System.Data;
using Microsoft.Data.Sqlite;

namespace cw8.Models;

public class ProductsRepo
{
    private readonly string? _connString;
    public ProductsRepo() {
        _connString = "Data Source=ProductsDB.db";
    }
    public List<Product> GetProducts() {
        List<Product> products = new List<Product>();
        SqliteConnection connection = new SqliteConnection(_connString);
        SqliteCommand command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM `Products`";
        connection.Open();
        SqliteDataReader dataReader = command.ExecuteReader();
        while (dataReader.Read()) {
            products.Add(new Product{
                Id = dataReader.GetInt32(0),
                Name = dataReader.GetString(1),
                Price = dataReader.GetFloat(2),
                Type = dataReader.GetString(3)
            });
        }
        connection.Close();
        return products;
    }
    public Product? GetProductById(int id){
        SqliteConnection connection = new SqliteConnection(_connString);
        SqliteCommand command = connection.CreateCommand();
        command.CommandText = $"SELECT * FROM `Products` WHERE id=@id";
        command.Parameters.AddWithValue("@id", id);
        connection.Open();
        SqliteDataReader dataReader = command.ExecuteReader();
        if (!dataReader.HasRows) {
            return null;
        }
        dataReader.Read();
        Product product = new Product{
            Id = dataReader.GetInt32(0),
            Name = dataReader.GetString(1),
            Price = dataReader.GetFloat(2),
            Type = dataReader.GetString(3)
        };
        connection.Close();
        return product;
    }
    public void AddProduct(Product product) {
        SqliteConnection connection = new SqliteConnection(_connString);
        SqliteCommand command = connection.CreateCommand();
        command.CommandText = "INSERT INTO `Products`(`name`,`price`,`type`) VALUES(@name,@price,@type)";
        command.Parameters.AddWithValue("@name", product.Name);
        command.Parameters.AddWithValue("@price", product.Price);
        command.Parameters.AddWithValue("@type", product.Type);
        connection.Open();
        command.ExecuteNonQuery();
    }
}
