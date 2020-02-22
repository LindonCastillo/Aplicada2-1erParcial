using _1erParcial_Aplicada2.Data;
using _1erParcial_Aplicada2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace _1erParcial_Aplicada2.Controllers
{
    public class PagosController
    {
		public bool Guardar(Pagos pagos)
		{
			Contexto db = new Contexto();
			bool paso = false;
			try
			{
				if (db.Pagos.Any(A => A.PagoId == pagos.PagoId))
				{
					paso = Modificar(pagos);
				}
				else
				{
					paso = Insertar(pagos);
				}

			}
			catch (Exception)
			{

				throw;
			}
			finally
			{
				db.Dispose();
			}

			return paso;
		}

		public bool Insertar(Pagos pagos)
		{
			Contexto db = new Contexto();
			bool paso = false;
			try
			{
				db.Pagos.Add(pagos);
				paso = db.SaveChanges() > 0;
			}
			catch (Exception)
			{

				throw;
			}
			finally
			{
				db.Dispose();
			}

			return paso;
		}

		public bool Modificar(Pagos pagos)
		{
			Contexto db = new Contexto();
			bool paso = false;
			try
			{
				db.Entry(pagos).State = EntityState.Modified;
				paso = db.SaveChanges() > 0;
			}
			catch (Exception)
			{

				throw;
			}
			finally
			{
				db.Dispose();
			}

			return paso;
		}

		public bool Eliminar(int id)
		{
			Contexto db = new Contexto();
			bool paso = false;
			try
			{
				Pagos pagos = db.Pagos.Find(id);
				if (pagos != null)
				{
					db.Entry(pagos).State = EntityState.Deleted;
					paso = db.SaveChanges() > 0;
				}
				else
				{
					paso = false;
				}

			}
			catch (Exception)
			{

				throw;
			}
			finally
			{
				db.Dispose();
			}

			return paso;
		}


		public Pagos Buscar(int id)
		{
			Contexto db = new Contexto();
			Pagos pagos;
			try
			{
				pagos = db.Pagos.Find(id);
			}
			catch (Exception)
			{

				throw;
			}
			finally
			{
				db.Dispose();
			}

			return pagos;
		}


		public List<Pagos> GetList(Expression<Func<Pagos, bool>> expression)
		{
			Contexto db = new Contexto();
			List<Pagos> lista = new List<Pagos>();
			try
			{
				lista = db.Pagos.Where(expression).ToList();
			}
			catch (Exception)
			{

				throw;
			}
			finally
			{
				db.Dispose();
			}

			return lista;
		}
	}
}
