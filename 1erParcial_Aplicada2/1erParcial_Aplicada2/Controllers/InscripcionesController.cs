using _1erParcial_Aplicada2.Data;
using _1erParcial_Aplicada2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1erParcial_Aplicada2.Controllers
{
    public class InscripcionesController
    {
        public bool Guardar(Inscripciones inscripciones)
        {
			Contexto db = new Contexto();
			bool paso = false;
			try
			{
				if(db.Inscripciones.Any(A => A.InscripcionId == inscripciones.InscripcionId))
				{

				}
				else
				{

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

		public bool Insertar(Inscripciones inscripciones)
		{
			Contexto db = new Contexto();
			bool paso = false;
			try
			{
				db.Inscripciones.Add(inscripciones);
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

		public bool Modificar(Inscripciones inscripciones)
		{
			Contexto db = new Contexto();
			bool paso = false;
			try
			{
				db.Entry(inscripciones).State = EntityState.Modified;
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
				Inscripciones inscripciones = db.Inscripciones.Find(id);
				if (inscripciones != null)
				{
					db.Entry(inscripciones).State = EntityState.Deleted;
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


		public Inscripciones Buscar(int id)
		{
			Contexto db = new Contexto();
			Inscripciones inscripciones;
			try
			{
				
			}
			catch (Exception)
			{

				throw;
			}
			finally
			{
				db.Dispose();
			}
		}
    }
}
