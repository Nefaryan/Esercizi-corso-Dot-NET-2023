using Microsoft.Extensions.Logging;
using SpotifakeData.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeData.Repository
{
    public class GenericRepository<T,K> where T : class
    {
        private readonly DBContext? _dbContext;
        private readonly ILogger<GenericRepository<T,K>> logger;
        private readonly string? _folderPath;

    }
}
