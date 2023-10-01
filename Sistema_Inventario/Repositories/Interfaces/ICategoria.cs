﻿using Sistema_Inventario.dtos;
using Sistema_Inventario.DTOs;

namespace Sistema_Inventario.Repositories.Interfaces
{
    public interface ICategoria
    {
        Task<int> Crear(CategoriaDTO categoria);

        Task<ICollection<CategoriaDTO>> Categorias();

        Task<CategoriaDTO> Categoria(int id);

        Task<int> Modificar(int id, CategoriaDTO categoria);
        Task<int> Eliminar(int id);

        Task<int> Guardar();

    }
}
