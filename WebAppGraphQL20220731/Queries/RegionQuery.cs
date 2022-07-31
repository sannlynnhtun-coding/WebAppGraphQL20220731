using Microsoft.EntityFrameworkCore;
using WebAppGraphQL20220731.EFDbContext;

namespace WebAppGraphQL20220731.Queries
{
    public class RegionQuery
    {
        public async Task<IEnumerable<Tbl_Region>> GetRegions()
        {
            var lst = await new AppDbContext().Regions.ToListAsync();
            //var lst = await db.Tbl_Region.ToListAsync();
            return lst;
        }

        public async Task<Tbl_Region> GetRegionById(int id)
        {
            var item = await new AppDbContext().Regions.Where(x => x.RegionId == id).FirstOrDefaultAsync();
            //var item = await db.Tbl_Region.Where(x => x.Id == id).FirstOrDefaultAsync();
            return item;
        }

        public async Task<Tbl_Region> AddRegion(Tbl_Region region)
        {
            var db = new AppDbContext();
            await db.Regions.AddAsync(region);
            await db.SaveChangesAsync();
            return region;
        }

        public async Task<Tbl_Region> UpdateRegion(int id, Tbl_Region region)
        {
            var db = new AppDbContext();
            region.RegionId = id;
            db.Entry(region).State = EntityState.Modified;
            db.Regions.Update(region);
            await db.SaveChangesAsync();
            return region;
        }

        public async Task<Tbl_Region> DeleteRegion(int id)
        {
            var db = new AppDbContext();
            var Tbl_Region = db.Regions.Where(x => x.RegionId == id).FirstOrDefault();
            db.Entry(Tbl_Region).State = EntityState.Deleted;
            db.Regions.Remove(Tbl_Region);
            await db.SaveChangesAsync();
            return Tbl_Region;
        }
    }
}
