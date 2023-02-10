using System.Collections.Generic;
using System.Linq;
using System;
using Model;
using DAL;

namespace BLL
{
    public  class FornecedorBLL
    {
         IFornecedorRepositorio _FornecedorRepositorio;

         public FornecedorBLL()
        {   
            try
            {
                _FornecedorRepositorio = new FornecedorRepositorio();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Fornecedor> Get_FornecedorInfo(int ID = -1)
        {
            try
            {
                if (ID == -1)
                {
                    return _FornecedorRepositorio.GetTodos().ToList();
                }
                else
                {
                    return _FornecedorRepositorio.Get(u => u.fornecedorId == ID).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void AdicionarFornecedor(Fornecedor forn)
        {
            try
            {
                _FornecedorRepositorio.Adicionar(forn);
                _FornecedorRepositorio.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Fornecedor Localizar(int id)
        {
            try
            {
                return _FornecedorRepositorio.Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExcluirFornecedor(Fornecedor forn)
        {
            try
            {
                _FornecedorRepositorio.Deletar(c => c == forn);
                _FornecedorRepositorio.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AlterarFornecedor(Fornecedor forn)
        {
            try
            {
                _FornecedorRepositorio.Atualizar(forn);
                _FornecedorRepositorio.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
