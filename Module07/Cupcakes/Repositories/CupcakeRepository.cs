using System.Collections.Generic;
using System.IO;
using System.Linq;

using Cupcakes.Data;
using Cupcakes.Models;

using Microsoft.EntityFrameworkCore;

namespace Cupcakes.Repositories
{
    public class CupcakeRepository : ICupcakeRepository
    {
        private readonly CupcakeContext _context;

        public CupcakeRepository(CupcakeContext context)
        {
            _context = context ?? throw new System.ArgumentNullException(nameof(context));
        }

        public IEnumerable<Cupcake> GetCupcakes()
        {
            return _context.Cupcakes.ToList();
        }

        public Cupcake GetCupcakeById(int id)
        {
            return _context.Cupcakes.Include(b => b.Bakery)
                .SingleOrDefault(c => c.CupcakeId == id);
        }

        public void CreateCupcake(Cupcake cupcake)
        {
            if (cupcake.PhotoAvatar != null && cupcake.PhotoAvatar.Length > 0)
            {
                cupcake.ImageMimeType = cupcake.PhotoAvatar.ContentType;
                cupcake.ImageName = Path.GetFileName(cupcake.PhotoAvatar.FileName);
                using (var memoryStream = new MemoryStream())
                {
                    cupcake.PhotoAvatar.CopyTo(memoryStream);
                    cupcake.PhotoFile = memoryStream.ToArray();
                }
                _context.Add(cupcake);
                _context.SaveChanges();
            }
        }

        public void DeleteCupcake(int id)
        {
            var cupcake = _context.Cupcakes.SingleOrDefault(c => c.CupcakeId == id);

            if (cupcake is null) return;

            _context.Cupcakes.Remove(cupcake);
            _context.SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IQueryable<Bakery> PopulateBakeriesDropDownList()
        {
            //var bakeriesQuery = from b in _context.Bakeries
            //                    orderby b.BakeryName
            //                    select b;

            var bakeriesQuery = _context.Bakeries.OrderBy(b => b.BakeryName);

            return bakeriesQuery;
        }
    }
}
