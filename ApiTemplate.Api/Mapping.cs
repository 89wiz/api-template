﻿using ApiTemplate.Api.Endpoints;

public static class Mapping
{
    internal static void MapEndpoints(this WebApplication app)
    {
        UserMap.Map(app);
        LoginMap.Map(app);
        TaskMap.Map(app);
    }
}
