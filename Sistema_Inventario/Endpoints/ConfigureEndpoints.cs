namespace Sistema_Inventario.Endpoints
{
    public static  class ConfigureEndpoints
    {
        public static void UseEndpoints(this WebApplication app) {
            CategoriaEndpoints.Add(app);
            ProveedorEndPoints.Add(app);
            RolEndpoints.Add(app);
            ProductoEndpoints.Add(app);
            TransaccionEndPoints.Add(app);

        }
    }
}
