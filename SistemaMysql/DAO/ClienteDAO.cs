﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SistemaMysql.Entidades;

namespace SistemaMysql.DAO
{
    public class ClienteDAO
    {
        //string conexao = "SERVER=localhost; DATABASE=sistema_clientes; UID=root; PWD=;";
        //MySqlConnection con = null;
        MySqlCommand sql;
        Conexao con = new Conexao();

        public DataTable Listar()
        {
            try
            {
                con.AbrirConexao();
                sql = new MySqlCommand("SELECT * FROM clientes ORDER BY id DESC", con.con);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = sql;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Editar(Clientes dado)
        {
            try
            {
                con.AbrirConexao();
                sql = new MySqlCommand("UPDATE clientes SET nome = @nome, sexo = @sexo, nascimento = @nascimento WHERE id = @id", con.con);
                sql.Parameters.AddWithValue("@nome", dado.Nome);
                sql.Parameters.AddWithValue("@sexo", dado.Sexo);
                sql.Parameters.AddWithValue("@nascimento", dado.Nascimento);
                sql.Parameters.AddWithValue("@id", dado.Id);
                sql.ExecuteNonQuery();
                con.FecharConexao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Editar " + ex.Message);
                con.FecharConexao();
            }
        }

        internal DataTable Buscar(Clientes dado)
        {
            try
            {
                con.AbrirConexao();
                sql = new MySqlCommand("SELECT * FROM clientes WHERE nome LIKE @nome ORDER BY id DESC", con.con);
                sql.Parameters.AddWithValue("@nome", dado.Nome + "%");
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = sql;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal void Excluir(Clientes dado)
        {
            try
            {
                con.AbrirConexao();
                sql = new MySqlCommand("DELETE FROM clientes WHERE id = @id", con.con);
                sql.Parameters.AddWithValue("@id", dado.Id);
                sql.ExecuteNonQuery();
                con.FecharConexao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Excluir " + ex.Message);
                con.FecharConexao();
            }
        }

        public void Salvar(Clientes dado)
        {
            try
            {
                con.AbrirConexao();
                sql = new MySqlCommand("INSERT INTO clientes (nome, sexo, nascimento) VALUES (@nome, @sexo, @nascimento)", con.con);
                sql.Parameters.AddWithValue("@nome", dado.Nome);
                sql.Parameters.AddWithValue("@sexo", dado.Sexo);
                sql.Parameters.AddWithValue("@nascimento", dado.Nascimento);
                sql.ExecuteNonQuery();
                con.FecharConexao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Salvar " + ex.Message);
                con.FecharConexao();
            }
        }

    }
}
