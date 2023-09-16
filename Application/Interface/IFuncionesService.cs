using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IFuncionesService
    {
        void CreateFuncion(Funcion nuevaFuncion);

        List<Funcion> GetAllFunciones();

        List<Pelicula> GetAllPeliculas();

        List<Sala> GetAllSalas();

        List<Funcion> GetFuncionesPorFechaYPelicula(DateTime? fecha, string tituloPelicula);

        List<Funcion> GetFuncionesPorFecha(DateTime fecha);

        List<Funcion> GetFuncionesPorPelicula(int peliculaId);
    }


}
