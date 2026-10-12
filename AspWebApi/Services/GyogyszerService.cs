using AspWebApi.Models;
using MySql.Data.MySqlClient;

namespace AspWebApi.Services
{
    public class GyogyszerService
    {
        ﻿
            public List<Gyogyszer> GetAllGyogyszer()
            {
                List<Gyogyszer> gyogyszerek = new List<Gyogyszer>();
            try
            {
                string connectionString = "SERVER = localhost;" +
                              "DATABASE= patika;" +
                              "UID = root;" +
                              "PASSWORD =;";
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = connectionString;
                conn.Open();
                string sql = "SELECT * FROM gyogyszer";
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Gyogyszer gyogysz = new Gyogyszer();
                    gyogysz.Id = reader.GetInt32("Id");
                    gyogysz.Nev = reader.GetString("Nev");
                    gyogysz.Hatoanyag = reader.GetString("Hatoanyag");
                    gyogysz.Venykoteles = reader.GetBoolean("Venykoteles");
                    gyogysz.kepnev = reader.GetString("kepnev");
                    gyogyszerek.Add(gyogysz);
                }
                conn.Close();
                return gyogyszerek;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            }


            public Gyogyszer GetbyId(int id)
            {
                Gyogyszer result;
                try
                {
                    string connectionString = "SERVER = localhost;" +
                                  "DATABASE= patika;" +
                                  "UID = root;" +
                                  "PASSWORD =;";
                    MySqlConnection conn = new MySqlConnection();
                    conn.ConnectionString = connectionString;
                    conn.Open();
                    string sql = "SELECT * FROM gyogyszer WHERE Id = @id";
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = sql;
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@id", id);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        result = new Gyogyszer();
                        result.Id = reader.GetInt32("Id");
                        result.Nev = reader.GetString("Nev");
                        result.Hatoanyag = reader.GetString("Hatoanyag");
                        result.Venykoteles = reader.GetBoolean("Venykoteles");
                        result.kepnev = reader.GetString("kepnev");
                        return result;
                    }
                    conn.Close();
                return null;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);

                    //Console.WriteLine("Hiba történt!", ex.Message);
                    //return null;
                }
            }
        }
    }

