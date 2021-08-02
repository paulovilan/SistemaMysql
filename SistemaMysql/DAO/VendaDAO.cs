﻿using MySql.Data.MySqlClient;
using SistemaMysql.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaMysql.DAO
{
    class VendaDAO
    {
        MySqlCommand sql;
        Conexao con = new Conexao();
        public void Salvar(Vendas dado)
        {
            try
            {
                con.AbrirConexao();
                sql = new MySqlCommand("INSERT INTO vendas (data, valor, id_cliente) VALUES (@data, @valor, @id_cliente)", con.con);
                sql.Parameters.AddWithValue("@data", dado.Data);
                sql.Parameters.AddWithValue("@valor", dado.Valor);
                sql.Parameters.AddWithValue("@id_cliente", dado.Id_cliente);
                sql.ExecuteNonQuery();
                con.FecharConexao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Salvar " + ex.Message);
                con.FecharConexao();
            }
        }

        internal void Editar(Vendas dado)
        {
            try
            {
                con.AbrirConexao();
                sql = new MySqlCommand("UPDATE vendas SET data = @data, valor = @valor, id_cliente = @id_cliente WHERE id = @id", con.con);
                sql.Parameters.AddWithValue("@data", dado.Data);
                sql.Parameters.AddWithValue("@valor", dado.Valor);
                sql.Parameters.AddWithValue("@id_cliente", dado.Id_cliente);
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

        internal DataTable Buscar(Vendas dado)
        {
            try
            {
                con.AbrirConexao();
                sql = new MySqlCommand("SELECT * FROM vendas WHERE id_cliente LIKE @id_cliente", con.con);
                sql.Parameters.AddWithValue("@id_cliente", dado.Id_cliente);
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

        internal void Excluir(Vendas dado)
        {
            try
            {
                con.AbrirConexao();
                sql = new MySqlCommand("DELETE from vendas WHERE id = @id", con.con);
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

        internal DataTable Listar()
        {
            try
            {
                con.AbrirConexao();
                sql = new MySqlCommand("SELECT * FROM vendas ORDER BY id DESC", con.con);
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
    }
}
