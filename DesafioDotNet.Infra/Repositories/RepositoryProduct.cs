using DesafioDotNet.Domain.Models;
using DesafioDotNet.Infra.Infra;
using DesafioDotNet.Infra.Repositories.Base;
using DesafioDotNet.Infra.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace DesafioDotNet.Infra.Repositories
{
    public class RepositoryProduct : RepositoryBase<Product>, IRepositoryProduct
    {
        private MSSQLDB _con;

        public RepositoryProduct(MSSQLDB con) : base(con)
        {
            _con = con;
        }

        public override IEnumerable<Product> GetAll()
        {
            using var con = _con.GetCon();
            string sql = "getProducts";
            List<Product> list = new List<Product>();

            con.Open();
            SqlCommand comando = new SqlCommand(sql, con);
            SqlDataReader rdr = comando.ExecuteReader();

            while (rdr.Read())
            {
                Product product = new Product
                {
                    Id = rdr.GetInt32(0),
                    Name = rdr.GetString(1),
                    Price = rdr.GetFloat(2),
                    Brand = rdr.GetString(3),
                    CreatedAt = rdr.GetDateTime(4),
                    UpdatedAt = rdr.GetDateTime(5)
                };
                list.Add(product);
            }
            con.Close();
            return list;
        }
        public override Product GetById(int id)
        {
            Product product = new Product();
            using var con = _con.GetCon();
            string sqlQuery = "getbyid";

            con.Open();
            SqlCommand comando = new SqlCommand(sqlQuery, con)
            {
                CommandType = CommandType.StoredProcedure
            };
            comando.Parameters.AddWithValue("@Id", id);
            SqlDataReader rdr = comando.ExecuteReader();


            while (rdr.Read())
            {
                product.Id = rdr.GetInt32(0);
                product.Name = rdr.GetString(1);
                product.Price = rdr.GetFloat(2);
                product.Brand = rdr.GetString(3);
                product.CreatedAt = rdr.GetDateTime(4);
                product.UpdatedAt = rdr.GetDateTime(5);
            }
            return product;
        }

        public override void Add(Product entity)
        {
            using var con = _con.GetCon();
            string sql = "post";

            SqlCommand cmd = new SqlCommand(sql, con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue(@"Name", entity.Name);
            cmd.Parameters.AddWithValue(@"Price", entity.Price);
            cmd.Parameters.AddWithValue(@"Brand", entity.Brand);
            cmd.Parameters.AddWithValue(@"CreatedAt", entity.CreatedAt);
            cmd.Parameters.AddWithValue(@"UpdatedAt", entity.UpdatedAt);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public override void Update(Product entity, int id)
        {
            using var con = _con.GetCon();
            string sql = "put";

            SqlCommand cmd = new SqlCommand(sql, con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue(@"Id", id);
            cmd.Parameters.AddWithValue(@"Name", entity.Name);
            cmd.Parameters.AddWithValue(@"Price", entity.Price);
            cmd.Parameters.AddWithValue(@"Brand", entity.Brand);
            cmd.Parameters.AddWithValue(@"UpdatedAt", entity.UpdatedAt);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public override void Remove(int id)
        {
            using var con = _con.GetCon();
            string sqlQuery = "delet";

            SqlCommand sqlcmd = new SqlCommand(sqlQuery, con)
            {
                CommandType = CommandType.StoredProcedure
            };

            sqlcmd.Parameters.AddWithValue("@Id", id);

            con.Open();
            sqlcmd.ExecuteNonQuery();
            con.Close();
        }
    }
}

