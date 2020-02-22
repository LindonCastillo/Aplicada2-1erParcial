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
    public class AsignaturasController
    {
		public bool Guardar(Asignaturas asignaturas)
		{
			Contexto db = new Contexto();
			bool paso = false;
			try
			{
				if (db.Asignaturas.Any(A => A.AsignaturaId == asignaturas.AsignaturaId))
				{
					paso = Modificar(asignaturas);
				}
				else
				{
					paso = Insertar(asignaturas);
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

		public bool Insertar(Asignaturas asignaturas)
		{
			Contexto db = new Contexto();
			bool paso = false;
			try
			{
				db.Asignaturas.Add(asignaturas);
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

		public bool Modificar(Asignaturas asignaturas)
		{
			Contexto db = new Contexto();
			bool paso = false;
			try
			{
				db.Entry(asignaturas).State = EntityState.Modified;
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
				Asignaturas asignaturas = db.Asignaturas.Find(id);
				if (asignaturas != null)
				{
					db.Entry(asignaturas).State = EntityState.Deleted;
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


		public Asignaturas Buscar(int id)
		{
			Contexto db = new Contexto();
			Asignaturas asignaturas;
			try
			{
				asignaturas = db.Asignaturas.Find(id);
			}
			catch (Exception)
			{

				throw;
			}
			finally
			{
				db.Dispose();
			}

			return asignaturas;
		}


		public List<Asignaturas> GetList(Expression<Func<Asignaturas, bool>> expression)
		{
			Contexto db = new Contexto();
			List<Asignaturas> lista = new List<Asignaturas>();
			try
			{
				lista = db.Asignaturas.Where(expression).ToList();
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
