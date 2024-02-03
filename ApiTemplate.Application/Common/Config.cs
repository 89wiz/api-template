using System.Reflection;

namespace ApiTemplate.Application.Common;

public static class Config
{
    public static Assembly Assembly => typeof(Config).Assembly;
}
