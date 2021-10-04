using Microsoft.Data.SqlClient;
using Persistence.Context;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Persistence.Repository
{
    public class RepositoryRestaurant : IRestaurantRepository
    {
        private readonly SiberianContext _restaurantContext;
        public RepositoryRestaurant(SiberianContext restaurantContext)
        {
            _restaurantContext = restaurantContext;
        }
        public List<RestaurantEntity> ListRestaurants()
        {
            var query = "exec [dbo].[Sp_Restaurante] @TipoOperacion= N'LISTALLRESTAURANTS'";
            var data = _restaurantContext.Restaurante
                .FromSqlRaw<RestaurantEntity>(query).ToList();
            return data;
        }

        public async Task AddRestaurant(RestaurantEntity restaurant, string Operacion)
        {
            
            SqlConnection con = new SqlConnection(_restaurantContext.Database.GetConnectionString());
            SqlCommand cmd = new SqlCommand("Sp_Restaurante", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            param = cmd.Parameters.Add("@TipoOperacion", SqlDbType.NVarChar, 20);
            param.Value = Operacion;
            param = cmd.Parameters.Add("@NombreRestaurante", SqlDbType.NVarChar, 20);
            param.Value = restaurant.NombreRestaurante;
            param = cmd.Parameters.Add("@IdCiudad", SqlDbType.NVarChar, 20);
            param.Value = restaurant.IdCiudad;
            param = cmd.Parameters.Add("@NumeroAforo", SqlDbType.NVarChar, 20);
            param.Value = restaurant.NumeroAforo;
            param = cmd.Parameters.Add("@Telefono", SqlDbType.NVarChar, 20);
            param.Value = restaurant.Telefono;
            param = cmd.Parameters.Add("@IdRestaurante", SqlDbType.Int);
            param.Value = restaurant.IdRestaurante;

            con.Open();
            await cmd.ExecuteNonQueryAsync();
            con.Close();
            
        }

        public async Task DeleteRestaurant(int IdRestaurant)
        {
            SqlConnection con = new SqlConnection(_restaurantContext.Database.GetConnectionString());
            SqlCommand cmd = new SqlCommand("Sp_Restaurante", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            param = cmd.Parameters.Add("@TipoOperacion", SqlDbType.NVarChar, 20);
            param.Value = "DELETE";
            param = cmd.Parameters.Add("@IdRestaurante", SqlDbType.Int);
            param.Value = IdRestaurant;
            con.Open();
            await cmd.ExecuteNonQueryAsync();
            con.Close();
        }

        public async Task UpdateRestaurant(RestaurantEntity restaurant)
        {
            SqlConnection con = new SqlConnection(_restaurantContext.Database.GetConnectionString());
            SqlCommand cmd = new SqlCommand("Sp_Restaurante", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            param = cmd.Parameters.Add("@TipoOperacion", SqlDbType.NVarChar, 20);
            param.Value = "UPDATE";
            param = cmd.Parameters.Add("@NombreRestaurante", SqlDbType.NVarChar, 20);
            param.Value = restaurant.NombreRestaurante;
            param = cmd.Parameters.Add("@IdCiudad", SqlDbType.NVarChar, 20);
            param.Value = restaurant.IdCiudad;
            param = cmd.Parameters.Add("@NumeroAforo", SqlDbType.NVarChar, 20);
            param.Value = restaurant.NumeroAforo;
            param = cmd.Parameters.Add("@Telefono", SqlDbType.NVarChar, 20);
            param.Value = restaurant.Telefono;
            con.Open();
            await cmd.ExecuteNonQueryAsync();
            con.Close();
        }

        public IEnumerable<RestaurantEntity> GetRestaurant(int id)
        {
            SqlConnection con = new SqlConnection(_restaurantContext.Database.GetConnectionString());
            SqlCommand cmd = new SqlCommand("Sp_Restaurante", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            param = cmd.Parameters.Add("@TipoOperacion", SqlDbType.NVarChar, 20);
            param.Value = "FILTERESTAURANT";
            param = cmd.Parameters.Add("@IdRestaurante", SqlDbType.NVarChar, 20);
            param.Value = id;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<RestaurantEntity> TestList = new List<RestaurantEntity>();
            RestaurantEntity test = null;
            
            while (reader.Read())
            {
                test = new RestaurantEntity();
                test.IdRestaurante = int.Parse(reader["IdRestaurante"].ToString());
                test.NombreRestaurante = reader["NombreRestaurante"].ToString();
                test.NumeroAforo = int.Parse(reader["NumeroAforo"].ToString());
                test.Telefono = reader["Telefono"].ToString();
                test.FechaCreacion = DateTime.Parse(reader["FechaCreacion"].ToString());
                test.IdCiudad = int.Parse(reader["IdCiudad"].ToString());
                TestList.Add(test);
            }
            
            //await cmd.ExecuteNonQueryAsync();
            con.Close();
            //var query = $"exec [dbo].[Sp_Restaurante] @TipoOperacion= N'FILTERESTAURANT' @IdRestaurante={id}";
            //var data = _restaurantContext.Restaurante
            //    .FromSqlRaw<RestaurantEntity>(query).ToList().AsEnumerable();
            return TestList.AsEnumerable();
        }
    }
  }
